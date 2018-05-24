using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DamageSystem {

    public enum DamageType
    {
        Physical, Ability, None

    };
	
    public enum ArmorType
    {
        Physical, Ability, None
    };

    public class Armor : MonoBehaviour
    {
        public ArmorType armorType;
        public int armorValue;
    };
}
