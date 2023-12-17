using UnityEngine;
using System.Collections.Generic;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 2.0f;
    // public PanelController panelController; // Referencia al PanelController

    private List<GameObject> clickableObjects = new List<GameObject>();

    void Start()
    {
        GameObject[] clickable = GameObject.FindGameObjectsWithTag("Clickable");
        clickableObjects.AddRange(clickable);
        Debug.Log(clickableObjects.Count);
    }

    void Update()
    {
        foreach (GameObject clickableObj in clickableObjects)
        {
            float distance = Mathf.Abs(transform.position.x - clickableObj.transform.position.x);

            if (distance <= interactionDistance && Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    GameObject clickedObject = hit.collider.gameObject;
                    float clickedDistance = Mathf.Abs(transform.position.x - clickedObject.transform.position.x);
                    if (clickedDistance <= interactionDistance)
                    {
                        clickableObj.GetComponent<DialogueTrigger>().TriggerDialogue();
                    }
                }
                // panelController.CreateAndShowPanel(); // Usa PanelController para mostrar el panel
            }
        }
    }
}