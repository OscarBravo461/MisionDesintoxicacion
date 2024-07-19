using System.Collections;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 

public class BlinkingText : MonoBehaviour
{
    // Componente que parpadea
    private TextMeshProUGUI blinkText;
    // Intervalo
    public float blinkInterval = 0.5f;

    // Flag controladora
    private bool isBlinking = true;

    void Start()
    {
        blinkText = GetComponent<TextMeshProUGUI>();

        // Chequeo de que exista
        if (blinkText == null)
        {
            Debug.LogError("TextMeshProUGUI component not found!");
            return;
        }

        StartCoroutine(Blink());
    }
    private void Update()
    {
        // Teoricamente hablando esto tiene en cuenta el touch
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            LoadNextScene();
        }
    }
    IEnumerator Blink()
    {
        while (isBlinking)
        {
            // Cambia elestado para que parpadee
            blinkText.enabled = !blinkText.enabled;

            // Espera el intervalo
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    void LoadNextScene()
            {
                // Asummiendo que estan ordenadas
                int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

                // Checar si hay escenas a updatear
                if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
                {
                    SceneManager.LoadScene(nextSceneIndex);
                }
                else
                {
                    Debug.LogWarning("No more scenes to load!");
                }
            }
}

