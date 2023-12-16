using UnityEngine;
using System.Collections.Generic;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 2.0f;
    public PanelController panelController; // Referencia al PanelController

    private List<GameObject> clickableObjects = new List<GameObject>();

    void Start()
    {
        GameObject[] clickable = GameObject.FindGameObjectsWithTag("Clickable");
        clickableObjects.AddRange(clickable);
    }

    void Update()
    {
        foreach (GameObject clickableObj in clickableObjects)
        {
            float distance = Vector2.Distance(transform.position, clickableObj.transform.position);

            if (distance <= interactionDistance && Input.GetMouseButtonDown(0))
            {
                clickableObj.GetComponent<ObjectInteraction>().ChangeColor();
                panelController.CreateAndShowPanel(); // Usa PanelController para mostrar el panel
            }
        }
    }
}
