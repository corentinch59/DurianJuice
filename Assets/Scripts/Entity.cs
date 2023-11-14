using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Durian
{
    public class Entity : MonoBehaviour, IHitable
    {
        [FormerlySerializedAs("_health")][SerializeField, Required("Health script Required")] Health _health;

        [SerializeField] private Bullet _bullet;

        public void Hit(float amount)
        {
            _health.TakeDamage(amount);
        }
        public void ShootBullet()
        {
            Bullet bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
            bullet.InitBullet(new Vector2(0.0f, -1.0f));
            bullet.Owner = gameObject;
        }
    }

}
