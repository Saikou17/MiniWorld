using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class AnimationEvents : MonoBehaviour
{
    public void MyListenerObject (Object obj)
    {
        Debug.Log($"Given Object IS an AudioClip? [{obj is AudioClip}]");
        Debug.Log($"Given Object IS an GameObject? [{obj is GameObject}]");

        AudioClip aud = obj as AudioClip;

        if(aud != null)
        {
            // Play the audio clip
            GetComponent<AudioSource>().clip = aud;
            GetComponent<AudioSource>().Play();
        }
    }
}
