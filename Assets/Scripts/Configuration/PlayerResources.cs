using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerResources", order = 2)]
public class PlayerResources : ScriptableObject
{
    public double StartCryptoCurrency;
    public double StartEnergy;
    public int StartOre;
    
    private double _cryptoCurrency;
    private double _energy = 0;
    private int _ore;
    
    public void Init()
    {
        _cryptoCurrency = StartCryptoCurrency;
        _energy = StartEnergy;
        _ore = StartOre;
        
    }

    //Add
    public void AddCryptoCurrency(double crypto)
    {
        _cryptoCurrency += crypto;
        if(_cryptoCurrency >= 5000)
            Debug.Log("Win");
    }

    public void AddEnergy(double energy)
    {
        _energy += energy;
    }

    public void AddOre(int ore)
    {
        _ore += ore;
    }
    
    //Remove
    public bool RemoveCryptoCurrency(double crypto)
    {
        if (_cryptoCurrency - crypto >= 0)
        {
            _cryptoCurrency -= crypto;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool RemoveEnergy(double energy)
    {
        if (_energy - energy >= 0)
        {
            _energy -= energy;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool RemoveOre(int ore)
    {
        if (_ore - ore >= 0)
        {
            _ore -= ore;
            return true;
        }
        else
        {
            return false;
        }
    }
}
