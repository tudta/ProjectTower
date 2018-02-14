using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class LevelTile {
    private LevelTileType tileType = LevelTileType.NONE;
    private bool isTraversable = false;
    private Sprite tileSprite = null;

    #region Properties
    public LevelTileType TileType {get {return tileType;} set {tileType = value;}}
    public bool IsTraversable {get {return isTraversable;} set {isTraversable = value;}}
    public Sprite TileSprite {get {return tileSprite;} set {tileSprite = value;}}
    #endregion
}