using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelData {
    private Sprite levelSprite = null;
    private AudioClip levelMusic = null;
    private int mapLengthMin = 0, mapLengthMax = 0;
    private int mapWidthMin = 0, mapWidthMax = 0;
    private int roomLengthMin = 0, roomLengthMax = 0;
    private int roomWidthMin = 0, roomWidthMax = 0;
    private int roomCountMin = 0, roomCountMax = 0;
    private int corridorLengthMin = 0, corridorLengthMax = 0;
    private int enemyCountMin = 0, enemyCountMax = 0;
    private GameObject[] floorTiles = null;
    private GameObject[] obstacleTiles = null;
    private GameObject[] wallTiles = null;
    private GameObject[] enemies = null;

    #region Properties
    public Sprite LevelSprite {get {return levelSprite; } set {levelSprite = value;}}
    public AudioClip LevelMusic {get {return levelMusic;} set {levelMusic = value;}}
    public int MapLengthMin {get {return mapLengthMin;} set {mapLengthMin = value;}}
    public int MapLengthMax {get {return mapLengthMax;} set {mapLengthMax = value;}}
    public int MapWidthMin {get {return mapWidthMin;} set {mapWidthMin = value;}}
    public int MapWidthMax {get {return mapWidthMax;} set {mapWidthMax = value;}}
    public int RoomLengthMin {get {return roomLengthMin;} set {roomLengthMin = value;}}
    public int RoomLengthMax {get {return roomLengthMax;} set {roomLengthMax = value;}}
    public int RoomWidthMin {get {return roomWidthMin;} set {roomWidthMin = value;}}
    public int RoomWidthMax {get {return roomWidthMax;} set {roomWidthMax = value;}}
    public int RoomCountMin {get {return roomCountMin;} set {roomCountMin = value;}}
    public int RoomCountMax {get {return roomCountMax;} set {roomCountMax = value;}}
    public int CorridorLengthMin {get {return corridorLengthMin;} set {corridorLengthMin = value;}}
    public int CorridorLengthMax {get {return corridorLengthMax;} set {corridorLengthMax = value;}}
    public int EnemyCountMin {get {return enemyCountMin;} set {enemyCountMin = value;}}
    public int EnemyCountMax {get {return enemyCountMax;} set {enemyCountMax = value;}}
    public GameObject[] FloorTiles {get {return floorTiles;} set {floorTiles = value;}}
    public GameObject[] ObstacleTiles {get {return obstacleTiles;} set {obstacleTiles = value;}}
    public GameObject[] WallTiles {get {return wallTiles;} set {wallTiles = value;}}
    public GameObject[] Enemies {get {return enemies;} set {enemies = value;}}
    #endregion
}
