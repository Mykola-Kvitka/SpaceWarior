using System.Collections.Generic;
using SpaceShip.Modules;
using UnityEngine;

namespace SpaceShip
{
    public class SpaceShip : MonoBehaviour
    {
        [SerializeField] private List<Module> _modules;
        private float _currentHealth = 0;
        private float _maxHealth = 0;
        private int _currentDamage;
    
    
    }
}
