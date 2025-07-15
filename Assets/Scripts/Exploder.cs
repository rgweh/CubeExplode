using System;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explodeRadius;
    [SerializeField] private float _explodeForse;

    public event Action<Cube> Exploded;

    public void Explode(List<Cube> createdCubes, Cube cube)
    {
        foreach (Cube createdCube in createdCubes)
        {
            cube.GetComponent<Rigidbody>().AddExplosionForce(_explodeForse, cube.transform.position, _explodeRadius);
        }
    }
}
