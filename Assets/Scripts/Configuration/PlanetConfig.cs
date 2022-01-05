using UnityEngine;

namespace Configuration
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlanetConfig", order = 1)]
    public class PlanetConfig : ScriptableObject
    {
        public double _chanseBeAttackedByPirets;
    }
}
