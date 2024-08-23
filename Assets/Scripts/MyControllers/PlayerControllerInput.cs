using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using Player;

namespace Player_Controller
{
    public class PlayerController : MonoBehaviour
    {

        public LayerMask groundMask;

        private IMovement character;


        // Start is called before the first frame update
        void Start()
        {
            character = new Player.Player(GetComponent<CharacterController>(), groundMask);
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            Debug.Log(movementDirection);
            float transitionRun = 0;

            if (movementDirection != Vector3.zero)
            {
                character.Move(movementDirection);
            }

            if (Input.GetButtonDown("Jump"))
            {
                character.Jump();
            }

            // Ground character
            character.AreYouOnTheGround();

        }
    }
}

