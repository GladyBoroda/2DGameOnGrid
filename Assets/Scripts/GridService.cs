using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridService : MonoBehaviour
{
    [SerializeField] private int _width;
    [SerializeField] private int _hight;

    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Tile _LockForWolkTile;
    [SerializeField] private GameObject LockedCollider ;

    private void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int z = 0; z < _hight; z++)
            {
                Tile _RandomTile;
                var _randomTile = Random.Range(0, 6);
                if (_randomTile == 3)
                {
                    _RandomTile = _LockForWolkTile;
                }
                else
                {
                    _RandomTile = _tilePrefab;
                }
                Tile spawnedTile = Instantiate(_RandomTile, new Vector3(x, 0,z), Quaternion.identity);
                if (_LockForWolkTile)
                {
                    LockedTile();
                }
                spawnedTile.name = $"Tile {x} {z}";
                var isOffset = (x % 2 == 0 && z % 2 != 0) || (x % 2 != 0 && z % 2 == 0);
                spawnedTile.Init(isOffset);
            }
        }
        void LockedTile()
        {
            _LockForWolkTile._lockedForWalk = true;
        }
    }
}
