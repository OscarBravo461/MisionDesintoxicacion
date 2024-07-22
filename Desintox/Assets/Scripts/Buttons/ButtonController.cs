using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour
{
    // Arreglo de botones que queremos controlar
    public Button[] buttons;

    // Escala normal y escala cuando se selecciona un botón
    public Vector3 normalScale = new Vector3(1, 1, 1);
    public Vector3 selectedScale = new Vector3(1.2f, 1.2f, 1.2f);

    // Referencia al controlador del botón de confirmación (supongo que existe en otro lugar)
    public ConfirmButtonController confirmButtonController;

    // Botón actualmente seleccionado
    private Button selectedButton;

    void Start()
    {
        // Asignamos una función al evento OnClick de cada botón
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    void OnButtonClick(Button clickedButton)
    {
        if (selectedButton != null)
        {
            // Restauramos la escala normal del botón previamente seleccionado
            selectedButton.transform.localScale = normalScale;
        }

        if (selectedButton == clickedButton)
        {
            // Si el botón seleccionado es el mismo que se hizo clic, lo deseleccionamos
            selectedButton = null;
            confirmButtonController.DisableConfirmButton();
        }
        else
        {
            // Si se hizo clic en un botón diferente, lo marcamos como seleccionado
            clickedButton.transform.localScale = selectedScale;
            selectedButton = clickedButton;
            confirmButtonController.EnableConfirmButton();
        }
    }

    public void DeselectAllButtons()
    {
        if (selectedButton != null)
        {
            // Deseleccionamos todos los botones y restauramos su escala normal
            selectedButton.transform.localScale = normalScale;
            selectedButton = null;
            confirmButtonController.DisableConfirmButton();
        }
    }
}