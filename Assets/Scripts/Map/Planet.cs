using Configuration;
using Enum;
using Events;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Map
{
    public class Planet : ZeroInvokerEvent
    {
        [SerializeField]private PlanetConfig _planetConfig;
        [SerializeField] private PlayerResources _playerResources;

    
        [SerializeField] private string _name;

        private void Awake()
        {
            unityEventsZ.Add(EventName.Battle, new BattleEvent());
            EventManager.AddZeroInvoker(EventName.Battle, this);
        
            //EventManager.AddIntListener(EventName.PlanetMining, Mining);
        }

        private void Mining(int count)
        {
            _playerResources.AddOre(count);
            PirateAttacked();
        }

        private void PirateAttacked()
        {
            if (Random.Range(0, 100) <= _planetConfig._chanseBeAttackedByPirets)
            {
                unityEventsZ[EventName.GameOver].Invoke();
            }
        }
    

        public void GenerateName(string name)
        {
            _name = name;
        }
    }
}
