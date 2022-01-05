using Configuration;
using Enum;
using Events;
using UnityEngine;

namespace Trade
{
    public class SellResources : MonoBehaviour
    {
        [SerializeField] private PlayerResources _playerResources;

        private void Start()
        {
            EventManager.AddIntListener(EventName.SellOre, Sell);
        }

        private void Sell(int ore)
        {
        
            if (ore < 100)
            {
                SellOre(ore,0.5);
            }
            else if (ore < 500)
            {
                SellOre(ore,0.4);
            }
            else if (ore < 1500)
            {
                SellOre(ore,0.3);
            }
            else
            {
                SellOre(ore,0.1);
            }
        }

        private void SellOre(int ore, double price)
        {
            if (_playerResources.RemoveOre(ore))
            {
                _playerResources.AddCryptoCurrency(ore * price);
            }
            else
            {
                Debug.Log("Not enouth ore");
            }
        }
    }
}
