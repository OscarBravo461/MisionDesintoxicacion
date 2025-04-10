using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugadores : MonoBehaviour
{
    public GameController GC;
    public static Jugadores Instance;
    public int Cantidaddejugadores = 4;

    //Info de los jugadores
    public string[] Playername = { "", "","","" };
    public string[] color = { "", "", "", "" };
    public string[] pet = { "", "", "", "" }; // Loro, gato, perro, pinguino
    public int[] score = { 0, 0, 0, 0 };
    public Image[] imagen = new Image[4];

    private void Awake() {
        if(Jugadores.Instance == null) {
            Jugadores.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(gameObject);
        }

        GC = FindAnyObjectByType<GameController>();
    }
    private void Start() {
        GC.CanJug = Cantidaddejugadores;
    }
}
