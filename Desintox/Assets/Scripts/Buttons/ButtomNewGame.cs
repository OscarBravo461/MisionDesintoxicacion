using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtomNewGame : MonoBehaviour
{
    // Esta funci�n se llama cuando se hace clic en el bot�n
    public void CambiarScene(string nombreDeLaEscena)
    {
        // Carga la escena especificada por su nombre
        SceneManager.LoadScene(nombreDeLaEscena);
    }
}