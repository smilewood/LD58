using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CityCollector : MonoBehaviour
{
   GameObject targetPickup;

   public float speed;

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      if(targetPickup == null)
      {
         //try and find a new target
         List<GameObject> pickups = transform.parent.GetComponentsInChildren<ClickableCollectable>().Select(ter => ter.gameObject).ToList();
         if (pickups.Any())
         {
            targetPickup = pickups[Random.Range(0, pickups.Count)];
            targetPickup.GetComponent<Button>().onClick.AddListener(() => this.targetPickup = null);
         }
      }

      if (targetPickup != null)
      {
         //move towards the target
         Vector3 vector = (targetPickup.transform.position - this.transform.position).normalized * speed;

         this.transform.position += vector * Time.deltaTime;
         this.transform.rotation = Quaternion.AngleAxis((Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg) - 90, Vector3.forward);

         if (Vector3.Distance(this.transform.position, targetPickup.transform.position) < (speed * Time.deltaTime))
         {
            targetPickup.GetComponent<Button>().onClick.Invoke();
         }
      }


   }

   public void SetSpeed(float newSpeed)
   {
      speed = newSpeed;
   }
}
