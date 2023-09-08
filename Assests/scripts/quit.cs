using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

 
//  [SerializeField] int deathpts=1;
//  scoreboard SB; 


public class quit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("BYE");
            Application.Quit();
        }

         if(Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Retry");
            int currentindexscene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentindexscene);
        }
    }
}
