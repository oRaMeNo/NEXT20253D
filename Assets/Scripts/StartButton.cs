using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{


   public void OnPressStartButton()
    {
        SceneManager.LoadScene("Gameplay");
    }


}
