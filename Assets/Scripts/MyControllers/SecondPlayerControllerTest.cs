// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Interfaces;
// using Player;
// using PlayerCam;

// public class SecondPlayerControllerTest : MonoBehaviour
// {
//     public float speed;
//     public Transform orientation;
//     float horizontal;
//     float vertical;
//     Vector3 direction;
//     public CharacterController controller { get; set; }
    
//     private MyInput()
//     {
//         horizontal = Input.GetAxisRaw("Horizontal");
//         vertical = Input.GetAxisRaw("Vertical");
//     }

//     private void MovePlayer()
//     {
//         direction = orientation.fordward * vertical + orientation.right * horizontal + direction;
//     }
//     // Start is called before the first frame update
//     void Start()
//     {
//          character = new Player.Player(GetComponent<CharacterController>(), groundMask);
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         MyInput();
//     }
// }
