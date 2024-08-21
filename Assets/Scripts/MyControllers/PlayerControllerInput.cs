using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

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

            if (movementDirection != Vector3.zero)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    character.Move(movementDirection * 2f);
                }
                else
                {
                    character.Move(movementDirection);
                }
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

