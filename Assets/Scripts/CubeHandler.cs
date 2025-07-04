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

        _clickReader.OnCubeClicked += TryDuplicate;
    }

    private void TryDuplicate(Cube cube)
    {
        if (cube.WillDuplicate())
        {
            List<Cube> createdCubes = _cubeDuplicator.Duplicate(cube);
            _exploder.Explode(createdCubes, cube);
        }

        Destroy(cube.gameObject);
    }

}
