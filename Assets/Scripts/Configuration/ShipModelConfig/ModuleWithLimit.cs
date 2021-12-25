using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpaceShip/ModuleWithLimit", order = 4)]
public class ModuleWithLimit : ModuleConfigs
{
   public int limit;
}
