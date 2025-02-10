using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugadores : MonoBehaviour
{
    public GameController GC;
    public static Jugadores Instance;
    public int Cantidaddejugadores = 0;

    //Info de los jugadores
    public string Playername = "";
    public string color = "";
    public bool[] pet = { false, false, false, false }; // Loro, gato, perro, pinguino
    public int score = 0;

    private void Awake() {
        if(Jugadores.Instance == null) {
            Jugadores.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(gameObject);
        }
    }
    private void Start() {
        GC.CanJug = Cantidaddejugadores;
    }
}
