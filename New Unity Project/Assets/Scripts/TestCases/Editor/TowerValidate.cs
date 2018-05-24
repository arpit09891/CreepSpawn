using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TowerValidate{

    [Test]
    public void validatePlayerHealth()
    {
        m_Tower towerModel = GameObject.FindGameObjectWithTag("Tower").GetComponent<m_Tower>();
        Assert.IsTrue(towerModel.MaxHealth > 0);
        Assert.IsTrue(towerModel.DamagePerShot >= 0);
        Assert.IsTrue(towerModel.armorValue >= 0);
        Assert.IsTrue(towerModel.attackSpeed > 0 && towerModel.attackSpeed < 100);
        Assert.IsTrue(towerModel.shootingRange > 80 && towerModel.shootingRange < 300);
    }
}
