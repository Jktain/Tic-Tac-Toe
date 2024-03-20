using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
            Screen.SetResolution(680, 720, false);
        if (Input.GetKey(KeyCode.Space))
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    //public void ResizeWindow()
    //{
    //    Screen.SetResolution(Screen.currentResolution.width - 300, Screen.currentResolution.height - 200, false);
    //}

    public void Quit()
    {
        Application.Quit();
    }
}
