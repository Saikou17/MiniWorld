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
        private bool groundedPlayer;
        private Vector3 velocity;
        private Vector2 cameraLook;
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

        //Funcion de movimiento del characte controller
        public void Move(Vector3 direction){
            var localDirection = controller.transform.TransformDirection(Vector3.ClampMagnitude(direction,1f));
            controller.Move(localDirection * Time.deltaTime * speed);
            _animator.SetFloat(FrontWalkAnimation, direction.z);
            _animator.SetFloat(SideWalkAnimation, direction.x);
            
        }

        //Funcion de movimiento de la camara
        public void CameraView(Vector2 view, Transform cameraPlayer)
        {
            //Input y valores de la camara
            cameraLook.x += view.x;
            cameraLook.y = Mathf.Clamp(cameraLook.y + view.y, -90f, 90f);
            //Aplicamos las rotaciones sobre la camara y el jugador
            cameraPlayer.localRotation = Quaternion.Euler(-cameraLook.y, 0, 0);
            controller.transform.rotation = Quaternion.Euler(0, cameraLook.x, 0);
            // transform.localRotation = Quaternion.Euler(0,cameraLook.x,0);
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