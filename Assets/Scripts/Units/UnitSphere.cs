using UnityEngine;

public class UnitSphere : Units
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject[] points;
    
    public static bool isChoosed;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (isChoosed == false)
        {
            StopAllCoroutines();
        }
    }
    protected override void InputMovement()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        rb.AddRelativeForce(Vector3.forward * (vertical * unit_speed * Time.deltaTime), ForceMode.Impulse);
        rb.AddRelativeForce(Vector3.right * (horizontal * unit_speed * Time.deltaTime), ForceMode.Impulse);
    }
    protected override void UseAbility()
    {
        for (int i = 0; i < points.Length; i++)
        {
            Instantiate(bulletPrefab, points[i].transform.position, points[i].transform.rotation);
        }
    }
    
    public void OnChooseSpin()
    {
        UnitTurret.isChoosed = false;
        UnitSpinner.isChoosed = false;
        isChoosed = true;
        StartCoroutine(AbilityCoroutine(isChoosed,1));
    }
}
