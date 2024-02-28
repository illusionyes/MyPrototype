
using UnityEngine;

public class UnitSpinner : Units
{
    [SerializeField] private GameObject spinner;
    [SerializeField] private float spinSpeed;
    private bool spinActive;
    private void Update()
    {
        InputMovement();
        this.UseAbility();
    }
    
    protected override void UseAbility()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Spin();
            spinActive = true;
        }
        else
        {
            spinActive = false;
        }
    }

    protected override void OnCollisionEnter(Collision other)
    {
        if (spinActive && other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        else
        {
            base.OnCollisionEnter(other);
        }
    }

    private void Spin()
    {
        spinner.transform.Rotate(0, spinSpeed * Time.deltaTime * unit_speed,0);
    }
}
