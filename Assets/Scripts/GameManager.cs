using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    public static GameManager instance;

    private void Awake()    
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Random.Range(0,TargetList.Count);
    }

    public InventoryPanel inventoryPanel;

    public void OpenInventoryPanel()
    {
        inventoryPanel.OnOpen();
        inventoryPanel.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public void CloseInventoryPanel()
    {
        inventoryPanel.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
    }


    public float timeCounter = 30f;
    public ItemData targetItem;
    public Image targetItemImage;
    public int targetAmount;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI targetAmountText;
    public List<ScriptableObject> TargetList = new List<ScriptableObject>();

    private void Update()
    {
        if (timeCounter > 0)
        {
            timeCounter -= Time.deltaTime;
            timerText.text = timeCounter.ToString();
            targetAmountText.text = (targetAmount - InventoryManager.instance.GetItemAmount(targetItem)).ToString();
                if (InventoryManager.instance.GetItemAmount(targetItem) >= targetAmount)
                {
                Debug.Log("You Win");
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene(2);
                }
        }
        
        else if (timeCounter <= 0)
        {
            Debug.Log("You Lose");
            SceneManager.LoadScene(0);
        }
    }

}
