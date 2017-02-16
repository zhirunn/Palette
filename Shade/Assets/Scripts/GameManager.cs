using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// GameManager code inspired by Unity 2D Rougelike tutorial
// https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager?playlist=17150
public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public float levelStartDelay = 0f; // Time to wait before starting level, in seconds.

    private List<Enemy> enemies;
<<<<<<< HEAD
    private GameObject[] footprint;
    private Text levelText; // Text to display current level number.
    private GameObject levelImage; // Image to block out level as levels are being set up, background for levelText.
    private GameObject eyeOpening; // Image for eye opening
=======
    public Text levelText; // Text to display current level number.
    public GameObject levelImage; // Image to block out level as levels are being set up, background for levelText.
    private Image _levelImage;
>>>>>>> origin/master
    public bool doingSetup = true; // Boolean to check if we're setting up, prevent Player from moving during setup.

    public int playerDisposition = 50;

    // Use this for initialization
    void Awake()
    {
        // Check if instance already exists
        if (Instance == null)
        {
            // If not, set instance to this
            Instance = this;
        }
        // If instance already exists and it's not this:
        else if (Instance != this)
        {
            // Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        // Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        // Assign enemies to a new List of Enemy objects.
        enemies = new List<Enemy>();

        //Finds all objects with specified tag
        footprint = GameObject.FindGameObjectsWithTag("Footprint");

        // Call the InitGame function to initialize the first level 
        InitGame();
    }

    // Initializes the game for each level.
    void InitGame()
    {
        // While doingSetup is true the player can't move, prevent player from moving while title card is up.
        doingSetup = true;

<<<<<<< HEAD
        // Get a reference to our image LevelImage by finding it by name.
        levelImage = GameObject.Find("LevelImage");
    
        // Get a reference to our text LevelText's text component by finding it by name and calling GetComponent.
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
=======
        // Get a reference to our image
        _levelImage = levelImage.GetComponent<Image>();
>>>>>>> origin/master

        // Set the text of levelText to the string "Day" and append the current level number.
        levelText.text = "Level Loading... ";

        // Set levelImage to active blocking player's view of the game board during setup.
        _levelImage.enabled = true;
        levelText.enabled = true;

        // Call the HideLevelImage function with a delay in seconds of levelStartDelay.
        Invoke("HideLevelImage", levelStartDelay);

        // Clear any Enemy objects in our List to prepare for next level.
        enemies.Clear();

        // Get reference for eye opening
        eyeOpening = GameObject.Find("EyeOpening");

        // Set eye opening as false to start
        eyeOpening.GetComponent<Image>().enabled = false;
    }

    // Hides black image used between levels
    void HideLevelImage()
    {
        levelText.enabled = false;
        _levelImage.enabled = false;

        // Set doingSetup to false allowing player to move again.
        doingSetup = false;
    }

    // Update is called every frame.
    void Update()
    {
        if (doingSetup)
            return;
    }

    // Call this to add the passed in Enemy to the List of Enemy objects.
    public void AddEnemyToList(Enemy script)
    {
        // Add Enemy to List enemies.
        enemies.Add(script);
    }

    // GameOver is called when the player reaches 0 health points
    public void GameOver()
    {
        // Display game over message
        levelText.text = "You have died.";

        // Enable black background image gameObject.
        _levelImage.enabled = true;

        // Disable this GameManager.
        enabled = false;
    }

    public void ToggleEnemyDispositions(bool enable)
    {
        foreach(Enemy e in enemies)
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
        for (int i = 0; i < footprint.Length; i++)
        {
            footprint[i].GetComponent<SpriteRenderer>().enabled = state;
        }
    }

}
