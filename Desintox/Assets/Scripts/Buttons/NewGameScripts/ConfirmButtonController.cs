using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConfirmButtonController : MonoBehaviour
{
    public Button confirmButton;
    public CanvasGroup confirmButtonCanvasGroup;

    void Start()
    {
        // Al inicio, desactivamos el bot�n de confirmaci�n
        DisableConfirmButton();

        // Asignamos un listener al bot�n para manejar el clic
        confirmButton.onClick.AddListener(OnConfirmButtonClick);
    }

    public void EnableConfirmButton()
    {
        // Habilita el bot�n de confirmaci�n
        confirmButton.interactable = true;
        confirmButtonCanvasGroup.alpha = 1f; // Opacidad completa (sin transparencia)
    }

    public void DisableConfirmButton()
    {
        // Deshabilita el bot�n de confirmaci�n
        confirmButton.interactable = false;
        confirmButtonCanvasGroup.alpha = 0.5f; // Opacidad reducida (transparencia)
    }

    public void OnConfirmButtonClick()
    {
        // Aqu� es donde manejamos el clic en el bot�n de confirmaci�n
        // En lugar de cambiar la escena, no hacemos nada adicional
        // El bot�n simplemente mantendr� su efecto de opacidad y no har� m�s acciones
    }
}