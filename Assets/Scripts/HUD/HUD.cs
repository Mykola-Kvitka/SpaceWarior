using Configuration;
using Enum;
using Events;
using UnityEngine;

namespace HUD
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private HUDConfiguration _hudConfiguration;
    
        private void Start()
        {
            _hudConfiguration.Start();
            _hudConfiguration.currencyText.text = "Currency: " + _hudConfiguration.GetResources().StartCryptoCurrency;
            _hudConfiguration.oreText.text = "Ore: " + _hudConfiguration.GetResources().StartOre;
            _hudConfiguration.energyText.text = "Energy: " + _hudConfiguration.GetResources().StartEnergy;
        
            //events
            EventManager.AddZeroListener(EventName.GameOver, GameOver);
        }
    
        private void GameOver()
        {
            Object.Instantiate(Resources.Load("GameOver"));
        }  
    }
}
