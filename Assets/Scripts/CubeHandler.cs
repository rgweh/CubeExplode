using System.Collections.Generic;
using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private ClickReader _clickReader;
    [SerializeField] private CubeModifier _cubeModifier;
    [SerializeField] private Cube _baseCube;
    [SerializeField] private Vector3 _spawnpoint;

    private int _minChance = 0;
    private int _maxChance = 100;

    private void Start()
    {
        Cube firstCube = Instantiate(_baseCube, _spawnpoint, Quaternion.identity);
        _clickReader.CubeClicked += TryDuplicate;
    }

    private void TryDuplicate(Cube cube)
    {
        if (Random.Range(_minChance, _maxChance) < cube.ActionChance)
        {
            List<Cube> createdCubes = _cubeSpawner.Duplicate(cube);
            _cubeModifier.ModifyCubes(createdCubes);
            _exploder.Explode(createdCubes, cube);
        }
        else
            _cubeSpawner.DestroyObject(cube);
    }
}
