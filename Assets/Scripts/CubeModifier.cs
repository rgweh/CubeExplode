using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class CubeModifier : MonoBehaviour
{
    public void ModifyCubes(List<Cube> cubes)
    {
        foreach (Cube cube in cubes)
        {
            if(cube.gameObject.TryGetComponent(out Renderer renderer))
                renderer.material.color = Random.ColorHSV();

            Vector3 scale = cube.transform.localScale;
            cube.transform.localScale = scale / cube.ScaleReduce;
        }
    }
}
