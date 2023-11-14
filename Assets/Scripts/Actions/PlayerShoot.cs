using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace Durian.Actions
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField, BoxGroup("Prefab")] private Bullet _bullet;

        public void ShootBullet()
        {
            Bullet bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
            bullet.InitBullet(new Vector2(0.0f, 1.0f));
        }
    }
}
