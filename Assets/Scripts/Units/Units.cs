using UnityEngine;

public class Units : MonoBehaviour
{
   [SerializeField] protected GameObject bulletPrefab;
   public float speed;

   public float m_speed
   {
      get { return speed;}
      set { speed = value; }
   }

   protected virtual void InputMovement()
   {
      var vertical = Input.GetAxis("Vertical");
      var horizontal = Input.GetAxis("Horizontal");
      gameObject.transform.Translate(Vector3.forward * vertical * Time.deltaTime * speed);
      gameObject.transform.Translate(Vector3.right * horizontal * Time.deltaTime * speed);
   }

   protected virtual void UseAbility()
   {
      
   }
}
