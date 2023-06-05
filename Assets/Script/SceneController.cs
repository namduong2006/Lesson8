using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Scenes/Lesson8/lesson8");
    }
    public void LoadGaraScene()
    {
        SceneManager.LoadScene("Scenes/Lesson8/Garage");
    }
    public void LoadHomeScene()
    {
        SceneManager.LoadScene("Scenes/Lesson8/Home");
    }     
    //public void LoadPauseScene()
    //{        
    //    SceneManager.LoadScene("Scenes/Lesson8/Pause");
        
    //}
    public void Resume()
    {
        SceneManager.UnloadSceneAsync("Scenes/Lesson8/Pause");
        
    }
}
