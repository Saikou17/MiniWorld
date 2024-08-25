using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

namespace Player{

    public class Player : IMovement
    {
        //Attributes
        private float gravity = -9.81f;
        private float speed = 2.0f;
        private float jumpForce = 30f;
        private bool groundedPlayer;
        private Vector3 velocity;

        //animacion para el personaje
        private readonly AnimatorController _animator;

        //nombre de los parametros de la animacion
        private const string FrontWalkAnimation = "Forward";
        private const string SideWalkAnimation = "Side";
        private const string RandomAnimation = "Jump";


        //Hashes de las animaciones
        private readonly int _randomAnimationHash = Animator.StringToHash(name:"(JUMP01)");
        
        //Controlar el jugador
        public CharacterController controller { get; set; }
        public LayerMask groundMask;

        public Transform orientation;

        //Methods
        public Player(CharacterController characterController, LayerMask groundLayerMask)
            {
                controller = characterController;
                groundMask = groundLayerMask;

                //Nuevo animador
                _animator = new AnimatorController();
                _animator.Animator = controller.GetComponentInChildren<Animator>();
            }

        protected Player()
        {

        }

        public void Move(Vector3 direction){
            var localDirection = controller.transform.TransformDirection(direction);
            controller.Move(localDirection * Time.deltaTime * speed);
            controller.transform.Rotate(Vector3.up,direction.x* 2,Space.World);
            _animator.SetFloat(FrontWalkAnimation, direction.z);
            _animator.SetFloat(SideWalkAnimation, direction.x);
            
        }
        public void Jump(){
            if(!AreYouOnTheGround() || velocity.y > 0) return;
            velocity.y += Mathf.Sqrt(jumpForce*-3.0f*gravity);
            controller.Move(velocity*Time.deltaTime);
            _animator.SetTrigger(RandomAnimation);

        }
        public void GroundedCharacter(){
            if(AreYouOnTheGround() && velocity.y < 0)
            {
                velocity.y = 0f;
                return;
            }
            velocity.y += gravity*Time.deltaTime;
            controller.Move(velocity*Time.deltaTime);
        }

        public bool AreYouOnTheGround(){
            Debug.DrawRay(controller.transform.position,Vector3.down*0.15f,Color.red);
            return Physics.Raycast(controller.transform.position,Vector3.down,out RaycastHit Hit,0.15f,groundMask);
        }
    }
}