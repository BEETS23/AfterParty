using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    Vector2 lastMousePos;
    bool isMoving = false;
    GameObject selectedObject; // Almacena la referencia al objeto seleccionado actualmente.
    public GameObject canvas;
    private bool canMove = true;

    // Update is called once per frame
    void Update()
    {

        if (canvas.activeSelf)
        {
            canMove = false; // Deshabilita el movimiento mientras el canvas está activo
            return;
        }

        if (!canMove) 
        {
            return; // Si no puede moverse, no ejecutar el resto del código de Update
        }

        if (Input.GetMouseButtonDown(0))
        {
            lastMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isMoving = true;

            // Llama a la función para deseleccionar el objeto anterior.
            DeselectObject();
        }

        if (isMoving && (Vector2)transform.position != lastMousePos)
        {
            Vector3 newPos = transform.position;
            newPos.x = Mathf.MoveTowards(transform.position.x, lastMousePos.x, speed * Time.deltaTime);
            transform.position = newPos;
        }

        // Verifica si el jugador hizo clic en algo más.
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;

                // Si el objeto clickeado tiene el componente ObjectInteraction, guárdalo como objeto seleccionado.
                ObjectInteraction objectInteraction = clickedObject.GetComponent<ObjectInteraction>();
                if (objectInteraction != null)
                {
                    selectedObject = clickedObject;
                }
            }
        }
    }

    // Función para deseleccionar el objeto previamente seleccionado.
    void DeselectObject()
    {
        if (selectedObject != null)
        {
            ObjectInteraction objectInteraction = selectedObject.GetComponent<ObjectInteraction>();
            if (objectInteraction != null)
            {
                objectInteraction.ResetColor(); // Restaura el color del objeto anterior.
            }
        }
        selectedObject = null; // Limpia la referencia al objeto seleccionado.
    }

    public void EnableMovementAfterDelay(float delay)
    {
        StartCoroutine(EnableMovementDelay(delay));
    }

    private IEnumerator EnableMovementDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canMove = true;
    }

    public void ResetMovement()
    {
        isMoving = false; // Detiene el movimiento
        lastMousePos = transform.position; // Resetea la última posición de mouse
    }

}
