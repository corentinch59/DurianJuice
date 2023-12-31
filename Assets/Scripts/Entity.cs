using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Durian
{
    public class Entity : MonoBehaviour, IHitable
    {
        [FormerlySerializedAs("_health")][SerializeField, Required("Health script Required")] Health _health;

        public Health Health => _health;

        public int beatIndex { get; set; }
        public bool isBeating { get; set; }
        public void Hit(int amount)
        {
            _health.TakeDamage(amount);
        }

        public void DestroyObject()
        {
            Destroy(gameObject);
            if(isBeating)
                MusicSyncManager.Instance.RemoveObjectChildToBeat(gameObject);
        }

    }
}
