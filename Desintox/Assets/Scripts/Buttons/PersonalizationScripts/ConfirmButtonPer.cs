using UnityEngine;
using UnityEngine.UI;

public class ConfirmButtonControllerPer : MonoBehaviour
{
    public Button confirmButton;
    public CanvasGroup confirmButtonCanvasGroup;
    public Canvas canvasToDisable; // Referencia al Canvas que deseas desactivar

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
        // Desactivamos el Canvas completo
        canvasToDisable.gameObject.SetActive(false);
    }
}