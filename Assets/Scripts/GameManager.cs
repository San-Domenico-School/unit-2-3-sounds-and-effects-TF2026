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
    public static bool gameOver = false;
    private static float score;
    private AudioSource AudioSource;
    private int timeRemaining = 60;
    private bool timedGame;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        DisplayUI();

        EndGame();
    }

    private void DisplayUI()
    {

    }

    private void TimeCountdown()
    {
        
    }

    public void StartGame()
    {
        AudioSource = GetComponent<AudioSource>();

        AudioSource.Play();

        toggleGroup.SetActive(false);

        playerAnimator.SetBool("BeginGame_b", true);

        dirtSplatter.Play();

        if (timedGame)
        {
            timeRemainingText.gameObject.SetActive(true);

            InvokeRepeating("TimeCountdown", 1f, 1f);
        }
    }

    private void EndGame()
    {

    }

    public void SetTimed(bool timed)
    {
        timedGame = timed;
    }

    public static void ChangeScore(int change)
    {

    }
}
