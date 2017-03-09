using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// GameManager code inspired by Unity 2D Rougelike tutorial
// https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager?playlist=17150
public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public float levelStartDelay = 0f; // Time to wait before starting level, in seconds.

    private List<DispositionObject> dispositionObjects;
    private GameObject[] footprints;
    private Text levelText; // Text to display current level number.
    private Image levelImage; // Image to block out level as levels are being set up, background for levelText.
    private GameObject eyeOpening; // Image for eye opening

    public bool doingSetup = true; // Boolean to check if we're setting up, prevent Player from moving during setup.

    public Disposition playerDisposition;

    [HideInInspector]
    public Story Story;

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
        Story = GetComponent<Story>();

        // Call the InitGame function to initialize the first level 
        // InitGame();
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
    }

    // Idea from Addyarb 
    // http://answers.unity3d.com/answers/1236899/view.html
    void OnEnable()
    {
        // Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        // Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
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
    public void GameOver()
    {
        // Display game over message
        levelText.text = "You have died.";

        // Enable black background image gameObject.
        levelImage.enabled = true;

        // Enable the game over message
        levelText.enabled = true;

        // Disable this GameManager.
        enabled = false;
    }

    public void ToggleEnemyDispositions(bool enable)
    {
        foreach (DispositionObject e in dispositionObjects)
        {
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
        for (int i = 0; i < footprints.Length; i++)
        {
            footprints[i].GetComponent<SpriteRenderer>().enabled = state;
        }
    }

}
