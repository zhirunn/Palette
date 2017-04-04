using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TwineManager : MonoBehaviour
{
    TwineTextPlayer twineTextPlayer;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        twineTextPlayer = GetComponent<TwineTextPlayer>();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Level1")
        {
            //// hooks
            
            //GameObject storyGameObject = new GameObject();
            //Story story = storyGameObject.AddComponent<Story>();
            //story.AutoPlay = true;
            //story.StartPassage = "Start";

            //GameObject level1StoryHooks = new GameObject();
            //level1StoryHooks.AddComponent<Level1StoryHooks>();

            //story.AdditionalHooks = new GameObject[] { level1StoryHooks };

            //twineTextPlayer.Story = story;

            //GameManager.Instance.Story = GameManager.Instance.gameObject.AddComponent<Story>();
            //GameManager.Instance.Story.AutoPlay = true;
            //GameManager.Instance.Story.StartPassage = "Start"
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
