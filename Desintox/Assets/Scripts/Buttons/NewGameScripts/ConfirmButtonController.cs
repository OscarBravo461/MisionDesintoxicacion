using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConfirmButtonController : MonoBehaviour
{
    public Button confirmButton;
    public CanvasGroup confirmButtonCanvasGroup;

    void Start()
    {
        // Al inicio, desactivamos el botón de confirmación
        DisableConfirmButton();

        // Asignamos un listener al botón para manejar el clic
        confirmButton.onClick.AddListener(OnConfirmButtonClick);
    }

    public void EnableConfirmButton()
    {
        // Habilita el botón de confirmación
        confirmButton.interactable = true;
        confirmButtonCanvasGroup.alpha = 1f; // Opacidad completa (sin transparencia)
    }

    public void DisableConfirmButton()
    {
        // Deshabilita el botón de confirmación
        confirmButton.interactable = false;
        confirmButtonCanvasGroup.alpha = 0.5f; // Opacidad reducida (transparencia)
    }

    public void OnConfirmButtonClick()
    {
        // Aquí es donde manejamos el clic en el botón de confirmación
        // En lugar de cambiar la escena, no hacemos nada adicional
        // El botón simplemente mantendrá su efecto de opacidad y no hará más acciones
    }
}