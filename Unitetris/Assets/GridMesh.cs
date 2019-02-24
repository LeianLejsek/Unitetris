using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class GridMesh : MonoBehaviour
{

    public GameObject gc = GameObject.Find("GameController");      
    
    void Awake()
    {
        SetUp su = gc.GetComponent<SetUp>();
        int GridWidth = su.width;
        int GridHeight = su.height;

        MeshFilter filter = gameObject.GetComponent<MeshFilter>();
        var mesh = new Mesh();
        var verticies = new List<Vector3>();
        var indicies = new List<int>();
        int index = 0;

        for(int j = 0; j <= GridHeight; j++)
        {
            for (int i = 0; i <= GridWidth; i++)
            {
                verticies.Add(new Vector3(i, j, 0));
                verticies.Add(new Vector3(i, j, GridWidth));

                indicies.Add(4*GridHeight * i + index % (4 * GridHeight));
                index++;
                indicies.Add(4*GridHeight * i + index % (4 * GridHeight));
                index++;

                verticies.Add(new Vector3(0, j, i));
                verticies.Add(new Vector3(GridWidth, j, i));

                indicies.Add(4*GridHeight * i + index % (4 * GridHeight));
                index++;
                indicies.Add(4*GridHeight * i + index % (4 * GridHeight));
                index++;

            }
        }
        


        mesh.vertices = verticies.ToArray();
        mesh.SetIndices(indicies.ToArray(), MeshTopology.Lines, 0);
        filter.mesh = mesh;

        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Sprites/Default"));
        meshRenderer.material.color = new Color(1.0f, 1.0f, 1.0f, 0.1f);
    }
}