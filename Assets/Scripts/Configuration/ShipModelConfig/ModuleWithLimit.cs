using UnityEngine;

namespace Configuration.ShipModelConfig
{
   [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpaceShip/ModuleWithLimit", order = 4)]
   public class ModuleWithLimit : ModuleConfigs
   {
      public int limit;
   }
}
