using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class s_Enemy{
    public float currentHealth;

    public float positionX;
    public float positionY;
    public float positionZ;

    public string type;
    public int spawnIndex;
    public int laneIndex;
}
