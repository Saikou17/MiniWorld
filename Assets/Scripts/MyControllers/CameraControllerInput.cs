using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerCam
{
    public class CameraControllerInput : MonoBehaviour
    {
        public float sensX;
        public float sensY;
        public Transform orientation;
        float xRotation;
        float yRotation;

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void Update()
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * sensX * Time.deltaTime;
            float mouseY = Input.GetAxisRaw("Mouse Y") * sensY * Time.deltaTime;

            // Rotar la cámara en el eje Y (mirar izquierda y derecha)
            yRotation += mouseX;
            xRotation -= mouseY; 
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
          

            // Rotar la cámara en el eje X (mirar arriba y abajo)
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
            orientation.rotation = Quaternion.Euler(0,yRotation, 0f);
    
        }
    }
}
