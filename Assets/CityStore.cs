using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityStore : MonoBehaviour
{
   public GameObject CollectablePrefab;
   public float SpawnRadius;

   public int MaxThings;
   public float SpawnnedThings;
   public bool StoreReady { get { return SpawnnedThings < MaxThings; } }

   public bool SpawnPickup()
   {
      if (StoreReady)
      {
         Vector2 spawnLocation = Random.insideUnitCircle * SpawnRadius;
         GameObject newPickup = Instantiate(CollectablePrefab, this.transform.position, Quaternion.identity, this.transform);
         newPickup.GetComponent<Button>().onClick.AddListener(() => --this.SpawnnedThings);
         newPickup.GetComponent<MoveToLocation>().TargetLocation = this.transform.position + new Vector3(spawnLocation.x, spawnLocation.y, 0);
         SpawnnedThings = SpawnnedThings >= 0 ? ++SpawnnedThings : 1;
         return true;
      }
      return false;
   }

   public void SetMaxThings(int number)
   {
      MaxThings = number;
   }
}
