using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Random = UnityEngine.Random;

public class BattleWithPirites : ZeroInvokerEvent
{
    [SerializeField] private ShipData _shipData;
    [SerializeField] private PlayerResources _playerResources;

    /// <summary>
    /// Refactore to SO
    /// </summary>
    [SerializeField] private double rewardInEnergy = 100;
    [SerializeField] private int rewardInOre = 1000;
    
    private void Awake()
    {
        unityEventsZ.Add(EventName.GameOver, new GameOverEvent());
        EventManager.AddZeroInvoker(EventName.GameOver, this);
        
        EventManager.AddZeroListener(EventName.Battle, Battle);
    }

    public void Battle()
    {
        float pirateStrength =
            Random.Range(Mathf.Round(_shipData._maxHealth * 0.8f), Mathf.Round(_shipData._maxHealth * 1.2f));
        
        string battleLog = "";
        CalculatedPiretsDamage(out var pirateDamage);

        battleLog = BattleLogic(_shipData._currentDamage, _shipData._currentHealth, pirateDamage, battleLog, pirateStrength);
        
        BattleLogSaveHelper.FileCreation(battleLog);
    }

    private void CalculatedPiretsDamage(out float pirateDamage)
    {
        int pirateCannonCount = Random.Range(2, 5);
        pirateDamage = 0;

        for (int i = 0; i < pirateCannonCount; i++)
        {
            int level = Random.Range(1, 3);
            if (level == 1)
                pirateDamage += 50;
            else if (level == 2)
                pirateDamage += 60;
            else
            {
                pirateDamage += 75;
            }
        }
    }

    private string BattleLogic(float shipDamage, float shipStrength, float pirateDamage, string battleLog,
        float pirateStrength)
    {
        while (true)
        {
            shipStrength -= pirateDamage;
            battleLog += "Pirets attacked ship! Damage " + pirateDamage.ToString() + "\n";
            if (shipStrength < 0)
            {
                battleLog += "Ship was destroied! \n";      
                unityEventsZ[EventName.GameOver].Invoke(); 
                break;
            }

            battleLog += "Ship attacked pirates! Damage " + shipDamage.ToString() + "\n";
            pirateStrength -= shipDamage;
            if (pirateStrength < 0)
            {
                _playerResources.AddEnergy(rewardInEnergy);
                _playerResources.AddOre(rewardInOre);
                battleLog += "Pirets was destroied! \n";
                break;
            }
        }
        return battleLog;
    }
}
