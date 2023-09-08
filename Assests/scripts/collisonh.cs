using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class collisonh : MonoBehaviour
{
     [SerializeField] float delay = 1f; 
     [SerializeField] AudioClip death;
     [SerializeField] AudioClip success;

    [SerializeField] ParticleSystem crashp; 
    [SerializeField] ParticleSystem successp;

    [SerializeField] int deathpts=1;
    scoreboard SB; 
    AudioSource audioSource; //cache
    TMP_Text deathscore;



    bool transitioning=false;
    bool collisionDisabled=false;

    void Start() 
    {
        audioSource=GetComponent<AudioSource>();
        SB = FindObjectOfType<scoreboard>();   //connecting
    }

    void Update() 
    {
        CHEAT();
    }

    void CHEAT()
    {
         if (Input.GetKeyDown(KeyCode.L))
        {
            NL();
            Debug.Log("Cheats enabled");
        } 
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;  //crash proof
            Debug.Log("Cheats enabled");
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if (transitioning || collisionDisabled) { return; }

            switch (other.gameObject.tag)
            {
                case "friendly":
                Debug.Log("start");
                break;

                case "Finish":
                Debug.Log("gg");
                SucessSeq();
                break;

                default:
                Debug.Log("try gain");
                crash();
                break;
            }
    }

    void SucessSeq()
    {
        transitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successp.Play();
        GetComponent<movement>().enabled=false;
        Invoke("NL",delay);

    }

    void crash()
    {
        transitioning=true;
        audioSource.Stop();
        audioSource.PlayOneShot(death);
        crashp.Play();
        GetComponent<movement>().enabled=false;
        // SB.increaseScore(deathpts);
        Invoke("Retry",delay);
       
    }

    void Retry()
    {
        int currentindexscene = SceneManager.GetActiveScene().buildIndex;
        //int next = currentindexscene+1;
        SceneManager.LoadScene(currentindexscene);
        // Debug.Log(currentindexscene);
        // Debug.Log(next);
        // Debug.Log("HI");
      //   SB.increaseScore(deathpts);
//DontDestroyOnLoad(gameObject);


    }

    void NL()
    {
        int currentindexscene = SceneManager.GetActiveScene().buildIndex;
        int next = currentindexscene+1;
        if( next == SceneManager.sceneCountInBuildSettings)
        {
            next=0;
            // AudioSource source = new AudioSource();
        }
        SceneManager.LoadScene(next);
        Destroy(gameObject);
    }
}

