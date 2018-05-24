using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

[System.Serializable]
public class s_Player {
    public float currentHealth;
    public float positionX;
    public float positionY;
    public float positionZ;

    public s_Player()
    {

        currentHealth = 100f;
        positionX = 0f;
        positionY = 0f;
        positionZ = 0f;    
    }

}
