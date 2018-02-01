using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    private Dictionary<ScreenType, string> requiredScreens = new Dictionary<ScreenType, string>() {
        {ScreenType.MAIN_MENU, "Screens/Screen_MainMenu"},
        {ScreenType.OPTIONS, "Screens/Screen_OptionsMenu"},
        {ScreenType.SOUND, "Screens/Screen_SoundMenu"},
        {ScreenType.KEY_BINDING, "Screens/Screen_KeyBindingsMenu"},
        //{ScreenTypes.WORLD_MAP, "Screens/Screen_WorldMap"},
        {ScreenType.TOWN, "Screens/Screen_Town"},
        //{ScreenTypes.STORE, "Screens/Screen_Store"},
        //{ScreenTypes.GAME, "Screens/Screen_Game"},
    };

    private static UIManager instance = null;
    private const string rootCanvasPath = "Screens/RootCanvas";
    private GameObject canvasRootObject;
    private bool isInitialized = false;
    private Dictionary<ScreenType, UIScreen> availableScreens = new Dictionary<ScreenType, UIScreen>();
    private Stack<ScreenType> screenStack;
    [SerializeField] private ScreenType initialScreen = ScreenType.NONE;
    private ScreenType currentScreen = ScreenType.NONE;

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

        foreach (KeyValuePair<ScreenType, string> entry in requiredScreens) {
            InitializeScreen(entry.Key, entry.Value);
        }
        OpenScreen(initialScreen);
        isInitialized = true;
        }

    private void InitializeScreen(ScreenType screenType, string prefabLocation) {
        GameObject instantiatedScreen = Instantiate(Resources.Load<GameObject>(prefabLocation), canvasRootObject.transform, false);
        UIScreen screenPanel = instantiatedScreen.GetComponent<UIScreen>();
        availableScreens.Add(screenType, screenPanel);
    }

    public void OpenScreen(ScreenType screen, bool clearStackHistory = false) {
        if (screen == currentScreen) {
            Debug.LogWarning("Attempted to open the same screen, aborting.");
            return;
        }

        if (screenStack == null) {
            screenStack = new Stack<ScreenType>();
        }

        UIScreen tmpScreen = null;
        availableScreens.TryGetValue(screen, out tmpScreen);

        if (tmpScreen != null) {
            //Possibly prevent the opening of a screen that exists in the stack already (Pop to main menu at root instead of opening a second)
            if (screenStack.Count > 0) {
                if (tmpScreen.IsPopup) {
                    foreach (UIScreen scrn in availableScreens.Values) {
                        scrn.Disable();
                    }
                    screenStack.Push(screen);
                    currentScreen = screen;
                    ShowNewScreen();
                }
                else {
                    availableScreens[screenStack.Peek()].OnUIElementHidden += ShowNewScreen;
                    availableScreens[screenStack.Peek()].Hide();
                    if (clearStackHistory) {
                        screenStack.Clear();
                    }
                    screenStack.Push(screen);
                    currentScreen = screen;
                }
            }
            else
            {
                screenStack.Push(screen);
                currentScreen = screen;
                ShowNewScreen();
            }
        }
        else {
            Debug.LogError("'" + screen.ToString() + "' is not a valid screen.");
        }
    }

    private void ShowNewScreen() {
        //Needs to wait for animation to finish [x]
        availableScreens[currentScreen].Show();

        //print("Stack:");
        //foreach (ScreenType scr in screenStack) {
        //    print(scr.ToString());
        //}
    }

    public bool CanGoBack() {
        return (screenStack != null && screenStack.Count > 1);
    }

    public void GoBack() {
        if (!CanGoBack()) {
            Debug.LogError("screenStack not initialized or empty, cannot go back.");
            return;
        }

        availableScreens[screenStack.Peek()].OnUIElementHidden += ShowNewScreen;
        availableScreens[screenStack.Pop()].Hide();
        currentScreen = screenStack.Peek();
        //print("Stack:");
        //foreach (ScreenType scr in screenStack) {
        //    print(scr.ToString());
        //}
    }

    public void PopToRoot() {
        if (!CanGoBack()) {
            Debug.LogError("screenStack not initialized or empty, cannot go to root.");
            return;
        }

        availableScreens[screenStack.Peek()].OnUIElementHidden += ShowNewScreen;
        availableScreens[screenStack.Pop()].Hide();
        while (screenStack.Count > 1) {
            screenStack.Pop();
        }
        currentScreen = screenStack.Peek();
        
    }
}
