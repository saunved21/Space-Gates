using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class music : MonoBehaviour
{
    void Update() 
    {
        int numMusic = FindObjectsOfType<music>().Length;
        int currentindexscene = SceneManager.GetActiveScene().buildIndex;
        int next = currentindexscene+1;
        Debug.Log("CURRENT "+currentindexscene);
        Debug.Log("NEXT "+next);

        if (numMusic >  1 )    //no looping 
        {
            Destroy(gameObject);
        }
        // else if ( currentindexscene==1)   //not working 
        // {
        //     Destroy(gameObject);
        // }
        else
        {
            DontDestroyOnLoad(gameObject); // doesnt stop the audio if the scene is refreshed 
        }
    }
}



