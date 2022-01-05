using UnityEngine;

namespace Configuration.ShipModelConfig
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpaceShip/EngineModule", order = 5)]
    public class EngineModule : ModuleConfigs
    {
        public int forTheBattle;
        public int forTheHundred;
    }
}
