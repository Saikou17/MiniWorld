using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCevents : MonoBehaviour
{

    public delegate void MyAnimationDelegate(GameObject targetObject);

    public static MyAnimationDelegate myAnimationEvent;

    public GameObject obj;

    private void OnEnable() 
    {
       myAnimationEvent += ActivateAnimation;
    }

    private void OnDisable()
    {
       myAnimationEvent -= ActivateAnimation;
    }

    private void ActivateAnimation(GameObject targetObject)
        {
            Animator animator = obj.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger("DoorATrigger");
            }
        }
     private void OnTriggerEnter(Collider other)
    {
        // Verificar si el jugador ha activado el trigger
        if (other.CompareTag("Player") && myAnimationEvent != null)
        {
            myAnimationEvent(obj); // Pasa la puerta al evento para activar la animación
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
