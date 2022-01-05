using UnityEngine;

namespace Configuration
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Link", order = 1)]
    public class Links : MonoBehaviour
    {
        [SerializeField] private MapConfiguration _mapConfiguration;
    }
}
