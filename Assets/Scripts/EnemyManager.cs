using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace Durian
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField, BoxGroup("Reference")] private Bullet _bullet;

        [SerializeField, BoxGroup("Prefab")] private Entity _enemy;

        [SerializeField, BoxGroup("Reference")] private Rigidbody2D _rb;
        [SerializeField, BoxGroup("Depandances")] private MusicSyncManager _musicSync;

        [SerializeField, BoxGroup("Setup")] private Vector2 _spawnOffset;
        [SerializeField, BoxGroup("Setup")] private float _speed;
        [SerializeField, BoxGroup("Setup")] private float _downOffset;
        [SerializeField, BoxGroup("Setup")] private float _sideOffset;
        [SerializeField, BoxGroup("Setup")] private float _attackRate;

        private Vector2 _entities = new Vector2(5,11);
        private int NbEntities => (int)_entities.x * (int)_entities.y;
        private int _nbEntitiesDead;
        private int _nbEntitiesAlive => NbEntities - _nbEntitiesDead;

        private Vector2 _direction;
        private Vector3 _leftEdge;
        private Vector3 _rightEdge;
        private Vector3 _enemyStop;

        private void Start()
        {
            _leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
            _rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
            _enemyStop = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 0.5f,0.0f));

            for (int i = 0; i < 5; ++i)
            {
                for (int j = 0; j < 11; ++j)
                {
                    Entity newEntity = Instantiate(_enemy, transform);
                    newEntity.transform.position = transform.position + new Vector3(1.0f * j * _spawnOffset.x, 1.0f * i * _spawnOffset.y * -1.0f, 0.0f);
                    newEntity.Health.OnDie += EntityDied;
                    int luck = Random.Range(0, 3);
                    Debug.Log(luck);
                    if(luck==1)
                        MusicSyncManager.Instance.AddObjectChildToBeat(newEntity.gameObject);
                }
            }
            _direction = Vector2.right;
            _rb.velocity = _direction * _speed;

            InvokeRepeating(nameof(EnemyShoot), _attackRate, _attackRate);
        }

        private void Update()
        {
            foreach (Transform entity in transform)
            {
                if (_direction == Vector2.left && entity.transform.position.x <= _leftEdge.x + _sideOffset)
                {
                    ChangeDirection();
                }
                else if (_direction == Vector2.right && entity.transform.position.x >= _rightEdge.x - _sideOffset)
                {
                    ChangeDirection();
                }
            }

        }

        private void ChangeDirection()
        {
            if (transform.position.y > _enemyStop.y)
                transform.position -= new Vector3(0.0f, _downOffset, 0.0f);

            _direction.x *= -1.0f;
            _rb.velocity = _direction * _speed;
        }

        private void EnemyShoot()
        {
            foreach (Transform entity in transform)
            {
                if (Random.value < (1.0f / _nbEntitiesAlive))
                {
                    Bullet bullet = Instantiate(_bullet, entity.position, Quaternion.identity);
                    bullet.InitBullet(new Vector2(0.0f, -1.0f));
                    bullet.Owner = gameObject;
                }
            }
        }

        private void EntityDied()
        {
            _nbEntitiesDead++;
        }
    }
}

