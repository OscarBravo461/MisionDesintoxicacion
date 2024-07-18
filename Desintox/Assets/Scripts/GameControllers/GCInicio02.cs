using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GCInicio02 : MonoBehaviour
{
    //Input.GetTouch(0); ---> De esta manera se puede registar la entrada táctil.
    //Link a la página de Unity ---> https://docs.unity3d.com/ScriptReference/Touch.html
    //Link a un video con información resumida ---> https://www.youtube.com/watch?v=2pw_rm4uTu8
    //La posición del toque se puede registrar con las coordenadas de los pixeles.
    public GameObject canvas_principal;
    public GameObject canvas_opciones;
    public TextMeshProUGUI texto_volumen;
    public Slider slider_volumen;
    void Start()
    {

    }

    void Update()
    {
        texto_volumen.text = slider_volumen.value.ToString();
    }

    public void Boton_Iniciar_Partida()
    {
        StartCoroutine(CargarEscena());
    }

    public void Boton_Opciones()
    {
        canvas_principal.SetActive(false);
        canvas_opciones.SetActive(true);
    }
    public void Boton_Regresar()
    {
        canvas_principal.SetActive(true);
        canvas_opciones.SetActive(false);
    }
    public void Boton_Salir()
    {
        Debug.Log("Saliendo");
        Application.Quit(); //En principio no se ocupa cambio en esta línea para Android.
    }

    private IEnumerator CargarEscena()
    {
        //Aquí podemos agregar algún tipo de efecto como fundido o algo que se vea más chido.
        yield return new WaitForSeconds(1f); //Este esperará para que se pueda ver el efecto antes de cambiar la escena.
        SceneManager.LoadSceneAsync("NuevoJuego"); //Cambiamos de escena (parece que no existen cambios en este apartado a la hora de programar para android).
        //Usamos LoadSceneAsyn para que la escena cargue en segundo plano en lo que el efecto se haga.
    }
}
