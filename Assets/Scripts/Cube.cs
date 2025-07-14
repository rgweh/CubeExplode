using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour 
{
    [SerializeField] private int _generation;

    private float _actionChance;
    private float _scaleReduce = 2;
    private float _baseChance = 100;

    public float ActionChance => _actionChance;
    public float ScaleReduce => _scaleReduce;

    public void Awake()
    {
        _generation++;
        _actionChance = _baseChance / _generation;
    }
}
