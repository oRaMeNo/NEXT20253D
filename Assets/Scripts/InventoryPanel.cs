using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{

    public Image SelectedIcon;
    public TextMeshProUGUI DescriptionText;
    public Transform rightPanelTransform;
    public GameObject itemButtonPrefab;

    public void OnOpen()
    {
        for(int i = rightPanelTransform.childCount - 1; i >= 0; i--)
        {
            Destroy(rightPanelTransform.GetChild(i).gameObject);
        }


            for (int i = 0; i < InventoryManager.instance.inventoryList.Count; i++)
        {
            GameObject itemButtonOBJ = Instantiate(itemButtonPrefab, rightPanelTransform);
            ItemButton itemButtonComp = itemButtonOBJ.GetComponent<ItemButton>();
            itemButtonComp.data = InventoryManager.instance.inventoryList[i];
            itemButtonComp.icon.sprite = itemButtonComp.data.ItemSprite;
            Button button = itemButtonOBJ.GetComponent<Button>();
            button.onClick.AddListener(() =>
            {
                SelectedIcon.sprite = itemButtonComp.data.ItemSprite;
                DescriptionText.text = itemButtonComp.data.ItemDescription;

            });

        }
    }

}
