using UnityEngine;

namespace Configuration
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AsteroidResources", order = 3)]
    public class AsteroidResources : ScriptableObject
    {
        [SerializeField] private int _countOfRessorsMin;
        [SerializeField] private int _countOfRessorsMax;

        public int Count()
        {
            return Random.Range(_countOfRessorsMin, _countOfRessorsMax);
        }
    }
}
