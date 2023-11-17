using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorOnSpawn : MonoBehaviour
{
    private SpriteRenderer _sr;
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _sr.material.SetFloat("_HsvShift", Random.Range(0,360));
    }

}
