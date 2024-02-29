using System;
using UnityEngine;

public class Units : MonoBehaviour
{
   [SerializeField] protected GameObject bulletPrefab;
   [SerializeField] protected GameObject mainUiGo;

   [SerializeField] private float zTopBound;
   [SerializeField] private float zBottomBound;
   [SerializeField] private float speed;

   public float unit_speed
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

   protected void CheckZBounds()
   {
      var zPos = gameObject.transform.position.z;
      if (zPos > zTopBound)
      {
         zPos = zTopBound;
      }
      else if (zPos < zBottomBound)
      {
         zPos = zBottomBound;
      }
      gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,zPos);
   }

   protected virtual void OnCollisionEnter(Collision other)
   {
      if (other.gameObject.CompareTag("Enemy"))
      {
         mainUiGo.GetComponent<MainUi>().GameOver();
         Destroy(this.gameObject);
      }
   }
}
