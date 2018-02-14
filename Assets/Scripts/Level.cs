using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    private LevelData data = null;
    private int mapLength = 0;
    private int mapWidth = 0;
    private int roomCount = 0;
    private int enemyCount = 0;
    private List<LevelTile> mapTiles = new List<LevelTile>();
    private List<LevelRoom> rooms = new List<LevelRoom>();
    //private List<Enemy> enemies = new List<Enemy>();

    public LevelData Data {get {return data;} set {data = value;}}
    public int MapLength {get {return mapLength;} set {mapLength = value;}}
    public int MapWidth {get {return mapWidth;} set {mapWidth = value;}}
    public int RoomCount {get {return roomCount;} set {roomCount = value;}}
    public int EnemyCount {get {return enemyCount;} set {enemyCount = value;}}
    public List<LevelTile> MapTiles {get {return mapTiles;} set {mapTiles = value;}}
    public List<LevelRoom> Rooms {get {return rooms;} set {rooms = value;}}

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //This will be moved to Level class
    private void InitializeLevelData() {
        mapLength = Random.Range(data.MapLengthMin, data.MapLengthMax);
        mapWidth = Random.Range(data.MapWidthMin, data.MapWidthMax);
        roomCount = Random.Range(data.RoomCountMin, data.RoomCountMax);
        enemyCount = Random.Range(data.EnemyCountMin, data.EnemyCountMax);
    }
}
