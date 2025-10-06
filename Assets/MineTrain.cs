using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MineTrain : MonoBehaviour
{
   public Transform destination;
   public float speed;
   public UnityEvent OnTrainArrive = new UnityEvent();

   // Update is called once per frame
   void Update()
   {
      Vector3 vector = (destination.position - this.transform.position).normalized * speed;

      this.transform.position += vector * Time.deltaTime;

      if (Vector3.Distance(this.transform.position, destination.position) < (speed * Time.deltaTime))
      {
         OnTrainArrive.Invoke();
         Destroy(this.gameObject);
      }
   }
}
