using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
