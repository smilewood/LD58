using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetStoreRateOnClick : MonoBehaviour
{
   public float newRate;
   private CityCollectableSpawnner spawnner;

   // Start is called before the first frame update
   void Start()
   {
      spawnner = this.transform.parent.GetComponent<CityCollectableSpawnner>();
      this.GetComponentInChildren<Button>().onClick.AddListener(SetNewRate);
   }

   public void SetNewRate()
   {
      spawnner.SetSpawnrate(newRate);
   }
}
