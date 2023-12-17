using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public Image displayImage; // Referencia al componente Image en el canvas
    public GameObject canvas; // Referencia al objeto del canvas

    void Start()
    {
        canvas.SetActive(false); // Oculta el canvas al inicio
    }

    public void ShowImage(Sprite imageToShow)
    {
        displayImage.sprite = imageToShow; // Establece la imagen a mostrar
        canvas.SetActive(true); // Muestra el canvas
    }

    public void CloseCanvas()
    {
        canvas.SetActive(false); // Oculta el canvas
    }
}
