using UnityEngine;
using UnityEngine.UIElements;

public class PanelController : MonoBehaviour
{
    private UIDocument panelUI;
    private VisualElement rootElement;
    private VisualElement panel;
    private Button closeButton;

    void Awake()
    {
        // Obtén la referencia al UIDocument de este GameObject
        panelUI = GetComponent<UIDocument>();
        if (panelUI == null)
        {
            Debug.LogError("No se encontró un componente UIDocument en este GameObject.");
        }
    }

    public void CreateAndShowPanel()
    {
        if (panelUI == null) return;

        // Carga el archivo UXML 'PanelLayout' desde la carpeta Resources
        var visualTree = Resources.Load<VisualTreeAsset>("PanelLayout");
        rootElement = visualTree.CloneTree();

        // Busca el panel y el botón de cerrar por sus nombres en el documento UXML
        panel = rootElement.Q<VisualElement>("Panel");
        closeButton = rootElement.Q<Button>("CloseButton");

        // Configura el evento click del botón para llamar a ClosePanel
        closeButton.clicked += ClosePanel;

        // Agrega el elemento raíz al UIDocument de este GameObject
        panelUI.rootVisualElement.Add(rootElement);

        // Muestra el panel
        panel.style.display = DisplayStyle.Flex;
    }

    public void ClosePanel()
    {
        // Elimina el panel y limpia los recursos
        panelUI.rootVisualElement.Remove(rootElement);
        rootElement = null;
        panel = null;
        closeButton = null;
    }
}
