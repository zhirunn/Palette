﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityTwine;

// GameManager code inspired by Unity 2D Rougelike tutorial
// https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager?playlist=17150
public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public float levelStartDelay = 0f; // Time to wait before starting level, in seconds.

    private List<DispositionObject> dispositionObjects;
    private GameObject[] footprints;
    private GameObject[] distractions;
    private Text levelText; // Text to display current level number.
    private Image levelImage; // Image to block out level as levels are being set up, background for levelText.
    private GameObject eyeOpening; // Image for eye opening

    public bool doingSetup = true; // Boolean to check if we're setting up, prevent Player from moving during setup.

    public Disposition playerDisposition;

    [HideInInspector]
    public TwineStory Story;

    [HideInInspector]
    public ReloadInfo reloadInfo = new ReloadInfo();

    public float gameSpeed = 1.0f;
    public GameObject menu;
    private Animator[] animators;

    public class ReloadInfo
    {
        public int disposition = 0;
        public Scene scene;
    }

    // Use this for initialization
    void Awake()
    {
        // Check if instance already exists
        if (Instance == null)
        {
            // Since the Instance is set to null on level loads we need to double check that a previous GameManager doesn't exist
            foreach (GameManager gm in GameObject.FindObjectsOfType<GameManager>())
            {
                if (!gm.gameObject.scene.Equals(SceneManager.GetActiveScene()))
                {
                    Destroy(gameObject);
                    return;
                }
            }

            // If not, set instance to this
            Instance = this;
        }
        // If instance already exists and it's not this:
        else if (Instance != this)
        {
            // Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
            return;
        }

        // Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        // Assign enemies to a new List of disposition objects.
        dispositionObjects = new List<DispositionObject>();

        playerDisposition = new Disposition(50);

        // Create the story
        Story = GetComponent<TwineStory>();

        // Call the InitGame function to initialize the first level 
        // InitGame();
    }

    void Start()
    {
        menu = GameObject.FindGameObjectWithTag("Menu");
    }

    // Initializes the game for each level.
    void InitGame()
    {
        // While doingSetup is true the player can't move, prevent player from moving while title card is up.
        doingSetup = true;

        //Get a reference to our image LevelImage by finding it by name.
        levelImage = GameObject.Find("LevelImage").GetComponent<Image>();

        //Get a reference to our text LevelText's text component by finding it by name and calling GetComponent.
        levelText = GameObject.Find("LevelText").GetComponent<Text>();

        // Set the text of levelText to the string "Day" and append the current level number.
        levelText.text = "Level Loading... ";

        // Set levelImage to active blocking player's view of the game board during setup.
        levelImage.enabled = true;
        levelText.enabled = true;

        // Call the HideLevelImage function with a delay in seconds of levelStartDelay.
        Invoke("HideLevelImage", levelStartDelay);

        // Clear any Enemy objects in our List to prepare for next level.
        dispositionObjects.Clear();

        // Get reference for eye opening
        eyeOpening = GameObject.Find("EyeOpening");

        // Set eye opening as false to start
        eyeOpening.GetComponent<Image>().enabled = false;

        //Finds all objects with specified tag
        footprints = GameObject.FindGameObjectsWithTag("Footprint");
        distractions = GameObject.FindGameObjectsWithTag("Distraction");
        
        animators = GameObject.FindObjectsOfType<Animator>();

        if(menu)
        {
            menu.GetComponentInChildren<ApplicationManager>().menuManager.CloseMenu();
        }
    }

    // Hides black image used between levels
    void HideLevelImage()
    {
        levelText.enabled = false;
        levelImage.enabled = false;

        // Set doingSetup to false allowing player to move again.
        doingSetup = false;
    }

    // Update is called every frame.
    void Update()
    {
        if (doingSetup)
            return;

        if (menu != null && menu.activeSelf == false && Input.GetKeyUp(KeyCode.Escape))
        {
            PauseGameAndShowMenu(true);
        }
    }

    // Idea from Addyarb 
    // http://answers.unity3d.com/answers/1236899/view.html
    void OnEnable()
    {
        // Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
        SceneManager.activeSceneChanged += RecordCurrentLevel;
    }

    void OnDisable()
    {
        // Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
        SceneManager.activeSceneChanged -= RecordCurrentLevel;
    }


    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        //Call InitGame to initialize our level.
        InitGame();
    }

    // Call this to add the passed in disposition object to the List of disposition objects.
    public void AddDispositionObjectToList(DispositionObject obj)
    {
        // Add Enemy to List enemies.
        dispositionObjects.Add(obj);
    }

    // GameOver is called when the player reaches 0 health points
    public IEnumerator GameOver()
    {
        // Display game over message
        levelText.text = "You have died.";

        // Enable black background image gameObject.
        levelImage.enabled = true;

        // Enable the game over message
        levelText.enabled = true;

        // Disable this GameManager.
        // enabled = false;

        PauseGame(true);

        yield return new WaitForSeconds(3);

        PauseGame(false);

        SceneManager.LoadScene(reloadInfo.scene.name);

        playerDisposition.disposition = reloadInfo.disposition;

        levelImage.enabled = false;
        levelText.enabled = false;
    }

    public void ToggleEnemyDispositions(bool enable)
    {
        foreach (DispositionObject e in dispositionObjects)
        {
            if(e.HideOnEyeMechanicEnabled)
                e.ToggleDisposition(!enable);
            else
                e.ToggleDisposition(enable);
        }
    }

    /*
    Swaps state of all footprint objects

    Param:
        - state (used to set state of a game object)
    */
    public void setState(bool state = false)
    {
        //Finds all objects with specified tag
        footprints = GameObject.FindGameObjectsWithTag("Footprint");
        distractions = GameObject.FindGameObjectsWithTag("Distraction");

        for (int i = 0; i < footprints.Length; i++)
        {
            footprints[i].GetComponent<SpriteRenderer>().enabled = state;
        }

        //Swap the state of the distractions
        foreach (GameObject candle in distractions)
        {
            if (state)
            {
                candle.GetComponent<SpriteRenderer>().enabled = false;
                candle.GetComponent<CircleCollider2D>().enabled = false;
                candle.GetComponent<DispositionObject>().enabled = false;
                candle.GetComponent<DispositionObject>().health = 0;
                //candle.GetComponent<ParticleSystem>().Stop();
            }
            else
            {
                candle.GetComponent<SpriteRenderer>().enabled = true;
                candle.GetComponent<CircleCollider2D>().enabled = true;
                candle.GetComponent<DispositionObject>().enabled = true;
                //candle.GetComponent<DispositionObject>().health = 40;
                candle.GetComponent<ParticleSystem>().Play();
            }
        }

    }

    public void RecordCurrentLevel(Scene oldScene, Scene newScene)
    {
        Debug.Log(string.Format("Recorded the current level ({0}) and disposition ({1})!", newScene.name, playerDisposition.disposition));
        reloadInfo.scene = newScene;
        reloadInfo.disposition = playerDisposition.disposition;
    }

    public void PauseGame(bool state = true)
    {
        if (state)
        {
            gameSpeed = 0.0f;
            pauseAnimations();
        }
        else
        {
            gameSpeed = 1.0f;
            pauseAnimations(false);
        }
    }

    public void PauseGameAndShowMenu(bool state = true)
    {
        if (state)
        {
            gameSpeed = 0.0f;
            menu.SetActive(true);
            menu.GetComponentInChildren<EventSystem>().enabled = true;
            pauseAnimations();
        }
        else
        {
            gameSpeed = 1.0f;
            menu.SetActive(false);
            menu.GetComponentInChildren<EventSystem>().enabled = false;
            pauseAnimations(false);
        }
    }

    public void pauseAnimations(bool pause = true)
    {
        foreach (Animator animator in animators)
        {
            if (animator.transform.root.gameObject.tag != "Menu")
            {
                animator.enabled = !pause;
            }
        }
    }

    public bool IsPaused
    {
        get
        {
            if (gameSpeed == 0.0f) return true;
            if (menu != null && menu.activeSelf) return true;
            return false;
        }
    }

    public bool IsMenuShowing
    {
        get
        {
            if (menu != null && menu.activeSelf) return true;
            return false;
        }
    }

    public bool IsGameOverShowing
    {
        get
        {
            return levelImage.enabled && levelText.enabled;
        }
    }
}
