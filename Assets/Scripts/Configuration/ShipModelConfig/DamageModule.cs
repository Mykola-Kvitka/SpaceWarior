using UnityEngine;

namespace Configuration.ShipModelConfig
{
  [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpaceShip/DamageModule", order = 2)]
  public class DamageModule : ModuleConfigs
  {
    public int energyPerShot;
    public int damage;
  }
}
