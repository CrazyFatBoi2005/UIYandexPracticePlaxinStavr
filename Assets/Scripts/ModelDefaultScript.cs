using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelDefaultScript : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material _baseMaterial;

    private void OnEnable()
    {
        _renderer.material = _baseMaterial;
    }
}
