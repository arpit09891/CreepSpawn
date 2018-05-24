using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class s_UIData {
    public float currentHealth;
    public float timer;
    public float score;

    public s_UIData()
    {
        currentHealth = 100f;
        timer = 30f;
        score = 0f;
    }
}
