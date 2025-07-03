using System.Collections.Generic;
using UnityEngine;

public class CubeDuplicator : MonoBehaviour
{
    [SerializeField] private int _minAmount = 2;
    [SerializeField] private int _maxAmount = 6;

    private int _actionChanceRangeMin = 0;
    private int _actionChanceRangeMax = 101;

    public List<Cube> TryDuplicate(Cube cube)
    {
        if(Random.Range(_actionChanceRangeMin, _actionChanceRangeMax) <= cube.ActionChance)
        {
            int amount = Random.Range(_minAmount, _maxAmount + 1);
            List<Cube> createdCubes = new List<Cube>();

            for (int i = 0; i < amount; i++)
            {
                Cube newborn = Instantiate(cube);
                createdCubes.Add(newborn);
                newborn.Init();
            }

            return createdCubes;
        }

        return null;
    }
}
