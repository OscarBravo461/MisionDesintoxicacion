using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonController : MonoBehaviour
{
    public Button[] buttons; // Arreglo de botones
    public Vector3 normalScale = new Vector3(1, 1, 1); // Escala normal del botón
    public Vector3 selectedScale = new Vector3(1.2f, 1.2f, 1.2f); // Escala cuando se selecciona el botón
    public float animationDuration = 0.2f; // Duración de la animación
    public ConfirmButtonController confirmButtonController; // Referencia al controlador del botón de confirmación
    public GameController gameController; // Referencia al GameController

    private Button selectedButton; // Botón actualmente seleccionado

    void Start()
    {
        // Asignamos un listener a cada botón
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    void OnButtonClick(Button clickedButton)
    {
        if (selectedButton != clickedButton)
        {
            if (selectedButton != null)
            {
                // Detenemos la animación anterior si existe en el GameController
                gameController.StartRestoreNormalScaleAnimation(selectedButton); // Restauramos la escala normal
            }

            // Escalamos el botón recién seleccionado en el GameController
            gameController.StartScaleAnimation(clickedButton, selectedScale);
            selectedButton = clickedButton;
            confirmButtonController.EnableConfirmButton(); // Habilitamos el botón de confirmación
        }
    }
}