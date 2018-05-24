using UnityEngine;
using UnityEngine.UI;
using DamageSystem;
using UnityEngine.Events;
using System.Collections.Generic;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth;
    public Slider healthSlider;

    
    float evasionPercentage;
    ArmorType armorType;
    float armorValue;
    [HideInInspector]
    public float startingHealth = 100f;
    [HideInInspector] 
    public float sinkSpeed = 2.5f;

    [HideInInspector]
    public AudioClip deathClip;
    int scoreValue = 10;

    m_Enemy enemyModel;
    private Text UILog;
    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;
    string enemyName;
    private UnityAction attackListener;
    private UnityAction damageListener;
    float damage;

    void Awake ()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();
        enemyModel = GetComponent<m_Enemy>();

        startingHealth = enemyModel.startingHealth;
        sinkSpeed = enemyModel.sinkSpeed;
        scoreValue = enemyModel.scoreValue;
        evasionPercentage = enemyModel.evasionPercentage;
        armorType = enemyModel.armorType;
        armorValue = enemyModel.armorValue;

        currentHealth = startingHealth;
        healthSlider.value = currentHealth;
        enemyName = GetComponent<StateController>().enemyName;
        UILog = GameObject.FindGameObjectWithTag("Canvas").GetComponentInChildren<Text>(true);
        attackListener = new UnityAction(EnemyAttacked);
        damageListener = new UnityAction(EnemyDamage);
    }

    private void OnEnable()
    {
        EventManager.StartListening(enemyName + "attack", attackListener);
        ;
        EventManager.StartListening(enemyName + "damage", damageListener);

    }

    private void OnDisable()
    {
        EventManager.StopListening(enemyName + "attack", attackListener);
        
        EventManager.StopListening(enemyName + "damage", damageListener);
    }


    void Update ()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (float amount, Vector3 hitPoint, DamageType damageType)
    {
        EventManager.TriggerEvent(enemyName + "attack");
        EvasionCalculator evC = new EvasionCalculator();
        if(isDead)
            return;
        if(evC.IsEvaded(evasionPercentage))
        {
            Debug.Log("Evasion is true");
            return;
        }
        if (damageType.ToString() == armorType.ToString())
        {
            float reducedAmount = 0;
            if (armorValue != 0)
            {
                Debug.Log("Before Armor Reduction" + amount);
                reducedAmount = (amount * armorValue) / 100;
            }
            amount -= reducedAmount;
            Debug.Log("After Armor Reduction" + amount);
        }

        damage = amount;
        enemyAudio.Play ();
        EventManager.TriggerEvent(enemyName + "damage");
        currentHealth -= amount;

        healthSlider.value = currentHealth;  
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    public void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;
        //GetComponent<StateController>().navMeshAgent.enabled = false;

        anim.SetTrigger ("Dead");

        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
    }


    public void StartSinking ()
    {
        //GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent<EnemyMovement>().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        //ScoreManager.score += scoreValue;
        Destroy (gameObject, 2f);
    }

    void EnemyDamage()
    {
        UILog.text += enemyName + " recieved " + damage + "\n";
    }

    void EnemyAttacked()
    {
        UILog.text += enemyName + "is attacked \n";
    }
}
