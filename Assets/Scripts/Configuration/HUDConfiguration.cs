using UnityEngine;
using UnityEngine.UI;

namespace Configuration
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/HUDConfiguration", order = 1)]
    public class HUDConfiguration : ScriptableObject
    {
        public Text currencyText;
        public Text energyText;
        public Text oreText;

        [SerializeField]private PlayerResources _playerResources;

        public void Start()
        {
            currencyText = GameObject.FindGameObjectWithTag("Currency").GetComponent<Text>();
            energyText = GameObject.FindGameObjectWithTag("Energy").GetComponent<Text>();
            oreText = GameObject.FindGameObjectWithTag("Ore").GetComponent<Text>();
        }

        public PlayerResources GetResources()
        {
            return _playerResources;
        }
    }
}
