using UnityEngine;
public class UnitSpinner : Units
{
    [SerializeField] private GameObject spinner;
    [SerializeField] private float spinSpeed;
    private bool spinActive;

    public static bool isChoosed;

    private void FixedUpdate()
    {
        if (isChoosed == false)
        {
            StopAllCoroutines();
        }
    }
    protected override void UseAbilityOnButton()
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

    protected override void UseAbility()
    {
        Spin();
    }
    
    private void Spin()
    {
        spinner.transform.Rotate(0, spinSpeed * Time.deltaTime * unit_speed,0);
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

    public void OnChooseSpin()
    {
        UnitTurret.isChoosed = false;
        UnitSphere.isChoosed = false;
        isChoosed = true;
        StartCoroutine(AbilityCoroutine(isChoosed,0));
    }
}
