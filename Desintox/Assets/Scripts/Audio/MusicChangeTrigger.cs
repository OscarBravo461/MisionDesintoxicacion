using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChangeTrigger : MonoBehaviour
{
    [Header("Area")]
    [SerializeField] private MusicArea area;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger");
        if (collider.tag.Equals("Player1"))
        {
            AudioManager.instance.SetMusicArea(area);
            Debug.Log("cambio");
        }
    }
}
