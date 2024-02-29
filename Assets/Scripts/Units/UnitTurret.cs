using UnityEngine;

public class UnitTurret : Units
{
    [SerializeField] private GameObject gun;
    
    public static bool isChoosed;
    
    private void FixedUpdate()
    {
        if (isChoosed == false)
        {
           StopAllCoroutines();
        }
    }

    protected override void InputMovement()
    {
        var horizontal = Input.GetAxis("Horizontal");
        gameObject.transform.Rotate(0,horizontal * unit_speed * Time.deltaTime,0);
    }

    protected override void UseAbility()
    {
         Instantiate(bulletPrefab, gun.transform.position, gameObject.transform.rotation);
    }
    public void OnChooseSpin()
    {
        UnitSpinner.isChoosed = false;
        UnitSphere.isChoosed = false;
        isChoosed = true;
        StartCoroutine(AbilityCoroutine(isChoosed,1));
        
    }
}
