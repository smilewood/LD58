using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ClickableCollectable : MonoBehaviour
{
   public int NumberHere;
   // Start is called before the first frame update
   void Start()
   {
      GetComponent<Button>().onClick.AddListener(OnCollected);
   }

   void OnCollected()
   {
      Collection.ThingCollected.Invoke(Collection.TypeOfThing.PickupFromGround, NumberHere);
      Destroy(this.gameObject);
   }
}
