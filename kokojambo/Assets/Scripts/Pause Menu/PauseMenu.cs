using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseM;
    public void Pause()
    {
        PauseM.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continue()
    {
        PauseM.SetActive(false);
        Time.timeScale = 0;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Exit()
    {
        Application.Quit(); 
    }
}
