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
    private float timer;

    // TEMP
    private int bonusScore = 0;
    private float bonusModifier = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // TEMP
    // calculates score based on factors
    public void calculateScore()
    {
        int internalScore = 0;
        calculateBonus();
        currentScore = internalScore;
    }
    
    // TEMP
    // adds bonus score to current score
    public void calculateBonus()
    {
        currentScore += (int)((float)bonusScore * bonusModifier);
        // reset the bonuses
        bonusModifier = 1;
        bonusScore = 0;
    }

    // TEMP
    // add to bonus score
    public void increaseBonus(int i)
    {
        bonusScore += i;
    }

    // TEMP
    // add to the bonus modifier
    public void increaseModifier(float i)
    {
        bonusModifier += i;
    }

    // TEMP
    // increment score when called
    public void increaseScore(int i)
    {
        currentScore += i;
    }

    // TEMP
    // steps needed to be taken after a successful or bad run
    public void finishRun(bool success)
    {
        if (success)
        {
            stopTimer();
            calculateScore();
            saveScore(currentScore);
        }
        else
        {
            // Do we still want to save score even if they don't finish?
            // Is there even anything different we want to do?
        }
    }

    // TEMP 
    // steps taken when starting a fresh run
    public void startRun()
    {
        resetScore();
        initiateTimer();
    }

    // retrieves all scores saved in PlayerPrefs
    public int[] retrieveScores()
    {
        int[] arrScore = PlayerPrefsX.GetIntArray("scores");
        return arrScore;
    }

    // takes note of the time when the run starts
    private void initiateTimer()
    {
        timer = Time.time;
    }

    // changes timer to the amount of time elapsed when run finishes
    private void stopTimer()
    {
        timer = Time.time - timer;
    }

    // sets the current score back to zero
    // ensure last score was saved
    private void resetScore()
    {
        currentScore = 0;
    }

    // retrieves the highest score saved
    private int highScore()
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
    private void saveScore(int score)
    {
        int[] curScores = retrieveScores();
        int[] arrScore = new int[curScores.Length + 1]; // Concern: Max number of scores

        curScores.CopyTo(arrScore, 1);
        arrScore[0] = score;

        PlayerPrefsX.SetIntArray("scores", arrScore);
    }
}
