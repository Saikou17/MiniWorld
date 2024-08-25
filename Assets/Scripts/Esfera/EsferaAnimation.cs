using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsferaAnimation : MonoBehaviour
{

    public Vector3 rotation = new Vector3(40f,40f,40f);
    public float moveSpeed = 2f; // Velocidad de movimiento vertical
    public float moveAmplitude = 1f; // Amplitud del movimiento vertical (altura máxima)
    private float startY; // Posición inicial en Y
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
