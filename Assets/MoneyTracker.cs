using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class MoneyTracker : MonoBehaviour
{
   public float TotalMoney;
   public float MoneyPerRockPerSec;
   public float MoneyUPS;
   public InputActionAsset actions;

   public static MoneyTracker Instance
   {
      get
      {
         return instance;
      }
   }
   private static MoneyTracker instance;

   // Start is called before the first frame update
   void Start()
   {
      if (instance == null)
      {
         instance = this;
      }
      StartCoroutine(MoneyTick());
      ControlMapping temp = new ControlMapping();
      temp.@default.GiveMoney.performed += (_) => AddMoney(1000000);
      temp.@default.GiveMoreMoney.performed += (_) => AddMoney(1000000000);
      temp.@default.Enable();
   }

   // Update is called once per frame
   void Update()
   {
   }

   IEnumerator MoneyTick()
   {
      while (true)
      {
         float RandomDelay = UnityEngine.Random.Range(-.25f, .75f);
         float delay = RandomDelay + (1f / MoneyUPS);
         yield return new WaitForSeconds(delay);
         TotalMoney += MoneyPerRockPerSec * Collection.Instance.ThingsCollected * delay;
      }
   }

   public void SetMoneyPerTick(float newAmount)
   {
      MoneyPerRockPerSec = newAmount;
   }

   public void AddMoney(float amount) 
   {
      TotalMoney += amount;
   }
}
