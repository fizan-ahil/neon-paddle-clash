using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
     private static bool hasLoadedMainMenu = false;
    void Start()
    {
        // If the Main Menu hasn't been loaded yet, load it
        if (!hasLoadedMainMenu)
        {
            // Ensure this block only runs once
            hasLoadedMainMenu = true;

            // Check if the current scene is not the main menu (scene 0)
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                // If it's not the main menu, load the main menu scene (scene 0)
                SceneManager.LoadScene(0);
            }
        }
    }
    public void movetoscene(int sceneid)
    {
        SceneManager.LoadScene(sceneid);//to load the scene that we want.
    }
    public void quit()
    {
        Application.Quit();//called whenever the user clicks quit button
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;  // Stops play mode in the Editor
        #endif
    }
}
