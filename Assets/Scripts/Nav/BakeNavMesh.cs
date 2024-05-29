using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class BakeNavMesh : MonoBehaviour
{
    NavMeshSurface navMeshSurface;
    private void Start()
    {
        navMeshSurface = GetComponent<NavMeshSurface>();
        navMeshSurface.BuildNavMesh();
    }
}
