using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Player_Controller;

public class MyCevents : MonoBehaviour
{
    //Funciones delegadas
    public delegate void MyAnimationDelegate(GameObject targetObject);

    public delegate void MyCinematicDelegate();

    //Variables de tipo de nuestras funciones
    public static MyAnimationDelegate myAnimationEvent;

    public static MyCinematicDelegate myCinematicEvent;

    //Atributos u Objetos a castear
    public GameObject targetObject;
    
    [SerializeField] private PlayableDirector _playableDirector;

    // Llamamos a nuestras funciones y las encapsulamos en las variable
    private void OnEnable() 
    {
       myAnimationEvent += ActivateAnimation;
       myCinematicEvent += PlayCinematic;
    }

    //Desactivamos nuestros eventos cuando no estemos llamandolos
    private void OnDisable()
    {
       myAnimationEvent -= ActivateAnimation;
       myCinematicEvent -= PlayCinematic;
    }

    // Funciones que llamarán a nuestras funciones delegadas
    private void ActivateAnimation(GameObject targetObject)
        {
            Animator animator = targetObject.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger("TriggerAnimation");
            }
        }

    private void PlayCinematic()
    {
        _playableDirector.Play(); 
    }

    //Funcion para activar los eventos a traves de Triggers
     private void OnTriggerEnter(Collider other)
    {
        
        // Verificar si el jugador ha activado el trigger
        if (other.CompareTag("Player") && targetObject.CompareTag("Animacion"))
        {
            myAnimationEvent(targetObject);
        }
        if (other.CompareTag("Player") && targetObject.CompareTag("Cinematica"))
        {
            PlayCinematic(); 
            //Desturimos el game object para que el evento se ejecute una vez
            Destroy(gameObject.GetComponent<BoxCollider>());
        }
    }

}
