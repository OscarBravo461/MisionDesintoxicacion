using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class FMODMultiSongZone : MonoBehaviour
{
    [Header("Evento FMOD")]
    [Tooltip("Ruta del evento FMOD, por ejemplo: 'event:/Music'")]
    [SerializeField] private string fmodEventPath;

    [Header("Parámetros del Evento FMOD")]
    [Tooltip("Nombre del parámetro que controla la canción, por ejemplo: 'SongSelector'")]
    [SerializeField] private string parameterName;

    [Tooltip("Índice de canción para esta zona (0 a 5)")]
    [SerializeField][Range(0, 6)] private int songIndex = 0;

    [Header("Opciones de Configuración")]
    [Tooltip("Si se activa, el cambio de canción ocurrirá solo la primera vez que el Player entre en la zona")]
    [SerializeField] private bool playOnce = true;

    private bool alreadyChanged = false;
    private EventInstance eventInstance;

    private void Start()
    {
        // Se crea la instancia del evento FMOD y se inicia la reproducción.
        eventInstance = RuntimeManager.CreateInstance(fmodEventPath);
        eventInstance.start();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica que el objeto que ingresa tenga la etiqueta "Player" 
        // y controla la lógica para reproducir una sola vez.
        if (other.CompareTag("Player1") && (!alreadyChanged || !playOnce))
        {
            // Cambia el parámetro que selecciona la canción
            eventInstance.setParameterByName(parameterName, songIndex);
            alreadyChanged = true;
        }
    }

    private void OnDestroy()
    {
        // Se detiene y libera la instancia del evento FMOD para evitar fugas de memoria.
        eventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        eventInstance.release();
    }
}

