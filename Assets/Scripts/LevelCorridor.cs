using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCorridor {
    private int startingXPos = 0;
    private int startingYPos = 0;
    private int corridorLength = 0;
    private int maxCorridorLength = 0;
    private LevelDirection corridorDirection;

    #region Properties
    public int StartingXPos {get {return startingXPos;} set {startingXPos = value;}}
    public int StartingYPos {get {return startingYPos;} set {startingYPos = value;}}
    public int CorridorLength {get {return corridorLength;} set {corridorLength = value;}}
    public LevelDirection CorridorDirection {get {return corridorDirection;} set {corridorDirection = value;}}
    #endregion

    public int EndingPositionX {
        get {
            if (corridorDirection == LevelDirection.NORTH || corridorDirection == LevelDirection.SOUTH) {
                return startingXPos;
            }
            else {
                if (corridorDirection == LevelDirection.EAST) {
                    return startingXPos + corridorLength - 1;
                }
                else {
                    return startingXPos - corridorLength + 1;
                }
            }
        }
    }

    public int EndingPositionY {
        get {
            if (corridorDirection == LevelDirection.EAST || corridorDirection == LevelDirection.WEST) {
                return startingYPos;
            }
            else {
                if (corridorDirection == LevelDirection.NORTH) {
                    return startingYPos + corridorLength - 1;
                }
                else {
                    return startingYPos - corridorLength + 1;
                }
            }
        }
    }

    public void InitializeCorridor(LevelRoom room, Level lvl, bool isFirstCorridor) {
        corridorDirection = (LevelDirection)Random.Range(0, System.Enum.GetValues(typeof(LevelDirection)).Length);
        //Gets the direction that would head back to previous room. Attempts to avoid going in that direction.
        LevelDirection backDirection = (LevelDirection)(((int)room.EntranceDirection + 2) % 4);
        if (!isFirstCorridor && corridorDirection == backDirection) {
            //Rotates Direction 90 degrees to avoid going back to previous room
            corridorDirection = (LevelDirection)(((int)corridorDirection + 1) % 4);
        }
        //Set size to something smaller than the room and length to w/e
        //Set rotation to direction of corridor
        //Set position to end of room
        corridorLength = Random.Range(lvl.Data.CorridorLengthMin, lvl.Data.CorridorLengthMax);
        maxCorridorLength = lvl.Data.CorridorLengthMax;
        switch (corridorDirection) {
            case LevelDirection.NORTH:
                startingXPos = Random.Range(room.XPos, room.XPos + room.RoomWidth - 1);
                startingYPos = room.YPos + room.RoomLength;
                maxCorridorLength = lvl.MapLength - startingYPos - lvl.Data.RoomLengthMin;
                break;
            case LevelDirection.SOUTH:
                startingXPos = Random.Range(room.XPos, room.XPos + room.RoomWidth);
                startingYPos = room.YPos;
                maxCorridorLength = startingYPos - lvl.Data.RoomLengthMin;
                break;
            case LevelDirection.EAST:
                startingXPos = room.XPos + room.RoomWidth;
                startingYPos = Random.Range(room.YPos, room.YPos + room.RoomLength - 1);
                maxCorridorLength = lvl.MapWidth - startingXPos - lvl.Data.RoomWidthMin;
                break;
            case LevelDirection.WEST:
                startingXPos = room.XPos;
                startingYPos = Random.Range(room.YPos, room.YPos + room.RoomLength);
                maxCorridorLength = startingXPos - lvl.Data.RoomWidthMin;
                break;
        }
        corridorLength = Mathf.Clamp(corridorLength, 1, maxCorridorLength);
    }
}