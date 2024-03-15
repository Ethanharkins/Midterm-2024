using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class CubeToSpiral : MonoBehaviour
{
    public float spiralTurns = 2f; // Number of turns in the spiral
    public float height = 2f; // Height of the spiral

    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = meshFilter.mesh;

        Vector3[] baseVertices = mesh.vertices;
        Vector3[] newVertices = new Vector3[baseVertices.Length];

        float maxY = float.MinValue;
        float minY = float.MaxValue;

        // Find min and max Y values to map them to the spiral height
        foreach (var vertex in baseVertices)
        {
            if (vertex.y > maxY) maxY = vertex.y;
            if (vertex.y < minY) minY = vertex.y;
        }

        for (int i = 0; i < baseVertices.Length; i++)
        {
            float normalizedY = (baseVertices[i].y - minY) / (maxY - minY);
            float angle = Mathf.Lerp(0, spiralTurns * 360, normalizedY) * Mathf.Deg2Rad;
            float radius = normalizedY; // This can be adjusted based on your spiral's desired appearance

            newVertices[i] = new Vector3(
                radius * Mathf.Cos(angle),
                baseVertices[i].y * height, // Scale height based on original Y position
                radius * Mathf.Sin(angle)
            );
        }

        mesh.vertices = newVertices;
        mesh.RecalculateNormals(); // Recalculate normals to correct lighting
        mesh.RecalculateBounds(); // Recalculate bounds if necessary
    }
}
