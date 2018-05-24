using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using DamageSystem;
using UnityEngine.Events;
using Player;

public class PlayerHealth : MonoBehaviour
{

    public float currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    [HideInInspector]
    public bool isDead;

    [HideInInspector]
    public float startingHealth = 100f;
    ArmorType armor;
    float armorValue;
    //float tempDMGTimer;
    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    bool damaged;

    private Text UILog;
    private UnityAction attackListener;
    private UnityAction damageListener;
    float damage;
    private m_Player playerModel;
    void Awake ()
    {
        playerModel = GetComponent<m_Player>();
        startingHealth = playerModel.MaxHealth;
        armor = playerModel.armorType;
        armorValue = playerModel.armorValue;
        //tempDMGTimer = Time.realtimeSinceStartup;
        anim = GetComponent <Animator> ();
        playerAudio = GetComponent <AudioSource> ();
        playerMovement = GetComponent <PlayerMovement> ();
        playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;

        UILog = GameObject.FindGameObjectWithTag("Canvas").GetComponentInChildren<Text>(true);
        attackListener = new UnityAction(UnitAttacked);
        damageListener = new UnityAction(UnitDamage);

        //Fetch data from Game System
        Game.current.LoadPlayerData();
    }

    private void OnEnable()
    {
        EventManager.StartListening("playerattack", attackListener);
       
        EventManager.StartListening("playerdamage", damageListener);

    }

    private void OnDisable()
    {
        EventManager.StopListening("playerattack", attackListener);

        EventManager.StopListening("playerdamage", damageListener);
    }



    void Update ()
    {

        healthSlider.value = currentHealth;
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }


    public void TakeDamage (float amount, DamageType damageType)
    {
        EventManager.TriggerEvent("playerattack");
        if (damageType.ToString() == armor.ToString())
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
        damaged = true;
        damage = amount;
        EventManager.TriggerEvent("playerdamage");
        currentHealth -= amount;

        healthSlider.value = currentHealth;

        playerAudio.Play ();

        if(currentHealth <= 0 && !isDead)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        playerShooting.DisableEffects ();

        anim.SetTrigger ("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play ();

        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }


    public void RestartLevel ()
    {
        SceneManager.LoadScene (0);
    }

    void UnitDamage()
    {
        UILog.text += "Player recieved " + damage + "\n";
    }

    void UnitAttacked()
    {
        UILog.text += "Player is attacked \n";
    }
}
