using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement; // Necesario para cargar escenas

public class ButtonController : MonoBehaviour
{
    public Button J2;
    public Button J3;
    public Button J4;

    public Vector3 normalScale = new Vector3(1, 1, 1);
    public Vector3 selectedScale = new Vector3(1.2f, 1.2f, 1.2f);
    public float animationDuration = 0.2f;
    public ConfirmButtonController confirmButtonController;
    public GameController gameController;
    public int NumJug;
    private Button selectedButton;

    void Start()
    {
        // Asignamos los listeners a los botones 
        J2.onClick.AddListener(() => OnButtonClick(J2));
        J3.onClick.AddListener(() => OnButtonClick(J3));
        J4.onClick.AddListener(() => OnButtonClick(J4));
    }

    void OnButtonClick(Button clickedButton)
    {
        if (selectedButton != clickedButton)
        {
            if (selectedButton != null)
            {
                // Detenemos la animación anterior si existe en el GameController
                gameController.StartRestoreNormalScaleAnimation(selectedButton);
            }

            // Escalamos el botón recién seleccionado en el GameController
            gameController.StartScaleAnimation(clickedButton, selectedScale);
            selectedButton = clickedButton;
            confirmButtonController.EnableConfirmButton();
        }
        // Asignamos el valor correspondiente a NumJug
        if (clickedButton == J2)
        {
            NumJug = 2;
        }
        else if (clickedButton == J3)
        {
            NumJug = 3;
        }
        else if (clickedButton == J4)
        {
            NumJug = 4;
        }
        GameController.NumJugadores = NumJug;
    }
}