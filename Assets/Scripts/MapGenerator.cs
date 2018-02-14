using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {
    private Vector3 origin = Vector3.zero;
    private Vector3 currentPos = Vector3.zero;
    [SerializeField] private int mapHeight = 0, mapWidth = 0;
    [SerializeField] private GameObject tilePrefab = null;
    [SerializeField] private GameObject wallTilePrefab = null;

    void Awake() {
        Init();
    }

    // Use this for initialization
    void Start () {
        GenerateMap(new LevelData());
        GenerateBoundaryWalls();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Init() {
    }

    private void GenerateMap(LevelData data) {
        for (int i = 0; i < mapWidth; i++) {
            currentPos = new Vector3(origin.x + i, origin.y, origin.z);
            GenerateTileColumn(currentPos, mapHeight, tilePrefab);
        }
    }

    private void GenerateTileRow(Vector3 startingPos, float rowLength, GameObject tile) {
        for (int i = 0; i < rowLength; i++) {
            currentPos = new Vector3(startingPos.x + i, startingPos.y, startingPos.z);
            PlaceTile(currentPos, tile);
        }
    }

    private void GenerateTileColumn(Vector3 startingPos, float columnHeight, GameObject tile) {
        for (int i = 0; i < columnHeight; i++) {
            currentPos = new Vector3(startingPos.x, startingPos.y, startingPos.z + i);
            PlaceTile(currentPos, tile);
            }
        }

    public void GenerateBoundaryWalls() {
        //Place boundary walls outside of generated map.
        //Generate outside columns
        GenerateTileColumn(new Vector3(origin.x - 1, origin.y, origin.z - 1), mapHeight + 2, wallTilePrefab);
        GenerateTileColumn(new Vector3(origin.x + mapWidth, origin.y, origin.z - 1), mapHeight + 2, wallTilePrefab);
        //Generate outside rows
        GenerateTileRow(new Vector3(origin.x, origin.y, origin.z - 1), mapWidth, wallTilePrefab);
        GenerateTileRow(new Vector3(origin.x, origin.y, origin.z + mapHeight), mapWidth, wallTilePrefab);
    }

    private void PlaceTile(Vector3 pos, GameObject tile) {
        GameObject tmpTile = Instantiate(tile);
        tmpTile.transform.position = pos; 
    }
}
