using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GridService GridService;
    [SerializeField] private Color _baseColor;
    [SerializeField] private Color _offsetColor;
    [SerializeField] private MeshRenderer _meshRenderer;
    public bool _lockedForWalk;

    public void Init(bool isOffset)
    {
        _meshRenderer.material.color = isOffset ? _offsetColor : _baseColor;   
    }
}
