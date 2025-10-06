using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CityCollectableSpawnner : MonoBehaviour
{
   public List<CityStore> Stores;
   public float StoreAvailabilityCooldown;

   // Start is called before the first frame update
   void Start()
   {
      Stores = this.transform.GetComponentsInChildren<CityStore>().ToList();
      StartCoroutine(StoreCycle());
   }

   public IEnumerator StoreCycle()
   {
      while (true)
      {
         float delay = StoreAvailabilityCooldown + (StoreAvailabilityCooldown * .3f * UnityEngine.Random.Range(-1f, 1f));
         //Debug.Log(delay);
         yield return new WaitForSeconds(delay);
         IList<CityStore> readyStores = Stores.Where(store => store.StoreReady).ToList();
         if (readyStores.Any())
         {
            readyStores[UnityEngine.Random.Range(0, readyStores.Count)].SpawnPickup();
         }
      }
   }

   public void SetSpawnrate(float cooldown)
   {
      StoreAvailabilityCooldown = cooldown;
   }
}
