using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsferaAnimation : MonoBehaviour
{

    //Creamos una animacion de rotacion
    public Vector3 rotation = new Vector3(40f,40f,40f);
    // Velocidad de movimiento vertical
    public float moveSpeed = 2f; 
    // Amplitud del movimiento vertical (altura máxima)
    public float moveAmplitude = 1f; 
    private float startY;
    void Start()
    {
        // Guardar la posición inicial del objeto
        startY = transform.position.y;
    }

    void Update()
    {
        // Rotar el objeto
        transform.Rotate(rotation * Time.deltaTime);

        // Mover el objeto arriba y abajo
        float newY = startY + Mathf.Sin(Time.time * moveSpeed) * moveAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
