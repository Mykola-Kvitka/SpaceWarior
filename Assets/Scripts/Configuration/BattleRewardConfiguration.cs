using UnityEngine;

namespace Configuration
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BattleRewardConfiguration", order = 0)]
    public class BattleRewardConfiguration : ScriptableObject
    { 
        public double rewardInEnergy = 100;
        public int rewardInOre = 1000;

    }
}