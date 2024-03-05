using UnityEngine;

public class UnitTurret : Units
{
    [SerializeField] private GameObject gun;
    
    protected override void InputMovement()
    {
        var horizontal = Input.GetAxis("Horizontal");
        gameObject.transform.Rotate(0,horizontal * unitSpeed * Time.deltaTime,0);
    }

    protected override void UseAbility()
    {
         Instantiate(bulletPrefab, gun.transform.position, gameObject.transform.rotation);
    }
}
