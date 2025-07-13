using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour 
{
    [SerializeField] private int _generation;

    private int _actionChance;
    private float _scaleReduce = 2;
    private int _actionChanceRangeMin = 0;
    private int _actionChanceRangeMax = 100;

    public int ActionChance => _actionChance;

    private void Awake()
    {
        _generation++;

        _actionChance = 100 / _generation;

        Vector3 scale = transform.localScale;
        transform.localScale = scale / _scaleReduce;

        if(TryGetComponent(out Renderer renderer))
            renderer.material.color = Random.ColorHSV();
    }
}
