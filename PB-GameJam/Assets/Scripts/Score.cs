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

    #region Class Variables
    private float timer;
    private int timerPenalty;
    private float penaltyFactor;

    // TEMP
    private int currentScore = 0;
    private int bonusScore = 0;
    private float bonusModifier = 1;
    #endregion

    #region Unity Functions
    // Start is called before the first frame update
    void Start()
    {
        
    }
    #endregion

    #region Public Functions
    // calculates score based on factors
    public void finalizeScoreTime()
    {
        int internalScore = 0;
        float internalTime = 0.0f;
        calculateBonus();
        calculateTimePenalty();

        internalTime = timer;
        currentScore = internalScore;
    }

    // steps taken when starting a fresh run
    public void startRun()
    {
        resetScore();
        initiateTimer();
    }

    // steps needed to be taken after a successful or bad run
    public void finishRun(bool success)
    {
        if (success)
        {
            stopTimer();
            finalizeScoreTime();
            saveScoreTime(currentScore, timer);
        }
        else
        {
            // Do we still want to save score even if they don't finish?
            // Is there even anything different we want to do?
        }
    }

    // retrieves the highest score saved
    public int highScore()
    {
        int[] arrScore = retrieveScores();
        int high = 0;
        for (int i = 0; i < arrScore.Length; i++)
        {
            if (arrScore[i] > high)
            {
                high = arrScore[i];
            }
        }
        return high;
    }

    // retrieves the best time saved
    public float bestTime()
    {
        float[] arrTime = retrieveTimes();
        float best = float.MaxValue;
        for (int i = 0; i < arrTime.Length; i++)
        {
            if (arrTime[i] < best)
            {
                best = arrTime[i];
            }
        }
        return best;
    }

    // retrieves all scores saved in PlayerPrefs
    public int[] retrieveScores()
    {
        return PlayerPrefsX.GetIntArray("scores");
    }

    // retrieves all times saved in PlayerPrefs as ints
    public float[] retrieveTimes()
    {
        return PlayerPrefsX.GetFloatArray("times");
    }

    // adds to the timerPenalty counter
    public void incrementTimerPenalty()
    {
        timerPenalty += 1;
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

    #endregion

    #region Private Functions

    // saves scores into PlayerPrefs
    private void saveScoreTime(int score, float time)
    {
        int[] curScores = retrieveScores();
        int[] arrScore = new int[curScores.Length + 1]; // Concern: Max number of scores

        float[] curTimes = retrieveTimes();
        float[] arrTime = new float[curTimes.Length + 1];

        curScores.CopyTo(arrScore, 1);
        arrScore[0] = score;

        curTimes.CopyTo(arrTime, 1);
        arrTime[0] = time;

        PlayerPrefsX.SetIntArray("scores", arrScore);
        PlayerPrefsX.SetFloatArray("times", arrTime);
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

    // takes into account the number of penalties into the time saved
    private void calculateTimePenalty()
    {
        timer += timerPenalty * penaltyFactor;
    }

    // TEMP
    // adds bonus score to current score
    private void calculateBonus()
    {
        currentScore += (int)((float)bonusScore * bonusModifier);
        // reset the bonuses
        bonusModifier = 1;
        bonusScore = 0;
    }
    #endregion

}
