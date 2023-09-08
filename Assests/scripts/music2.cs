using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class music2 : MonoBehaviour
{
    void Start() 
    {
      //  mp.enabled=false;
       // Destroy(Object Music_Player);
        int numMusic = FindObjectsOfType<music2>().Length;
        int currentindexscene = SceneManager.GetActiveScene().buildIndex;
        int next = currentindexscene+1;
        Debug.Log("CURRENT "+currentindexscene);
        Debug.Log("NEXT "+next);

        if (numMusic > 1 || currentindexscene==2)
        {
            Destroy(gameObject);
        }
        // else 
        // {
        //     DontDestroyOnLoad(gameObject);
        // }
        else 
        {
            DontDestroyOnLoad(gameObject);
        }
        
    }
}


