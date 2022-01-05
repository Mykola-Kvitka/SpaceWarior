using Configuration;
using Enum;
using Events;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Map
{
    public class Asteroid : IntInvokerEvent
    {
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    
        [SerializeField ] private AsteroidResources _asteroidResources;
        [SerializeField] private PlayerResources _playerResources;
    
        private string _name;
        private int _countOfResources;
        private void Start()
        {
            EventManager.AddIntListener(EventName.AsteroidMining, Mining);
        
            _countOfResources = _asteroidResources.Count();
            GanerateName();
        }
    
        private void Mining(int count)
        {
            if (_countOfResources - count > 0)
            {
                _countOfResources -= count;
                _playerResources.AddOre(count);
            }
            else
            {
                _playerResources.AddOre(_countOfResources);
                Destroy(this.gameObject);
            }
        }

        private void GanerateName()
        {
            for (int i = 0; i < 8; i++)
            {
                name += chars[Random.Range(0,chars.Length)];
            }
        }
    }
}
