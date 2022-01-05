using UnityEngine;

namespace Configuration.ShipModelConfig
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpaceShip/ModuleConfigs", order = 1)]
    public class ModuleConfigs : ScriptableObject
    {
        public double price;
        public double strength;

    }
}
