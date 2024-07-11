using UnityEditor;
using UnityEngine;

public class CubePlatformOrganizer : MonoBehaviour
{
    [MenuItem("Tools/Organize Cube Platform")]
    static void OrganizeCubePlatform()
    {
        GameObject[] selectedObjects = Selection.gameObjects;
        if (selectedObjects.Length != 256)
        {
            Debug.LogError("You must select exactly 256 objects.");
            return;
        }

        float separationDistance = 1.25f;
        int gridSize = 16;

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                int index = i * gridSize + j;
                Vector3 newPosition = new Vector3(j * separationDistance, 0, i * separationDistance);
                selectedObjects[index].transform.position = newPosition;
            }
        }
    }
}

