using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour
{
    public void exit()
    {
        Application.Quit();
    }

   
    public void htp(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
}
