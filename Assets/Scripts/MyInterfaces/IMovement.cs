using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces{

    public interface IMovement
    {
        //Methods
        public CharacterController controller { get; set; }
        // For Movement and Jumping related actions
        public void Move(Vector3 position);
        public void Jump();
        // In a 3D game
        public void GroundedCharacter();
        public bool AreYouOnTheGround();
    }
}


