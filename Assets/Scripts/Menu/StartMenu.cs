using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
