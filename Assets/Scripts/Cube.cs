using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Renderer), typeof(Rigidbody))]
public class Cube : MonoBehaviour 
{
    [SerializeField] private int _generation;

    private Rigidbody _rigidbody;
    private Renderer _renderer;
    private float _baseChance = 100;

    public float ActionChance;
    public float ScaleReduce = 2;

    public void Awake()
    {
        _generation++;
        ActionChance = _baseChance / _generation;
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }
}
