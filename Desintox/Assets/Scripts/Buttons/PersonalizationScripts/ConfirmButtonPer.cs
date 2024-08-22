using UnityEngine;
using UnityEngine.UI;

public class ConfirmButtonControllerPer : MonoBehaviour
{
    public Button confirmButton;
    public CanvasGroup confirmButtonCanvasGroup;
    public Canvas canvasToDisable; // Referencia al Canvas que deseas desactivar

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
        // Desactivamos el Canvas completo
        canvasToDisable.gameObject.SetActive(false);
    }
}