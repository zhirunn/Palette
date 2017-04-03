using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ApplicationManager : MonoBehaviour {

    public PanelManager menuManager;
    public EventSystem menuEventSystem;
	
    public void StartGame()
    {
        menuManager.CloseMenu();
        menuEventSystem.enabled = false;
        SceneManager.LoadScene("Level1");
    }

    public void Continue()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            GameObject menu = GameManager.Instance.menu;
            if (menu != null)
            {
                menuManager.CloseMenu();
            }
        }
    }

	public void Quit () 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}
