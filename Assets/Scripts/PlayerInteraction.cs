using UnityEngine;
using System.Collections.Generic;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 2.0f;
    public GameObject closeupCanvas; // Referencia al canvas Closeup_01

    private List<GameObject> clickableObjects = new List<GameObject>();
    public PlayerMovement playerMovementScript; // Referencia al script PlayerMovement


    void Start()
    {
        GameObject[] clickable = GameObject.FindGameObjectsWithTag("Clickable");
        clickableObjects.AddRange(clickable);
        closeupCanvas.SetActive(false); // Asegúrate de que el canvas esté oculto al inicio
    }

    void Update()
    {
        foreach (GameObject clickableObj in clickableObjects)
        {
            float distance = Vector2.Distance(transform.position, clickableObj.transform.position);

            if (distance <= interactionDistance && Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    clickableObj.GetComponent<ObjectInteraction>().ChangeColor();
                    closeupCanvas.SetActive(true); // Muestra el canvas
                    
                }
            }
        }
    }

    // En el método que cierra el canvas
    public void CloseCanvas()
    {
        closeupCanvas.SetActive(false);
        playerMovementScript.EnableMovementAfterDelay(0.5f); // 0.5 segundos de retraso
        playerMovementScript.ResetMovement();
    }

}
