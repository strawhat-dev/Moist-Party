using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MashHappy : MinigameManager
{
    public Text ScoreText1;  // Text to show the score for player 1
    public Text ScoreText2;
    public Text ScoreText3;
    public Text ScoreText4;
    public Text CenterText;  // text in the center of screen for reference

    [SerializeField]
    private string player1Button;  // Button for player 1 to mash
    [SerializeField]
    private string player2Button;
    [SerializeField]
    private string player3Button;
    [SerializeField]
    private string player4Button;

    private int player1Score = 0;  // How many times player 1 has mashed
    private int player2Score = 0;  // How many times player 1 has mashed
    private int player3Score = 0;  // How many times player 1 has mashed
    private int player4Score = 0;  // How many times player 1 has mashed


    [SerializeField]
    private GameObject pointText;

    [SerializeField]
    private GameObject player1;  // Used to get the players position
    [SerializeField]
    private GameObject player2;
    [SerializeField]
    private GameObject player3;
    [SerializeField]
    private GameObject player4;



    public override void Update()
    {
        if (phase == "Playing")
        {
            if (Input.GetKeyDown(player1Button) && (Players.Length >= 1))
            {
                player1Score += 1;

                // Spawn point effect
                GameObject pointEffect = Instantiate(pointText, player1.gameObject.transform.position + new Vector3(0, 1, 1.73f), Quaternion.Euler(0, 0, 0));
                Text textEdit = pointEffect.GetComponent<PointEffect>().pointText;
                textEdit.color = Color.green;
                textEdit.text = "$";

                // Punch animation
                player1.GetComponent<Animator>().SetTrigger("Punch");
            }

            if (Input.GetKeyDown(player2Button) && (Players.Length >= 2))
            {
                player2Score += 1;

                // Spawn point effect
                GameObject pointEffect = Instantiate(pointText, player2.gameObject.transform.position + new Vector3(0, 1, 1.73f), Quaternion.Euler(0, 0, 0));
                Text textEdit = pointEffect.GetComponent<PointEffect>().pointText;
                textEdit.color = Color.green;
                textEdit.text = "$";

                // Punch animation
                player2.GetComponent<Animator>().SetTrigger("Punch");
            }

            if (Input.GetKeyDown(player3Button) && (Players.Length >= 3))
            {
                player3Score += 1;

                // Spawn point effect
                GameObject pointEffect = Instantiate(pointText, player3.gameObject.transform.position + new Vector3(0, 1, 1.73f), Quaternion.Euler(0, 0, 0));
                Text textEdit = pointEffect.GetComponent<PointEffect>().pointText;
                textEdit.color = Color.green;
                textEdit.text = "$";

                // Punch animation
                player3.GetComponent<Animator>().SetTrigger("Punch");
            }

            if (Input.GetKeyDown(player4Button) && (Players.Length >= 4))
            {
                player4Score += 1;

                // Spawn point effect
                GameObject pointEffect = Instantiate(pointText, player4.gameObject.transform.position + new Vector3(0, 1, 1.73f), Quaternion.Euler(0, 0, 0));
                Text textEdit = pointEffect.GetComponent<PointEffect>().pointText;
                textEdit.color = Color.green;
                textEdit.text = "$";

                // Punch animation
                player4.GetComponent<Animator>().SetTrigger("Punch");
            }
        }
    }



    public override IEnumerator GameLoop()
    {
        // Start off by running the 'GameStart'
        yield return StartCoroutine(GameStarting());

        // Once the 'GameStart' coroutine is finished, run the 'GamePlaying' coroutine but don't return until it's finished.
        yield return StartCoroutine(GamePlaying());

        // Once execution has returned here, run the 'GameEnd' coroutine, again don't return until it's finished.
        yield return StartCoroutine(GameEnding());

        yield return StartCoroutine(ShowScores());

        yield return StartCoroutine(ShowResults());

        yield return StartCoroutine(ReturnToBoard());
    }



    IEnumerator ShowScores()
    {
        // Adjust text positions to only show texts for the number of players then center them

        if (Players.Length == 1)
        {
            ScoreText1.transform.position = CenterText.transform.position;
            ScoreText1.text = "Player 1:\n" + player1Score.ToString();
        }

        else if (Players.Length == 2)
        {
            ScoreText1.transform.position = CenterText.transform.position - new Vector3(125, 0, 0);
            ScoreText1.text = "Player 1:\n" + player1Score.ToString();

            ScoreText2.transform.position = CenterText.transform.position + new Vector3(125, 0, 0);
            ScoreText2.text = "Player 2:\n" + player2Score.ToString();
        }

        else if (Players.Length == 3)
        {
            ScoreText1.transform.position = CenterText.transform.position - new Vector3(250, 0, 0);
            ScoreText1.text = "Player 1:\n" + player1Score.ToString();

            ScoreText2.transform.position = CenterText.transform.position;
            ScoreText2.text = "Player 2:\n" + player2Score.ToString();

            ScoreText3.transform.position = CenterText.transform.position + new Vector3(250, 0, 0);
            ScoreText3.text = "Player 3:\n" + player3Score.ToString();
        }

        else
        {
            ScoreText1.text = "Player 1:\n" + player1Score.ToString();
            ScoreText2.text = "Player 2:\n" + player2Score.ToString();
            ScoreText3.text = "Player 3:\n" + player3Score.ToString();
            ScoreText4.text = "Player 4:\n" + player4Score.ToString();
        }
        

        yield return new WaitForSeconds(3);
    }



    public override IEnumerator ShowResults()
    {
        ScoreText1.text = "";
        ScoreText2.text = "";
        ScoreText3.text = "";
        ScoreText4.text = "";

        int highest = Mathf.Max(player1Score, player2Score, player3Score, player4Score);

        bool tie = false;
        int winner = 0;

        // Find the player number of the winner
        if (player1Score == highest)
        {
            // If no winner has been chosen, set them as the winner
            if (winner == 0)
            {
                winner = 1;
            }

            else
            {
                tie = true;
            }
        }

        if (player2Score == highest)
        {
            // If no winner has been chosen, set them as the winner
            if (winner == 0)
            {
                winner = 2;
            }
            // Otherwise tie
            else
            {
                tie = true;
            }
        }

        if (player3Score == highest)
        {
            // If no winner has been chosen, set them as the winner
            if (winner == 0)
            {
                winner = 3;
            }

            else
            {
                tie = true;
            }
        }

        if (player4Score == highest)
        {
            // If no winner has been chosen, set them as the winner
            if (winner == 0)
            {
                winner = 4;
            }

            else
            {
                tie = true;
            }
        }

        if (tie)
        {
            UIMainText.text = "TIE";
        }
        else
        {
            UIMainText.text = "Player " + winner.ToString() + " Wins!";

            // Increase the winner's score
            scoreTracker.GetComponent<ScoreTracker>().IncreaseScore(winner);
        }

        yield return resultsWait;
    }
}
