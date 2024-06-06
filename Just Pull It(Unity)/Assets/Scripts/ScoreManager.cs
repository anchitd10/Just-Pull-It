/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public static int scoreCount = 0;
    public static int hiscoreCount = 0;

    void Start()
    {
        StartCoroutine(IncreaseScoreCount());
        if (PlayerPrefs.HasKey("Hi-Score"))
        {
            hiscoreCount = PlayerPrefs.GetInt("Hi-Score");
        }
    }

    void Update()
    {

        if (scoreCount > hiscoreCount)
        {
            hiscoreCount = scoreCount;
            PlayerPrefs.SetInt("Hi-Score", hiscoreCount);
        }

        scoreText.text = "Score: " + scoreCount;  //.ToString();
        highScoreText.text = "Hi-Score: " + hiscoreCount;  //.ToString();
    }

    private IEnumerator IncreaseScoreCount()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            scoreCount++;
            Debug.Log("Score incremented: " + scoreCount);
        }
    }
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + scoreCount;
    }
}*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public static int scoreCount = 0;
    public static int hiscoreCount = 0;

        private float timer = 0f;
        private float scoreIncreaseInterval = 1f; // Interval in seconds

        void Start()
        {
            if (PlayerPrefs.HasKey("Hi-Score"))
            {
                hiscoreCount = PlayerPrefs.GetInt("Hi-Score");
            }
        }

        void Update()
        {
            timer += Time.deltaTime;

            while (timer >= scoreIncreaseInterval)
            {
                scoreCount++;
                timer -= scoreIncreaseInterval;

                if (scoreCount > hiscoreCount)
                {
                    hiscoreCount = scoreCount;
                    PlayerPrefs.SetInt("Hi-Score", hiscoreCount);
                }

                // Update UI
                scoreText.text = "Score:" + scoreCount;
                highScoreText.text = "Hi-Score:" + hiscoreCount;

                Debug.Log("Timer: " + timer);
                Debug.Log("Score: " + scoreCount);
                Debug.Log("Hi-Score: " + hiscoreCount);
        }
        }
    }
