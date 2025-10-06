using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smokepuffer : MonoBehaviour
{
   public float rate;
   public GameObject puff;

   private void Start()
   {
      StartCoroutine(PuffCycle());
   }
   private IEnumerator PuffCycle()
   {
      while (true)
      {
         Instantiate(puff, this.transform.position, Quaternion.identity, this.transform.parent.parent);
         yield return new WaitForSeconds(rate);
      }
   }
}
