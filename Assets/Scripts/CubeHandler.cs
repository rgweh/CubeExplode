using System.Collections.Generic;
using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    [SerializeField] private CubeDuplicator _cubeDuplicator;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private ClickReader _clickReader;
    [SerializeField] private Cube _baseCube;
    [SerializeField] private Vector3 _spawnpoint;

    private void Start()
    {
        Cube firstCube = Instantiate(_baseCube, _spawnpoint, Quaternion.identity);
        firstCube.Init();

        _clickReader.OnCubeClicked += TryDuplicate;
    }

    private void TryDuplicate(Cube cube)
    {
        List<Cube> createdCubes = _cubeDuplicator.TryDuplicate(cube);

        if(createdCubes != null)
            Explode(cube, createdCubes);

        Destroy(cube.gameObject);
    }

    private void Explode(Cube cube, List<Cube> createdCubes)
    {
        _exploder.Explode(createdCubes);
    }

}
