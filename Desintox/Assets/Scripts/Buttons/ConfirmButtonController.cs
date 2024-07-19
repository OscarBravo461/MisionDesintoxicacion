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
        DisableConfirmButton(); // Asegúrate de que el botón esté desactivado al inicio
    }

    public void EnableConfirmButton()
    {
        confirmButton.interactable = true;
        confirmButtonCanvasGroup.alpha = 1f; // Sin transparencia
    }

    public void DisableConfirmButton()
    {
        confirmButton.interactable = false;
        confirmButtonCanvasGroup.alpha = 0.5f; // Transparencia
    }

    public void OnConfirmButtonClick()
    {
        if (confirmButton.interactable)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}