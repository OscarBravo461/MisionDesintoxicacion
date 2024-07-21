using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtomNewGame : MonoBehaviour
{
    // Esta función se llama cuando se hace clic en el botón
    public void CambiarScene(string nombreDeLaEscena)
    {
        // Carga la escena especificada por su nombre
        SceneManager.LoadScene(nombreDeLaEscena);
    }
}