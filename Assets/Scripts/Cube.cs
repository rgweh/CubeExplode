using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour 
{
    [SerializeField] private int _generation;

    private float _actionChance;
    private float _scaleReduce = 2;
    private int _actionChanceRangeMin = 0;
    private int _actionChanceRangeMax = 100;

    private void Awake()
    {
        _generation++;

        _actionChance = 100 / _generation;

        Vector3 scale = transform.localScale;
        transform.localScale = scale / _scaleReduce;

        var renderer = new Renderer();
        TryGetComponent<Renderer>(out renderer);

        if (renderer != null)
            renderer.material.color = Random.ColorHSV();
    }

    public bool WillDuplicate()
    {
        if(Random.Range(_actionChanceRangeMin, _actionChanceRangeMax + 1) <= _actionChance)
        {
            return true;
        }

        return false;
    }
}
