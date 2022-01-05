using Configuration;
using Enum;
using Events;
using UnityEngine;
using UnityEngine.Events;

namespace Trade
{
    public class BuyEnergy : MonoBehaviour
    {
        [SerializeField] private PlayerResources _playerResources;

        private BuyEnergyEvent _buyEnergyEvent;
    
        private void Start()
        {
            EventManager.AddBuyEnergyListener(Buy);
        }


        private void Buy(int energy, TradeName name)
        {
            switch (name)
            {
                case TradeName.BuyWithDelivery:
                    if (energy < 1500)
                    {
                        BuyEnergyNow(energy, 0.4);
                    }
                    else
                    {
                        BuyEnergyNow(energy, 0.3);
                    }

                    break;
                case TradeName.Buy:
                    if (energy < 100)
                    {
                        BuyEnergyNow(energy, 0.5);
                    }
                    else if (energy < 500)
                    {
                        BuyEnergyNow(energy, 0.4);
                    }
                    else if (energy < 1500)
                    {
                        BuyEnergyNow(energy, 0.3);
                    }
                    else
                    {
                        BuyEnergyNow(energy, 0.1);
                    }

                    break;
            }
        }

        private void BuyEnergyNow(int energy, double price)
        {
            if (_playerResources.RemoveCryptoCurrency(energy * price))
            {
                _playerResources.AddEnergy(energy);
            }
            else
                Debug.Log("Not enouth money");
        }

        public void AddBuyEnergyEventListener(UnityAction<int, TradeName> buyEnergyEventHandler)
        {
            _buyEnergyEvent.AddListener(buyEnergyEventHandler);
        }
    }
}

