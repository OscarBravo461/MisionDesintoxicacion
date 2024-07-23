using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonController : MonoBehaviour
{
    public Button[] buttons; // Arreglo de botones
    public Vector3 normalScale = new Vector3(1, 1, 1); // Escala normal del bot�n
    public Vector3 selectedScale = new Vector3(1.2f, 1.2f, 1.2f); // Escala cuando se selecciona el bot�n
    public float animationDuration = 0.2f; // Duraci�n de la animaci�n
    public ConfirmButtonController confirmButtonController; // Referencia al controlador del bot�n de confirmaci�n
    public GameController gameController; // Referencia al GameController

    private Button selectedButton; // Bot�n actualmente seleccionado

    void Start()
    {
        // Asignamos un listener a cada bot�n
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
                // Detenemos la animaci�n anterior si existe en el GameController
                gameController.StartRestoreNormalScaleAnimation(selectedButton); // Restauramos la escala normal
            }

            // Escalamos el bot�n reci�n seleccionado en el GameController
            gameController.StartScaleAnimation(clickedButton, selectedScale);
            selectedButton = clickedButton;
            confirmButtonController.EnableConfirmButton(); // Habilitamos el bot�n de confirmaci�n
        }
    }
}