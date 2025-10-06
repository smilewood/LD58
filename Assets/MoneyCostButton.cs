using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MoneyCostButton : MonoBehaviour
{
   public TMP_Text CostText;
   public float Cost;
   private Button button;

   // Start is called before the first frame update
   void Start()
   {
      button = GetComponent<Button>();
      CostText.text = Utilities.FormatNumber(Cost, false);
   }

   // Update is called once per frame
   void Update()
   {
      button.interactable = MoneyTracker.Instance.TotalMoney >= Cost;
   }

   public void BuyThis()
   {
      MoneyTracker.Instance.TotalMoney -= Cost;
   }
}
