
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 60f;
    public Text timerText;
    public Text resultText;

    private bool gameEnded = false;

    void Start()
    {
        resultText.gameObject.SetActive(false);
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (timeRemaining > 0 && !gameEnded)
        {
            timerText.text = "Tempo: " +
                Mathf.CeilToInt(timeRemaining);

            yield return new WaitForSeconds(1f);
            timeRemaining--;
        }

        if (!gameEnded)
        {
            timeRemaining = 0;
            timerText.text = "Tempo: 0";
            EndGame(false);
        }
    }

    public void EndGame(bool won)
    {
        if (gameEnded)
            return;

        gameEnded = true;

        resultText.gameObject.SetActive(true);

        if (won)
        {
            resultText.text = "YAY CONSEGUISTES!";
        }
        else
        {
            resultText.text = "AWWW 😢";
        }

        Time.timeScale = 0f;
    }
}