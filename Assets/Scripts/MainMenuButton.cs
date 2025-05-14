using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void OnPressMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
