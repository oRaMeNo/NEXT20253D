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
        AssignRandomItem();


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
    public int score;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI targetAmountText;
    public List<ItemData> TargetList = new List<ItemData>();

    private void Update()
    {
        if (targetItem != null && targetItemImage != null)
        { targetItemImage.sprite = targetItem.ItemSprite; }
        
        if (timeCounter > 0)
        {
            timeCounter -= Time.deltaTime;
            timerText.text = timeCounter.ToString();
            targetAmountText.text = (targetAmount - score).ToString();
                if (score >= targetAmount)
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

    public void AssignRandomItem()
    {
        if (targetItem != null && targetItemImage != null)
        { targetItemImage.sprite = targetItem.ItemSprite; }
        int randomIndex  = Random.Range(0, TargetList.Count);
        targetItem = TargetList[randomIndex];
    }

}
