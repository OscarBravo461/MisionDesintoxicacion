using UnityEngine;
using UnityEngine.UI; // Necesario para el uso de UI
using System.Collections;
using UnityEngine.SceneManagement; // Necesario para cargar escenas

public class GameController : MonoBehaviour
{
    public float animationDuration = 0.2f; // Duraci�n de la animaci�n en segundos

    // Corutina para escalar el bot�n
    IEnumerator ScaleButton(Button button, Vector3 targetScale)
    {
        Vector3 initialScale = button.transform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            button.transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        button.transform.localScale = targetScale; // Aseguramos que termine en la escala objetivo
    }

    // Corutina para restaurar la escala normal del bot�n
    IEnumerator RestoreNormalScaleAnimation(Button button)
    {
        Vector3 initialScale = button.transform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            button.transform.localScale = Vector3.Lerp(initialScale, Vector3.one, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        button.transform.localScale = Vector3.one; // Escala normal (1, 1, 1)
    }

    // Iniciar la animaci�n de escala
    public void StartScaleAnimation(Button button, Vector3 targetScale)
    {
        StartCoroutine(ScaleButton(button, targetScale));
    }

    // Iniciar la animaci�n para restaurar la escala normal
    public void StartRestoreNormalScaleAnimation(Button button)
    {
        StartCoroutine(RestoreNormalScaleAnimation(button));
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}