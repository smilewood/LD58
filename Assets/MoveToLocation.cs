using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToLocation : MonoBehaviour
{
   public Vector3 TargetLocation;
   public float speed;

   // Update is called once per frame
   void Update()
   {
      if(TargetLocation != null && Vector3.Distance(this.transform.position, TargetLocation) > .1f)
      {
         this.transform.position = Vector3.Slerp(this.transform.position, TargetLocation, speed * Time.deltaTime);
      }
      else
      {
         this.enabled = false;
      }
   }
}
