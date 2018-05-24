using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

using Player;
public class PlayerValidate {


    [Test]
    public void validatePlayerHealth()
    {
        m_Player playerModel = GameObject.FindGameObjectWithTag("Player").GetComponent<m_Player>();
        Assert.IsTrue(playerModel.MaxHealth > 0);
        Assert.IsTrue(playerModel.DamagePerShot >= 0);
        Assert.IsTrue(playerModel.armorValue >= 0);
        Assert.IsTrue(playerModel.attackSpeed > 0 && playerModel.attackSpeed < 60);
        Assert.IsTrue(playerModel.shootingRange > 10 && playerModel.shootingRange < 200);
    }
}
