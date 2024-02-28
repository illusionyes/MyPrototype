using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float force;
    private void Start()
    {
        var rb = gameObject.GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.right * force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.collider.CompareTag("Bullet"))
        {
            if (other.collider.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
