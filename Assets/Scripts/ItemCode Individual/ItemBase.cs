using UnityEngine;

public class ItemBase : MonoBehaviour, IInteractable
{

    public ItemData data;

    public void Interact()
    {
        Debug.Log("Interact item :" + data.name);
        InventoryManager.instance.AddItem(data);
        Destroy(gameObject);
    }
}
