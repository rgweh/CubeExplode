using System.Collections.Generic;
using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private ClickReader _clickReader;
    [SerializeField] private Vector3 _spawnpoint;
    [SerializeField] private Cube _baseCube;

    private int _minChance = 0;
    private int _maxChance = 100;

    private void OnEnable()
    {
        _cubeSpawner.SpawnCube(_baseCube, _spawnpoint);
        _clickReader.CubeClicked += TryDuplicate;
    }

    private void OnDisable()
    {
        _clickReader.CubeClicked -= TryDuplicate;
    }

    private void TryDuplicate(Cube cube)
    {
        if (Random.Range(_minChance, _maxChance) < cube.ActionChance)
        {
            List<Cube> createdCubes = _cubeSpawner.SpawnCubes(cube);
            _exploder.Explode(createdCubes, cube);
        }

        _cubeSpawner.DestroyObject(cube);
    }
}
