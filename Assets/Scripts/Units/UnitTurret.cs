using UnityEngine;

public class UnitTurret : Units
{
    [SerializeField] private GameObject gun;
    private void Update()
    {
        this.InputMovement();
        this.UseAbility();
    }

    protected override void InputMovement()
    {
        var horizontal = Input.GetAxis("Horizontal");
        gameObject.transform.Rotate(0,horizontal * unit_speed * Time.deltaTime,0);
    }

    protected override void UseAbility()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, gun.transform.position, gameObject.transform.rotation);
        }
    }
}
