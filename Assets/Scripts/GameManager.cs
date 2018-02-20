using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    // Use this for initialization

    public SManager sceneManager;                       // Reference to SManager for each scene
    public static bool mousepressed = false;
    [HideInInspector]
    public enum Scenes                                      // Place all scene names here in order
    {
        Init,
        Scene00,
        Scene01,
        Scene02,
        Scene03,
		Scene04,
		Scene05,
		Scene06,
		Scene08,
		Scene09,
		Scene10,
		Scene11,
		Scene12,
		Scene13,
		Scene14,
		Scene15,
		Scene16,
		Scene17,
		Scene18,
		Scene19,
		Scene20,
		Scene21,
		Scene23,
		Scene24,
        END
    }
    public Scenes currentScene;
    public static GameManager Instance
    {
        get { return GameManager.instance; }
    }
    // access to the singleton
    private static GameManager instance;
    // this is called after Awake() OR after the script is recompiled (Recompile > Disable > Enable)
    private void Init()
    {
        // Assign our current scene on one-time init so we can support starting game from any scene during testing
        currentScene = (Scenes)Enum.Parse(typeof(Scenes), SceneManager.GetActiveScene().name);
        Debug.Log("rere scene" + currentScene);
    }

    protected virtual void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (instance == null)
        {
            Debug.Log("enable");
            instance = this;

            Init();
        }
        else if (instance != this)
        {
            Debug.LogWarning("GAME MANAGER: WARNING - THERE IS ALREADY AN INSTANCE OF GAME MANAGER RUNNING - DESTROYING THIS ONE.");
            Destroy(this.gameObject);
            return;
        }
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Called each time a new scene is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("LEVEL WAS LOADED: " + SceneManager.GetActiveScene().name);
        //AndroidBroadcastIntentHandler.BroadcastJSONData("scene", SceneManager.GetActiveScene().name);
        LoadSceneManager();
    }

    private void LoadSceneManager()
    {
        // Grab the current SManager GameObject (if it exists)
        GameObject sceneManagerGO = GameObject.Find("SceneManager");


        if (sceneManagerGO != null)
        {
            sceneManager = sceneManagerGO.GetComponent<SManager>();

            if (sceneManager != null)
            {
                sceneManager.Init(this);

            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }


    public void LoadPreviousScene()
    {
        if (currentScene > Scenes.Init + 1)
        {
            currentScene--;
            SceneManager.LoadScene(currentScene.ToString());
        }
    }
    public void LoadNextScene()
    {
        if (currentScene < Scenes.END - 1)
        {
            currentScene++;
            TinkerText.nooftaps = 0;
            SceneManager.LoadScene(currentScene.ToString());
            Debug.Log(currentScene);
        }
    }


}
