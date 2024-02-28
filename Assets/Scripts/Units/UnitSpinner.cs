
using UnityEngine;

public class UnitSpinner : Units
{
    [SerializeField] private GameObject spinner;
    [SerializeField] private float spinSpeed;
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
        }
    }
    private void Spin()
    {
        spinner.transform.Rotate(0, spinSpeed * Time.deltaTime * speed,0);
    }
}
