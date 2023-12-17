using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    Vector2 lastMousePos;
    bool isMoving = false;
    public GameObject selectedObject; // Almacena la referencia al objeto seleccionado actualmente.
    public GameObject canvas;
    private bool canMove = true;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (canvas != null)
        {
            canvas.SetActive(false); // Asegúrate de que el canvas esté oculto al inicio
        }
    }
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
            animator.Play("P_Walk");

            // Llama a la función para deseleccionar el objeto anterior.
            DeselectObject();
        }

        if (isMoving && transform.position.x != lastMousePos.x)
        {
            Vector3 newPos = transform.position;
            newPos.x = Mathf.MoveTowards(transform.position.x, lastMousePos.x, speed * Time.deltaTime);
            transform.position = newPos;
        }

        if (isMoving)
        {
            Vector3 newPos = transform.position;
            newPos.x = Mathf.MoveTowards(transform.position.x, lastMousePos.x, speed * Time.deltaTime);
            transform.position = newPos;

            if (lastMousePos.x < transform.position.x) // Movimiento hacia la izquierda
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if (lastMousePos.x > transform.position.x) // Movimiento hacia la derecha
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }

            // Comprueba si el jugador ha llegado a la posición de destino
            if (Mathf.Abs(transform.position.x - lastMousePos.x) < 0.1f) // 0.1f es un umbral para la precisión
            {
                isMoving = false;
                animator.Play("P_Idle"); // Cambia a la animación idle
            }
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
        animator.Play("P_Idle");
    }

}
