using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Grid : MonoBehaviour
{
	public int xSize, ySize;
	private Vector3[] vertices;
	private Mesh mesh;

	private void Generate()
	{
		GetComponent<MeshFilter>().mesh = mesh = new Mesh();
		mesh.name = "Procedural Grid";
		vertices = new Vector3[(xSize + 1) * (ySize + 1)];

		for (int i = 0, y = 0; y <= ySize; y++)
		{
			for (int x = 0; x <= xSize; x++, i++)
			{
				vertices[i] = new Vector3(x, y);
			}
		}

        mesh.vertices = vertices;

		int[] triangles = new int[3];
		triangles[0] = 0;
		triangles[1] = xSize + 1;
		triangles[2] = 1;
		mesh.triangles = triangles;
	}

	private void OnDrawGizmos()
	{
		if (vertices == null)
		{
			return;
		}

		Gizmos.color = Color.black;
		for (int i = 0; i < vertices.Length; i++)
		{
			Gizmos.DrawSphere(vertices[i], 0.1f);
		}
	}

	private void Awake()
	{
		Generate();
	}
}