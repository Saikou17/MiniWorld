using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables; // Agrega esta línea
using Player_Controller;

public class MyCevents : MonoBehaviour
{

    public delegate void MyAnimationDelegate(GameObject targetObject);

    public delegate void MyCinematicDelegate(GameObject value);

    public static MyAnimationDelegate myAnimationEvent;

    public static MyCinematicDelegate myCinematicEvent;

    public GameObject obj;

    private void OnEnable() 
    {
       myAnimationEvent += ActivateAnimation;
       myCinematicEvent += PlayCinematic;
    }

    private void OnDisable()
    {
       myAnimationEvent -= ActivateAnimation;
       myCinematicEvent -= PlayCinematic;
    }

    private void ActivateAnimation(GameObject targetObject)
        {
            Animator animator = obj.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger("DoorATrigger");
            }
        }

    private void PlayCinematic(GameObject targetObject)
    {
        PlayableDirector director = obj.GetComponent<PlayableDirector>();
        if (director!= null)
        {
            director.enabled = true;
            GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<PlayerControllerInput>().enabled = false;
            // Opcionalmente, desactiva el PlayableDirector después de su duración
            StartCoroutine(DisableDirectorAfterFinish(11));
        } 
    }

    private IEnumerator DisableDirectorAfterFinish(float time)
    {
        yield return new WaitForSeconds(time); // Espera a que termine la timeline
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<PlayerControllerInput>().enabled = true;
    }
    
     private void OnTriggerEnter(Collider other)
    {
        // Verificar si el jugador ha activado el trigger
        if (other.CompareTag("Player") && obj.CompareTag("Animacion") && myAnimationEvent != null )
        {
            myAnimationEvent(obj); // Pasa la puerta al evento para activar la animación
        }
        if (other.CompareTag("Player") && obj.CompareTag("Cinematica") && myCinematicEvent != null )
        {
            myCinematicEvent(obj); // Pasa la puerta al evento para activar la cámara cinemática
            Destroy(gameObject.GetComponent<BoxCollider>());
        }
    }

}
