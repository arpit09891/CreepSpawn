using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DamageSystem;
public class ProximityBasedDamage : MonoBehaviour {
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 50;
    public DamageType damageType;

    GameObject enemy;    
    EnemyHealth enemyHealth;
    bool enemyInRange;
    float timer;
    Animator anim;

    // Use this for initialization
    void Start () {
        //enemy = GameObject.FindGameObjectWithTag("Enemy");
        //enemyHealth = enemy.GetComponent<EnemyHealth>();
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == enemy)
        {
            enemyInRange = false;
        }
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && enemyInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }       
    }

    void Attack()
    {
        timer = 0f;

        if (enemyHealth.currentHealth > 0)
        {
            enemyHealth.TakeDamage(attackDamage, Vector3.zero, damageType);
        }
    }
}
