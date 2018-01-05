using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager instance = null;
    [SerializeField] private GameState currentState = GameState.MENU;
    private Player playerUnit = null;
    private List<Unit> allUnits = new List<Unit>();

    public static GameManager Instance { get { return instance; } set { instance = value; } }
    public GameState CurrentState { get { return currentState; } set { currentState = value; } }
    public Player PlayerUnit { get { return playerUnit; } set { playerUnit = value; } }
    public List<Unit> AllUnits { get { return allUnits; } set { allUnits = value; } }

    private void Awake() {
        Init();
    }

    private void Init() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }
}
