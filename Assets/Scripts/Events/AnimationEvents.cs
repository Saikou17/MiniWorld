using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class AnimationEvents : MonoBehaviour
{
    //Funcion para llamar objetos de AudioSource desde el Animation
    public void MyListenerObject (Object obj)
    {
        // Castear el objeto a un AudioClip
        AudioClip aud = obj as AudioClip;

        if(aud != null)
        {
            // Play the audio clip
            GetComponent<AudioSource>().clip = aud;
            GetComponent<AudioSource>().Play();
        }
    }

    //Funcion para desactivar objetos por nombre
    public void MyDisabledGameObjectByName(string objectName)
    {
        // Buscar el objeto por nombre
        GameObject obj = GameObject.Find(objectName);
        if (obj != null)
        {
            obj.SetActive(false);
        }
    }
}
