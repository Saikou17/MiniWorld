using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using Player;
using PlayerCam;

namespace Player_Controller
{
    public class PlayerControllerInput : MonoBehaviour
    {

        //Atributos
        //Transform de la camara del jugador
        [SerializeField] Transform cameraPlayer;
        //Vector de la vista
        Vector2 CameraView;
        //Vector del movimento
        Vector3 movementDirection;
        //Mascara 
        public LayerMask groundMask;
        //Creamos un objeto de tipo interfaz
        private IMovement character;

        void Start()
        {
            //Instanciamos un nuevo objeto de tipo Player y su constructor
            character = new Player.Player(GetComponent<CharacterController>(), groundMask);
            //Desaparecemos el curso de la pantalla
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            //Input que regresa la posicion que se debe mover
            Vector3 movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //Input que regresa la posicion que se debe rotar la camara
            Vector2 cameraView = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            //Mostramos los valores en consola para debuggear
            Debug.Log(movementDirection);
            Debug.Log(cameraView);
            //Movimiento y vista del personaje

            character.CameraView(cameraView,cameraPlayer);
            if (movementDirection != Vector3.zero)
            {
                character.Move(movementDirection);
            }
            // Ground character
            character.AreYouOnTheGround();
        }

    }
}

