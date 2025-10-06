using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ThingCollectedEvent : UnityEvent<Collection.TypeOfThing, int> {}

public class Collection : MonoBehaviour
{
   public enum TypeOfThing
   {
      PickupFromGround,
      BuyInStore,
      Mine,
   }

   public static ThingCollectedEvent ThingCollected = new ThingCollectedEvent();
   public static Collection Instance
   {
      get
      {
         return instance;
      }
   }
   private static Collection instance;

   public int ThingsCollected
   {
      get; private set;
   }

   // Start is called before the first frame update
   void Start()
   {
      if(instance == null)
      {
         instance = this;
         ThingCollected.AddListener(HandleThingCollected);
      }
   }
   private int pickupMult = 1;
   void HandleThingCollected(TypeOfThing typeOfThing, int numberPickedUp)
   {
      switch (typeOfThing)
      {
         case TypeOfThing.PickupFromGround:
         {
            ThingsCollected += numberPickedUp * pickupMult;
            break;
         }
         case TypeOfThing.Mine:
         {
            ThingsCollected += numberPickedUp;
            break;
         }
      }
   }

   public void SetPickupMult(int mult)
   {
      pickupMult = mult;  
   }
}
