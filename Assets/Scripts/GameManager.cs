using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        else
        {
            Instance = this;
        }
    }


    public void GameOver()
    {
        StartCoroutine(GameOverDelay());
    }

    public void GameWin()
    {
        StartCoroutine(GameWinDelay());
    }

    private IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Gameplay");
    }


    private IEnumerator GameWinDelay()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Win");
    }

}
