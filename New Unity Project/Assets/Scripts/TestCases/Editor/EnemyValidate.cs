using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;


public class EnemyValidate{

    [Test]
    public void validatePlayerHealth()
    {
        m_Enemy enemyModel = GameObject.FindGameObjectWithTag("Enemy").GetComponent<m_Enemy>();
        Assert.IsTrue(enemyModel.startingHealth > 0);
        Assert.IsTrue(enemyModel.attackDamage >= 0);
        Assert.IsTrue(enemyModel.armorValue >= 0);
        Assert.IsTrue(enemyModel.attackSpeed > 0 && enemyModel.attackSpeed < 60);
        Assert.IsTrue(enemyModel.evasionPercentage > 0 && enemyModel.evasionPercentage < 60);
        Assert.IsTrue(enemyModel.scoreValue > 0);
        Assert.IsTrue(enemyModel.movementSpeed >= 0);
    }
}
