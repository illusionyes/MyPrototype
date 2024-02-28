using UnityEngine;

public class UnitSphere : Units
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject[] points;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        InputMovement();
        this.UseAbility();
    }
    protected override void InputMovement()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        rb.AddRelativeForce(Vector3.forward * vertical * speed * Time.deltaTime, ForceMode.Impulse);
        rb.AddRelativeForce(Vector3.right * horizontal * speed * Time.deltaTime, ForceMode.Impulse);
    }
    protected override void UseAbility()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < points.Length; i++)
            {
                Instantiate(bulletPrefab, points[i].transform.position, points[i].transform.rotation);
            }
        }
    }
}
