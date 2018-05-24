using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
//using UnityEngine.Assertions;
//using NUnit.Framework;

public class PlayerValidate : MonoBehaviour {
    float MaxHealth;
    float currentHealth;
    float DamagePerShot;
    float armorValue;
    float attackSpeed;
    float shootingRange;

    m_Player playerModel;
	
    //[Test]
    //public void validatePlayerHealth()
    //{
    //    Assert.IsFalse(playerModel.MaxHealth > 0);
    //    Assert.IsFalse(playerModel.DamagePerShot >= 0);
    //    Assert.IsFalse(armorValue >=0 );
    //    Assert.IsFalse(attackSpeed > 0 && attackSpeed < 60);
    //    Assert.IsFalse(shootingRange > 10 && shootingRange < 200);
    //}
}
