using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    #region Singleton
    public static Score Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // ensures that only one Instance can exist
        }
    }
    #endregion

    private int currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // TEMP
    // calculates score based on factors
    public void calculateScore()
    {
        int internalScore = 0;
        currentScore = internalScore;
    }

    // TEMP
    // increment score when called
    public void increaseScore(int i)
    {
        currentScore += i;
    }

    // sets the current score back to zero
    // ensure last score was saved
    public void resetScore()
    {
        currentScore = 0;
    }

    // retrieves all scores saved in PlayerPrefs
    public int[] retrieveScores()
    {
        int[] arrScore = PlayerPrefsX.GetIntArray("scores");
        return arrScore;
    }

    // retrieves the highest score saved
    public int highScore()
    {
        int[] arrScore = retrieveScores();
        int high = 0;
        for( int i = 0; i < arrScore.Length; i++)
        {
            if ( arrScore[i] > high )
            {
                high = arrScore[i];
            }
        }
        return high;
    }

    // saves scores into PlayerPrefs
    public void saveScore(int score)
    {
        int[] curScores = retrieveScores();
        int[] arrScore = new int[curScores.Length + 1]; // Concern: Max number of scores

        curScores.CopyTo(arrScore, 1);
        arrScore[0] = score;

        PlayerPrefsX.SetIntArray("scores", arrScore);
    }
}
