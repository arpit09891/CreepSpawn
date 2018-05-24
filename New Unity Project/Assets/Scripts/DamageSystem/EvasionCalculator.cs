using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DamageSystem
{
    public class EvasionCalculator/* : MonoBehaviour*/
    {
        private int rand;
        public bool IsEvaded(float evasionPercentage)
        {
            rand = Random.Range(0, 101);
            if (rand <= evasionPercentage)
            {
                return true;
            }

            if (rand > evasionPercentage)
            {
                return false;
            }
            Debug.Log("rand check " + rand);
            return false;
        }

    }
}