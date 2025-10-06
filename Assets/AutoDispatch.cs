using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDispatch : MonoBehaviour
{
   public float DispatchTimer;
   public MineColtroller mine;

   void Start()
   {
      StartCoroutine(DispatchCycle());
   }

   public IEnumerator DispatchCycle()
   {
      while (true)
      {
         yield return new WaitForSeconds(DispatchTimer);
         mine.DispatchTrain();
      }
   }
}
