using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LD58.v1
{

   public class InitializeCell : MonoBehaviour
   {
      public List<GameObject> things;

      // Start is called before the first frame update
      void Start()
      {
         GameObject thing = Instantiate(things[Random.Range(0, things.Count)], this.transform.position, this.transform.rotation, GameObject.Find("ThingCollection").transform);
         GridCell thisCell = this.GetComponent<GridCell>();
         thing.GetComponent<ThingDragHandler>().targetCell = thisCell;
         thisCell.AssignedThing = thing;
      }
   }
}