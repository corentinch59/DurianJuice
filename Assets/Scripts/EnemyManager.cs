using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Durian
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField, Category("Prefab")] private Entity _enemy;
        [SerializeField, Category("Reference")] private Rigidbody2D _rb;
        [SerializeField, Category("Setup")] private Vector2 _spawnOffset;
        [SerializeField, Category("Setup")] private float _speed;
        [SerializeField, Category("Setup")] private float _offset;
        
        private Entity[,] _enemies;
        private Vector2 _direction;
        private float _cooldown;

        private void Start()
        {
            _enemies = new Entity[5, 11];
            for (int i = 0; i < 5; ++i)
            {
                for (int j = 0; j < 11; ++j)
                {
                    Entity newEntity = Instantiate(_enemy, transform);
                    newEntity.transform.position = transform.position + new Vector3(1.0f * j * _spawnOffset.x, 1.0f * i * _spawnOffset.y * -1.0f, 0.0f);
                    _enemies[i,j] = newEntity;
                }
            }

            _direction = Vector2.right;
            _rb.velocity = _direction * _speed;
        }

        private void Update()
        {
            Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
            Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

            foreach (Transform entity in transform)
            {
                if (_direction == Vector2.left && entity.transform.position.x <= leftEdge.x )
                {
                    ChangeDirection();
                }
                else if (_direction == Vector2.right && entity.transform.position.x >= rightEdge.x )
                {
                    ChangeDirection();
                }
            }
        }

        private void ChangeDirection()
        {
            transform.position -= new Vector3(0.0f, _offset, 0.0f);
            _direction.x *= -1.0f;
            _rb.velocity = _direction * _speed;
        }

    }
}

