using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineUpgrades : MonoBehaviour
{
   MineColtroller[] mines;

   // Start is called before the first frame update
   void Start()
   {
      mines = this.transform.GetComponentsInChildren<MineColtroller>(true);
   }

   public void ChangeMineSpeed(float newSpeed)
   {
      foreach(MineColtroller mine in mines)
      {
         mine.MineFillTime = newSpeed;
      }
   }

   public void ChangeDeliveryAmound(int newAmmount)
   {
      foreach(MineColtroller mine in mines)
      {
         mine.MineDeliveryAmmount = newAmmount;
      }
   }

   public void ChangeTrainSpeed(float newSpeed)
   {
      foreach (MineColtroller mine in mines)
      {
         mine.TrainSpeed = newSpeed;
      }
   }

   public void EnableAutoDispatch()
   {
      foreach(MineColtroller mine in mines)
      {
         mine.AutoDispatch.SetActive(true);
      }
   }

   public void ChangeAutoDispatchRate(float newRate)
   {
      foreach (MineColtroller mine in mines)
      {
         mine.AutoDispatch.GetComponent<AutoDispatch>().DispatchTimer = newRate;
      }
   }
}
