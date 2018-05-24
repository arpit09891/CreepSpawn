using UnityEngine;
using System.Collections;
using DamageSystem;


public class EnemyAttack : MonoBehaviour
{
    float timeBetweenAttacks = 0.5f;
    float attackDamage = 10;
    DamageType damageType;

    EvasionCalculator evasionCalculator;
    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    m_Enemy enemyModel;   

    bool playerInRange;
    float timer;



    void Awake ()
    {
        enemyModel = GetComponent<m_Enemy>();
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
    }
    private void Start()
    {
        timeBetweenAttacks = enemyModel.attackSpeed;
        attackDamage = enemyModel.attackDamage;
        damageType = enemyModel.damageType;
    }


    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack ();
        }

        if(playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger ("PlayerDead");
        }
    }


    void Attack ()
    {
        timer = 0f;
        float localDamage;
        //probable Damage
        float probableDamage = 0;
        probableDamage = Random.Range(0,3);
        localDamage = attackDamage - probableDamage;

        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage (localDamage, damageType);
        }
    }
}
