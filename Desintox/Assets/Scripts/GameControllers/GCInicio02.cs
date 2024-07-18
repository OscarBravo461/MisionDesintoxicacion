using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GCInicio02 : MonoBehaviour
{
    //Input.GetTouch(0); ---> De esta manera se puede registar la entrada táctil.
    //Link a la página de Unity ---> https://docs.unity3d.com/ScriptReference/Touch.html
    //Link a un video con información resumida ---> https://www.youtube.com/watch?v=2pw_rm4uTu8
    //La posición del toque se puede registrar con las coordenadas de los pixeles.
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Boton_Iniciar_Partida()
    {
        StartCoroutine(CargarEscena());
    }

    private IEnumerator CargarEscena()
    {
        //Aquí podemos agregar algún tipo de efecto como fundido o algo que se vea más chido.
        yield return new WaitForSeconds(1f); //Este esperará para que se pueda ver el efecto antes de cambiar la escena.
        SceneManager.LoadSceneAsync("NuevoJuego"); //Cambiamos de escena (parece que no existen cambios en este apartado a la hora de programar para android).
        //Usamos LoadSceneAsyn para que la escena cargue en segundo plano en lo que el efecto se haga.
    }
}
