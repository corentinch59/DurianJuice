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

        public void Hit(float amount)
        {
            _health.TakeDamage(amount);
        }
    }

}
