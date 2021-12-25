using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private MapConfiguration _mapConfiguration;

    /// <summary>
    /// hexs list
    /// </summary>
    private List<GameObject> hexs;

    void Awake()
    {
        EventManager.Initialize();
        hexs = new List<GameObject>();
        СreateGridMap();
    }
    
    /// <summary>
    /// Generate map method 
    /// </summary>
    private void СreateGridMap()
    {
        //Game object which is the parent of all the hex tiles
        GameObject hexGridGO = new GameObject("HexGrid");

        CreateSpace(hexGridGO);
        CreateStation(hexGridGO);
        CreatePlanets(hexGridGO);
        SpawnAsteroid();
    }

    private void CreateSpace(GameObject hexGridGO)
    {
        for (float y = 0; y < _mapConfiguration.gridHeightInHexes; y++)
        {
            for (float x = 0; x < _mapConfiguration.gridWidthInHexes; x++)
            {
                //GameObject assigned to Hex public variable is cloned
                GameObject hex = (GameObject) Instantiate(_mapConfiguration.spacePrefab);
                //Current position in grid
                Vector2 gridPos = new Vector2(x, y);
                hex.transform.position = gridPos;
                hex.transform.parent = hexGridGO.transform;
                hexs.Add(hex);
            }
        }
    }

    private void CreateStation(GameObject hexGridGO)
    {
        int hexNumber = ((_mapConfiguration.gridWidthInHexes * _mapConfiguration.gridHeightInHexes) / 2)
                        + _mapConfiguration.gridWidthInHexes / 2;

        GameObject orbital = (GameObject) Instantiate(_mapConfiguration.orbitalStationPrefab);
        GameObject player = (GameObject) Instantiate(_mapConfiguration.playerPrefab);
        orbital.transform.position = hexs[hexNumber].transform.position;
        player.transform.position = hexs[hexNumber].transform.position;
        player.GetComponent<Player>().SetSquareSide(_mapConfiguration.squareSide);
        hexs[hexNumber] = orbital;
        orbital.transform.parent = hexGridGO.transform;

        GameObject.Find("Main Camera").transform.position =
            new Vector3(orbital.transform.position.x, orbital.transform.position.y, -10);
    }

    private void CreatePlanets(GameObject hexGridGO)
    {
        int mapSize = (_mapConfiguration.gridWidthInHexes * _mapConfiguration.gridHeightInHexes);
        int halfOfMapSize = (mapSize / 2);
        int firtsPlanet = Random.Range(0, halfOfMapSize - _mapConfiguration.gridWidthInHexes);
        int secoundPlanet = Random.Range(halfOfMapSize + _mapConfiguration.gridWidthInHexes, mapSize - 1);

        SpawntPlanet(firtsPlanet,hexGridGO);
        SpawntPlanet(secoundPlanet,hexGridGO);
    }

    private void SpawntPlanet(int position, GameObject hexGridGO)
    {
        GameObject planet = (GameObject) Instantiate(_mapConfiguration.planetPrefab);
        planet.transform.position = hexs[position].transform.position;
        hexs[position] = planet;
        planet.GetComponent<Planet>()
            .GenerateName(_mapConfiguration.planetNames[Random.Range(0, _mapConfiguration.planetNames.Count)]);
        planet.transform.parent = hexGridGO.transform;

    }

    private void SpawnAsteroid()
    {
        while (true)
        {
            int iter = Random.Range(0, hexs.Count);
            
            if (!hexs[iter].CompareTag("Spawnless"))
            {
                GameObject asteroid = (GameObject) Instantiate(_mapConfiguration.asteroid);
                asteroid.transform.position = hexs[iter].transform.position;
                break;
            }
        }
    }
}