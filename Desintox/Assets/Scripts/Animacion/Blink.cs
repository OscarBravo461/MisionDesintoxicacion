using System.Collections;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; 

public class BlinkingText : MonoBehaviour
{
    private TextMeshProUGUI blinkText;
    private bool isBlinking = true;

    void Start()
    {
        blinkText = GetComponent<TextMeshProUGUI>();
        /*
        // Chequeo de que exista
        if (blinkText == null)
        {
            Debug.LogError("TextMeshProUGUI component not found!");
            return;
        }
        */
        StartCoroutine(Blink());
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)//Input.touchCount, se utiliza en dispositivos moviles
        {
            LoadNextScene();
        }
    }
    IEnumerator Blink()
    {
        while (isBlinking)
        {
            blinkText.enabled = !blinkText.enabled;
            yield return new WaitForSeconds(0.5f);
        }
    }

    void LoadNextScene()
            {
                int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        /*
        // Checar si hay escenas a updatear
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No more scenes to load!");
        }*/
        SceneManager.LoadScene(nextSceneIndex);
    }
}

