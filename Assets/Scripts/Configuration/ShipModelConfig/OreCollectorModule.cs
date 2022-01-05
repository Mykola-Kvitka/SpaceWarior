using UnityEngine;

namespace Configuration.ShipModelConfig
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpaceShip/OreCollectorModule", order = 6)]
    public class OreCollectorModule : ModuleConfigs
    {
        public int energyPerCollect;

    }
}
