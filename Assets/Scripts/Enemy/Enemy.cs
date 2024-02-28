using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        gameObject.transform.Translate(Vector3.back *(speed * Time.deltaTime));
    }
}
