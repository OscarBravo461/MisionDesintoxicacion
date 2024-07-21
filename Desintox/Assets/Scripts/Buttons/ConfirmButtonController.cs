using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConfirmButtonController : MonoBehaviour
{
    public Button confirmButton;
    public CanvasGroup confirmButtonCanvasGroup;
    public string nextSceneName;

    void Start()
    {
        // Al inicio, desactivamos el bot�n de confirmaci�n
        DisableConfirmButton();
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
        // Si el bot�n de confirmaci�n est� habilitado, carga la siguiente escena
        if (confirmButton.interactable)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}