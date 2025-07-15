using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private int _minAmount = 2;
    [SerializeField] private int _maxAmount = 6;
    [SerializeField] private CubeModifier _cubeModifier;

    public List<Cube> SpawnCubes(Cube cube)
    {
        int amount = Random.Range(_minAmount, _maxAmount + 1);
        List<Cube> createdCubes = new List<Cube>();

        for (int i = 0; i < amount; i++)
        {
            Cube newborn = Instantiate(cube);
            createdCubes.Add(newborn);
        }

        _cubeModifier.ModifyCubes(createdCubes);

        return createdCubes;
    }

    public void DestroyObject(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}
