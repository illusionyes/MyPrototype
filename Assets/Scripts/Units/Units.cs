using UnityEngine;
using System.Collections;

public class Units : MonoBehaviour
{
   [SerializeField] protected GameObject bulletPrefab;
   [SerializeField] private float zTopBound;
   [SerializeField] private float zBottomBound;
   [SerializeField] private float speed;
  
   public static bool isDemo;
   private static Coroutine coroutine;
   public float unitSpeed
   {
      get { return speed; }
      private set {
         if (value < 0.0f)
         {
            Debug.Log("Fail");
         }
         else
         {
            speed = value;
         }
      }
   }
   
   protected void Update()
   {
      if (isDemo == false)
      {
         InputMovement();
         UseAbilityOnButton();
         CheckZBounds();
      }
   }

   protected virtual void InputMovement()
   {
      if (isDemo == false)
      {
         var vertical = Input.GetAxis("Vertical");
         var horizontal = Input.GetAxis("Horizontal");
         gameObject.transform.Translate(Vector3.forward * (vertical * Time.deltaTime * speed));
         gameObject.transform.Translate(Vector3.right * (horizontal * Time.deltaTime * speed));
      }
   }
   
   protected virtual void UseAbility()
   {
      
   }
   
   private IEnumerator AbilityCoroutine(float repeatTime)
   {
      while (true)
      {
         UseAbility();
         yield return new WaitForSeconds(repeatTime);
      }
   }

   private void Stop()
   {
      StopCoroutine(coroutine);
   }

   protected virtual void UseAbilityOnButton()
   {
      if (Input.GetKeyDown(KeyCode.Space))
      {
         UseAbility();
      }
   }
   
   public void OnChoose(int rep)
   {
      if (coroutine != null)
      {
         Stop();
      }
      coroutine = StartCoroutine(AbilityCoroutine(rep));
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
         MainUi.mainUi.GameOver();
         if (MainUi.scoreUi > DataManager.Instance.bestScore)
         {
            DataManager.Instance.bestScore = MainUi.scoreUi;
         }
         Destroy(this.gameObject);
      }
   }
}
