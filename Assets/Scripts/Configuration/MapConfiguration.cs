using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MapConfiguration", order = 1)]
public class MapConfiguration : ScriptableObject
{
    /// <summary>
    /// GameObjects of Map
    /// </summary>
    public GameObject orbitalStationPrefab;
    public GameObject planetPrefab;
    public GameObject spacePrefab;
    public GameObject playerPrefab;
    public GameObject asteroid;

    /// <summary>
    /// Planet name
    /// </summary>
    public List<string> planetNames = new List<string>(){
        ("Luna"), 
        ("Phobos") ,
        ("Deimos") ,
        ("Io") ,
        ("Europa") ,
        ("Ganymede") ,
        ("Callisto") ,
        ("Amalthea") ,
    };

    /// <summary>
    /// Map size in hexagons
    /// </summary>
    public int  gridWidthInHexes = 40;
    public int  squareSide = 1000;
    public int gridHeightInHexes = 40;
}
