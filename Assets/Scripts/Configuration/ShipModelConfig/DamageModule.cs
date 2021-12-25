using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpaceShip/DamageModule", order = 2)]
public class DamageModule : ModuleConfigs
{
  public int energyPerShot;
  public int damage;
}
