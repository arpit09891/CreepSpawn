
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DamageSystem;

public class m_Enemy : MonoBehaviour {
    public float movementSpeed;
    public float startingHealth;
    public float currentHealth;
    public ArmorType armorType;
    public float armorValue;
    public float attackSpeed;
    public DamageType damageType;
    public float attackDamage;
    public int scoreValue;
    public float sinkSpeed;
    public float evasionPercentage;
}
