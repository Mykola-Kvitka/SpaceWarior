using Configuration;
using Enum;
using Events;
using Map;
using UnityEngine;

namespace Mining
{
    public class MiningEventListener : ZeroInvokerEvent
    {
        [SerializeField] private PlayerResources _playerResources;
        [SerializeField] private PlanetConfig _planetConfig;

        private void Awake()
        {
            unityEventsZ.Add(EventName.Battle, new BattleEvent());
            //EventManager.AddZeroInvoker(EventName.Battle, this);
        
            //EventManager.AddIntListener(EventName.AsteroidMining, MiningAsteroid);
            //    EventManager.AddIntListener(EventName.PlanetMining, MiningPlanet);
        }

        private void MiningAsteroid(int count, Asteroid asteroid)
        {

        }

        private void MiningPlanet(int count)
        {
            _playerResources.AddOre(count);
            PirateAttacked();
        }
    
        private void PirateAttacked()
        {
            if (Random.Range(0, 100) <= _planetConfig._chanseBeAttackedByPirets)
            {
                unityEventsZ[EventName.Battle].Invoke();
            }
        }
    }
}
