using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private void OnMouseUp()
    {
        SceneManager.LoadScene(1);
    }
}
