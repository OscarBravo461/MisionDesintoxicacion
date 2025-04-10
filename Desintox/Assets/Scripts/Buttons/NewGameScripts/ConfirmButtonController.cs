using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using JetBrains.Annotations;

public class ConfirmButtonController : MonoBehaviour
{
    public Button confirmButton;
    public CanvasGroup confirmButtonCanvasGroup;
    public Jugadores InfoJugadores;
    public GameController GC;
    public int conJug = 0;
    void Start() {
        InfoJugadores = FindAnyObjectByType<Jugadores>();
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
        InfoJugadores.Cantidaddejugadores = GC.CanJug;
        InfoJugadores.color[conJug] = GC.color;
        InfoJugadores.Playername[conJug] = GC.PlayerName;
        //GC.StartRestoreNormalScaleAnimation(GC.BotonSeleccionado);
        //GC.BotonSeleccionado.interactable = false;
        conJug++;
    }
}