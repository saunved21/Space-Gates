using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreboard : MonoBehaviour
{
    int score;
    TMP_Text deathscore;

    void Start()
    {
        deathscore = GetComponent<TMP_Text>();
        deathscore.text = "Deaths";
    }

    void Awake()
    {
         int s = FindObjectsOfType<scoreboard>().Length;
        // Make sure there's only one instance of this object in the scene
        if (s > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
        deathscore.text = score.ToString();
    }
}
