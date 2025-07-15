using System.Collections.Generic;
using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private ClickReader _clickReader;
    [SerializeField] private Cube _baseCube;
    [SerializeField] private Vector3 _spawnpoint;

    private int _minChance = 0;
    private int _maxChance = 100;

    private void Start()
    {
        Cube firstCube = Instantiate(_baseCube, _spawnpoint, Quaternion.identity);
        _clickReader.CubeClicked += TryDuplicate;
        _clickReader.ReaderDestroyed += UnsubscribeFromReader;
    }

    private void TryDuplicate(Cube cube)
    {
        if (Random.Range(_minChance, _maxChance) < cube.ActionChance)
        {
            List<Cube> createdCubes = _cubeSpawner.SpawnCubes(cube);
            _exploder.Explode(createdCubes, cube);
            _cubeSpawner.DestroyObject(cube);
        }
        else
        {
            _cubeSpawner.DestroyObject(cube);
        }
    }

    private void UnsubscribeFromReader()
    {
        _clickReader.CubeClicked -= TryDuplicate;
        _clickReader.ReaderDestroyed -= UnsubscribeFromReader;
    }
}
