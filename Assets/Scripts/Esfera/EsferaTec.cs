using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsferaTec : MonoBehaviour
{
    //Material o textura de la esfera
    public Material material;
    //Una lista de vectores (poligonos de la esfera tecelada)
    List<Vector3> geometry;
    // Una lista de índices (aristas) de la esfera tecelada
    List<int> topology;

    List<int> Subdivide(List<int> triangle) // Subdivide triángulos en 4 triángulos
    {
        // Índices de los vértices
        int iA = triangle[0]; // Índice del vértice A
        int iB = triangle[1]; // Índice del vértice B
        int iC = triangle[2]; // Índice del vértice C
        int iD, iE, iF; // Índices de los vértices D, E y F

        // Vértices
        Vector3 A = geometry[iA]; // Vértice A
        Vector3 B = geometry[iB]; // Vértice B
        Vector3 C = geometry[iC]; // Vértice C
        // Vértices intermedios
        Vector3 D = ((A + B) / 2).normalized; // Vértice D
        Vector3 E = ((B + C) / 2).normalized; // Vértice E
        Vector3 F = ((C + A) / 2).normalized; // Vértice F

        // Añadir vértices al array geometry
        if (geometry.Contains(D)) iD = geometry.IndexOf(D);
        else
        {
            iD = geometry.Count;
            geometry.Add(D);
        }

        if (geometry.Contains(E)) iE = geometry.IndexOf(E);
        else
        {
            iE = geometry.Count;
            geometry.Add(E);
        }

        if (geometry.Contains(F)) iF = geometry.IndexOf(F);
        else
        {
            iF = geometry.Count;
            geometry.Add(F);
        }

        // Devolver los índices de los vértices
        List<int> result = new List<int> {iA,iD,iF, iD,iB,iE, iD,iE,iF, iF,iE,iC};
        return result;
    }

    void Start()
    {
        geometry = new List<Vector3>();
        geometry.Add(new Vector3(0, 0, 1)); // A = 0
        geometry.Add(new Vector3(1, 0, 0)); // B = 1
        geometry.Add(new Vector3(0, 1, 0)); // C = 2
        geometry.Add(new Vector3(0, 0, -1)); // D = 3
        geometry.Add(new Vector3(-1, 0, 0)); // E = 4
        geometry.Add(new Vector3(0, -1, 0)); // F = 5


        topology = new List<int>() {0,1,2, 
                                    1,3,2,
                                    3,4,2,
                                    4,0,2,
                                    5,1,0,
                                    5,3,1,
                                    5,4,3,
                                    5,0,4
                                    };

        Iterations(3); // Iteraciones
    }

    void GenerateUVs()
{
    // Inicializa una lista para las coordenadas UV
    List<Vector2> uvs = new List<Vector2>();

    // Recorre todos los vértices y calcula sus coordenadas UV
    foreach (Vector3 vertex in geometry)
    {
        // Convierte las coordenadas esféricas a UV
        float u = Mathf.Atan2(vertex.z, vertex.x) / Mathf.PI + 0.5f;
        float v = Mathf.Asin(vertex.y / vertex.magnitude) / Mathf.PI + 0.5f;

        uvs.Add(new Vector2(u, v));
    }

    // Asigna las coordenadas UV a la malla
    MeshFilter mf = GetComponent<MeshFilter>();
    Mesh mesh = mf.sharedMesh;
    mesh.uv = uvs.ToArray();
}




    void Iterations(int n) // Iteraciones
        {   
            for (int iter = 0; iter < n; iter++) // Iterar n veces
            {
                int limit = topology.Count; // Número de triángulos
                for (int i = 0; i < limit; i += 3) // Recorrer los triángulos
                {
                    List<int> division = Subdivide(new List<int> {topology[i], topology[i + 1], topology[i + 2]}); // Subdividir triángulo
                    foreach (int j in division) topology.Add(j); // Añadir los nuevos triángulos
                }
                topology.RemoveRange(0, limit); // Eliminar los triángulos originales
            }
            
            MeshFilter mf = gameObject.AddComponent<MeshFilter>();
            Mesh mesh = new Mesh();
            mesh.vertices = geometry.ToArray();
            mesh.triangles = topology.ToArray();
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
            MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();
            mf.sharedMesh = mesh;
            mr.material = material;

            // Generar coordenadas UV
                // Genera las coordenadas UV
            GenerateUVs();
            mf.sharedMesh = mesh;
            mr.material = material;
        }
}
