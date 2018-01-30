using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public enum Screens{
        NONE,
        MAIN_MENU,
        OPTIONS,
        SOUND,
        KEY_BINDING,
        WORLD_MAP,
        TOWN,
        STORE,
        GAME
    }

    private Dictionary<Screens, string> requiredScreens = new Dictionary<Screens, string>() {
        {Screens.MAIN_MENU, "Screens/Screen_MainMenu"},
        {Screens.OPTIONS, "Screens/Screen_OptionsMenu"},
        {Screens.SOUND, "Screens/Screen_SoundMenu"},
        {Screens.KEY_BINDING, "Screens/Screen_KeyBindingsMenu"},
        //{Screens.WORLD_MAP, "Screens/Screen_WorldMap"},
        {Screens.TOWN, "Screens/Screen_Town"},
        //{Screens.STORE, "Screens/Screen_Store"},
        //{Screens.GAME, "Screens/Screen_Game"},
    };

    private static UIManager instance = null;
    private const string rootCanvasPath = "Screens/RootCanvas";
    private Dictionary<Screens, UIScreen> availableScreens = new Dictionary<Screens, UIScreen>();
    private bool isInitialized = false;

    private Stack<Screens> screenStack;
    private GameObject canvasRootObject;
    [SerializeField] private Screens initialScreen = Screens.NONE;
    private Screens currentScreen = Screens.NONE;

    public static UIManager Instance { get { return instance; } set { instance = value; } }

    private void Awake() {
        Init();
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Init() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(this);
        }
        InitializeUI();
    }

    public void InitializeUI() {
        if (isInitialized) {
            Debug.LogError("Error: Cannot Initialize. UI already initialized.");
        }

        canvasRootObject = Instantiate(Resources.Load(rootCanvasPath) as GameObject);
        canvasRootObject.name = "RootCanvas";

        if (canvasRootObject == null) {
            Debug.LogError("Error: Could not find RootCanvas");
            return;
        }

        foreach (KeyValuePair<Screens, string> entry in requiredScreens) {
            InitializeScreen(entry.Key, entry.Value);
        }
        OpenScreen(initialScreen);

        isInitialized = true;
        }

    private void InitializeScreen(Screens screenType, string prefabLocation) {
        GameObject instantiatedScreen = Instantiate(Resources.Load<GameObject>(prefabLocation), canvasRootObject.transform, false);
        UIScreen screenPanel = instantiatedScreen.GetComponent<UIScreen>();
        availableScreens.Add(screenType, screenPanel);
    }

    public void OpenScreen(Screens screen, bool clearHistory = false) {
        if (screen == currentScreen) {
            Debug.LogWarning("Attempted to open the same screen, aborting.");
            return;
        }

        if (screenStack == null) {
            screenStack = new Stack<Screens>();
        }

        UIScreen panel = null;
        availableScreens.TryGetValue(screen, out panel);

        if (panel != null) {
            if (screenStack.Count > 0) {
                availableScreens[screenStack.Peek()].OnUIElementHidden += () => {
                    //Needs to wait for animation to finish [x]
                    availableScreens[screen].Show();

                    if (clearHistory) {
                        screenStack.Clear();
                    }

                    screenStack.Push(screen);
                    currentScreen = screen;
                };
                availableScreens[screenStack.Peek()].Hide();
            }
            else // we don't need to wait
            {
                availableScreens[screen].Show();

                if (clearHistory) {
                    screenStack.Clear();
                }

                screenStack.Push(screen);
                currentScreen = screen;
            }
        }
        else {
            Debug.LogError("'" + screen.ToString() + "' is not a valid screen.");
        }
    }

    public bool CanGoBack() {
        return (screenStack != null && screenStack.Count > 1);
    }

    public void GoBack() {
        if (!CanGoBack()) {
            Debug.LogError("screenStack not initialized or empty, cannot go back.");
            return;
        }

        availableScreens[screenStack.Peek()].OnUIElementHidden += () => {
            //Need to wait for animation to finish [x]
            availableScreens[screenStack.Peek()].Show();
            currentScreen = screenStack.Peek();
        };
        availableScreens[screenStack.Pop()].Hide();
    }

    public void PopToRoot() {
        if (!CanGoBack()) {
            Debug.LogError("screenStack not initialized or empty, cannot go to root.");
            return;
        }

        availableScreens[screenStack.Peek()].OnUIElementHidden += () => {
            //Need to wait for animation to finish [x]
            while (screenStack.Count > 1) {
                screenStack.Pop();
            }

            availableScreens[screenStack.Peek()].Show();
            currentScreen = screenStack.Peek();
        };
        availableScreens[screenStack.Pop()].Hide();
    }
}
