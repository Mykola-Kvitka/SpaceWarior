using UnityEngine;

namespace Configuration
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ShipData", order = 1)]
    public class ShipData : ScriptableObject
    {
        public float _currentHealth = 0;
        public float _maxHealth = 0;
        public int _currentDamage;
    }
}
