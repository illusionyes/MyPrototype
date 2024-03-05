using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float force;
    
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
                var score = ++MainUi.scoreUi;
                Destroy(other.gameObject);
                MainUi.SetScoreText(score);
            }
            Destroy(this.gameObject);
        }
    }
}
