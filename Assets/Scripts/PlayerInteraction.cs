using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Image;

public class PlayerInteraction : MonoBehaviour
{
    private LayerMask Mask;
    GameManager manager;

    private void Start()
    {
         Mask = LayerMask.GetMask("Interactable");
    }

    void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward*5f, Color.green);
        

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click Air");
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 5f, Mask))
            {

                Debug.Log("Click on things");
                IInteractable comp = hit.collider.gameObject.GetComponent<IInteractable>();
                comp.Interact();

            }
                
                //Vector3 origin, Vector3 direction, out RaycastHit hitinfo, float maxDistance, int layerMask))

        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            GameManager.instance.OpenInventoryPanel();
        }
        if (Input.GetKeyUp(KeyCode.C))
        { GameManager.instance.CloseInventoryPanel(); }
    }
}
