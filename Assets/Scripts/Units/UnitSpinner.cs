using UnityEngine;
public class UnitSpinner : Units
{
    [SerializeField] private GameObject spinner;
    [SerializeField] private float spinSpeed;
    private bool spinActive;

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
        spinner.transform.Rotate(0, spinSpeed * Time.deltaTime * unitSpeed,0);
    }

    protected override void OnCollisionEnter(Collision other)
    {
        if (spinActive && other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            ++MainUi.scoreUi;
            MainUi.SetScoreText(MainUi.scoreUi);
        }
        else
        {
            base.OnCollisionEnter(other);
        }
    }
}
