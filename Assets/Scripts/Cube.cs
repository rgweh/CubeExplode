using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour 
{
    [SerializeField] private int _generation;

    private float _actionChance;
    private float _scaleReduce = 2;

    public float ActionChance => _actionChance;

    public void Init()
    {
        _generation++;

        _actionChance = 100 / _generation;

        Vector3 scale = transform.localScale;
        transform.localScale = scale/_scaleReduce;

        var renderer = GetComponent<Renderer>();
        renderer.material.color = Random.ColorHSV();
    }
}
