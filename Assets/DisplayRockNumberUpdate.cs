using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class DisplayRockNumberUpdate : MonoBehaviour
{
   TMP_Text numberText;

   // Start is called before the first frame update
   void Start()
   {
      numberText = this.gameObject.GetComponent<TMP_Text>();
   }

   // Update is called once per frame
   void Update()
   {
      numberText.text = Collection.Instance.ThingsCollected.ToString();
   }
}
