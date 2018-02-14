using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRoom {
    private int roomLength = 0;
    private int roomWidth = 0;
    private int enemyCount = 0;
    private int xPos = 0, yPos = 0;
    private LevelDirection entranceDirection;
    private LevelDirection exitDirection;

    #region Properties
    public int RoomLength {get {return roomLength;} set {roomLength = value;}}
    public int RoomWidth {get {return roomWidth;} set {roomWidth = value;}}
    public int EnemyCount {get {return enemyCount;} set {enemyCount = value;}}
    public int XPos {get {return xPos;} set {xPos = value;}}
    public int YPos {get {return yPos;} set {yPos = value;}}
    public LevelDirection EntranceDirection {get {return entranceDirection;} set {entranceDirection = value;}}
    public LevelDirection ExitDirection {get {return exitDirection;} set {exitDirection = value;}}
    #endregion

    //Used for first room
    public void InitializeRoom(Level lvl) {
        //Set length & width
        roomLength = Random.Range(lvl.Data.RoomLengthMin, lvl.Data.RoomLengthMax);
        roomWidth = Random.Range(lvl.Data.RoomWidthMin, lvl.Data.RoomWidthMax);

        //Set position
        xPos = Mathf.RoundToInt(lvl.MapWidth / 2.0f - roomWidth / 2.0f);
        yPos = Mathf.RoundToInt(lvl.MapLength / 2.0f - roomLength / 2.0f);
        //Corridor.Initialize
    }

    public void InitializeRoom(Level lvl, LevelCorridor corridor) {
        //Set length & width
        roomLength = Random.Range(lvl.Data.RoomLengthMin, lvl.Data.RoomLengthMax);
        roomWidth = Random.Range(lvl.Data.RoomWidthMin, lvl.Data.RoomWidthMax);

        entranceDirection = corridor.CorridorDirection;
        switch (entranceDirection) {
            case LevelDirection.NORTH:
                roomLength = Mathf.Clamp(roomLength, 1, lvl.MapLength - corridor.EndingPositionY);
                yPos = corridor.EndingPositionY;
                xPos = Random.Range(corridor.EndingPositionX - roomWidth + 1, corridor.EndingPositionX);
                xPos = Mathf.Clamp(xPos, 0, lvl.MapWidth - roomWidth);
                break;
            case LevelDirection.EAST:
                roomWidth = Mathf.Clamp(roomWidth, 1, lvl.MapWidth - corridor.EndingPositionX);
                xPos = corridor.EndingPositionX;
                yPos = Random.Range(corridor.EndingPositionY - roomLength + 1, corridor.EndingPositionY);
                yPos = Mathf.Clamp(yPos, 0, lvl.MapLength - roomLength);
                break;
            case LevelDirection.SOUTH:
                roomLength = Mathf.Clamp(roomLength, 1, corridor.EndingPositionY);
                yPos = corridor.EndingPositionY - roomLength + 1;
                xPos = Random.Range(corridor.EndingPositionX - roomWidth + 1, corridor.EndingPositionX);
                xPos = Mathf.Clamp(xPos, 0, lvl.MapWidth - roomWidth);
                break;
            case LevelDirection.WEST:
                roomWidth = Mathf.Clamp(roomWidth, 1, corridor.EndingPositionX);
                xPos = corridor.EndingPositionX - roomWidth + 1;
                yPos = Random.Range(corridor.EndingPositionY - roomLength + 1, corridor.EndingPositionY);
                yPos = Mathf.Clamp(yPos, 0, lvl.MapLength - roomLength);
                break;
        }
    }
}
