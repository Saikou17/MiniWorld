using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //Listas de los diferentes audios a reproducir
    public List<AudioClip> StoneStep;
    public List<AudioClip> WaterStep;
    public AudioSource audioSource_step;
    public int groundType = 0;
    //Funcion que es llamada desde los eventos de animacion
    public void PlayAudio()
    {
        //Escoge un sonido aleatorio de la lista según el tipo de suelo
        switch (groundType)
        {
            case 0:
                Debug.Log("Reproduciendo sonido de piedra.");
                audioSource_step.PlayOneShot(StoneStep[Random.Range(0, StoneStep.Count)]);
                break;
            case 1:
                Debug.Log("Reproduciendo sonido de agua.");
                audioSource_step.PlayOneShot(WaterStep[Random.Range(0, WaterStep.Count)]);
                break;
            default:
                Debug.LogWarning("Tipo de suelo no válido.");
                break;
        }
    }

}
