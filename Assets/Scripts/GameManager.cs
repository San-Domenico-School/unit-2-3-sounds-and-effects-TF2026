using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreboardText, timeRemainingText;
    [SerializeField] private GameObject toggleGroup, startButton, spawnManager;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private ParticleSystem dirtSplatter;
    public static bool gameOver = true;
    private static float score;
    private AudioSource AudioSource;
    private int timeRemaining = 60;
    private bool timedGame;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayUI();

        EndGame();
    }

    private void DisplayUI()
    {
        scoreboardText.text = "Score: " + Mathf.RoundToInt(score).ToString();

        if (timedGame)
        {
            if (timeRemaining > 0)
            {
                timeRemainingText.text = timeRemaining.ToString(); 
            }
            else
            {
                scoreboardText.text = "Game\nOver";
            }
        }
    }

    private void TimeCountdown()
    {
        if (timedGame)
        {
            timeRemaining--;

            if (timeRemaining <= 0f)
            {
                gameOver = true;
            }
        }
    }

    public void StartGame()
    { 
        AudioSource.Play();

        toggleGroup.SetActive(false);
        startButton.SetActive(false);

        gameOver = false;

        spawnManager.SetActive(true);

        playerAnimator.SetBool("BeginGame_b", true);
        playerAnimator.SetFloat("Speed_f", 1.0f);

        dirtSplatter.Play();

        if (timedGame)
        {
            timeRemainingText.gameObject.SetActive(true);

            InvokeRepeating("TimeCountdown", 1f, 1f);
        }
    }

    private void EndGame()
    {

        if (gameOver || timeRemaining == 0)
        {
            gameOver = true;

            playerAnimator.SetBool("BeginGame_b", false);

            playerAnimator.SetFloat("Speed_f", 0f);

            AudioSource.Stop();

            CancelInvoke();
        }
    }

    public void SetTimed(bool timed)
    {
        timedGame = timed;
    }

    public static void ChangeScore(int change)
    {
        score += change;
    }
}
