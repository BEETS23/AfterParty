using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public Material newMaterial; // Material para cuando se selecciona el objeto.
    public Material hoverMaterial; // Material para cuando el ratón pasa sobre el objeto.

    private Material originalMaterial; // Material original del objeto.
    private bool isSelected = false; // Indica si el objeto está seleccionado.
    public Sprite imageToShow; // La imagen específica para este objeto
    private CanvasController canvasController; // Referencia al controlador del canvas


    void Start()
    {
        originalMaterial = GetComponent<Renderer>().material;
        canvasController = FindObjectOfType<CanvasController>(); // Encuentra el controlador del canvas en la escena
    }

    public void SelectObject() 
    {
        if (canvasController != null)
        {
            isSelected = true; // Marca el objeto como seleccionado.
            canvasController.ShowImage(imageToShow); // Muestra la imagen en el canvas
        }
    }

    public void ResetColor()
    {
        GetComponent<Renderer>().material = originalMaterial;
        isSelected = false; // Marca el objeto como no seleccionado.
    }

    void OnMouseEnter()
    {
        // Cambia el color solo si el objeto no está seleccionado.
        if (!isSelected)
        {
            GetComponent<Renderer>().material = hoverMaterial;
        }
    }

    void OnMouseExit()
    {
        // Restablece el color solo si el objeto no está seleccionado.
        if (!isSelected)
        {
            ResetColor();
        }
    }
}
