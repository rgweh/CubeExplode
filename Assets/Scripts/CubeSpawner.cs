using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private int _minAmount = 2;
    [SerializeField] private int _maxAmount = 6;

    public List<Cube> SpawnCubes(Cube cube)
    {
        int amount = Random.Range(_minAmount, _maxAmount + 1);
        List<Cube> createdCubes = new List<Cube>();

        for (int i = 0; i < amount; i++)
            createdCubes.Add(Instantiate(cube));

        ModifyCubes(createdCubes);

        return createdCubes;
    }

    public void SpawnCube(Cube cube, Vector3 spawnpoint)
    {
        Cube firstCube = Instantiate(cube, spawnpoint, Quaternion.identity);
    }

    public void DestroyObject(Cube cube)
    {
        Destroy(cube.gameObject);
    }

    public void ModifyCubes(List<Cube> cubes)
    {
        foreach (Cube cube in cubes)
        {
            if (cube.TryGetComponent(out Renderer cubeRenderer))
                cubeRenderer.material.color = Random.ColorHSV();

            Vector3 scale = cube.transform.localScale;
            cube.transform.localScale = scale / cube.ScaleReduce;
        }
    }
}
