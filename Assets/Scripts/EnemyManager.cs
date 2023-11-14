using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Durian
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField, Category("Prefab")] private Entity _enemy;
        [SerializeField, Category("Reference")] private GameObject _spawnPoint;
        [SerializeField, Category("Reference")] private Rigidbody2D _rb;
        [SerializeField, Category("Setup")] private Vector2 _offset;
        [SerializeField, Category("Setup")] private float _speed;
        
        private Entity[,] _enemies;
        private Vector2 _direction;
        private Vector2Int _remaining;

        private void Start()
        {
            _remaining.x = 11;
            _remaining.y = 5;
            _enemies = new Entity[5, 11];
            for (int i = 0; i < 5; ++i)
            {
                for (int j = 0; j < 11; ++j)
                {
                    Entity newEntity = Instantiate(_enemy, transform);
                    newEntity.transform.position = _spawnPoint.transform.position + new Vector3(1.0f * j * _offset.x, 1.0f * i * _offset.y * -1.0f, 0.0f);
                    _enemies[i,j] = newEntity;
                }
            }

            _direction = Vector2.right;
        }

        private void Update()
        {
            Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
            Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

            if (_direction == Vector2.right)
            {
                bool IsEnemy = false;
                for (int i = _remaining.x; i > 0; --i)
                {
                    if (IsEnemy)
                        break;

                    for (int j = 0; j < _remaining.y; ++j)
                    {

                    }
                }
            }
        }

        private IEnumerator DecideShooter()
        {
            yield return null;
        }
    }
}

