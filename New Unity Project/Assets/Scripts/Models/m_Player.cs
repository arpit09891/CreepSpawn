using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DamageSystem;


namespace Player
{
    [System.Serializable]
    public class m_Player :MonoBehaviour
    {
        public float MaxHealth;
        public float MovementSpeed;
        public DamageType damageType;
        public float DamagePerShot;
        //public float CurrentHealth;
        public ArmorType armorType;
        public float armorValue;
        public float attackSpeed;
        public float shootingRange;

    }
}