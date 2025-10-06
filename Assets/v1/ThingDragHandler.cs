using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace LD58.v1
{

   public class ThingDragHandler : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler
   {
      bool dragging = false;
      public GridCell targetCell;
      private GridCell startingCell;
      public Vector2 targetposition;
      public float snapSrtength;
      // Start is called before the first frame update
      void Start()
      {
      }

      int started = -1;

      // Update is called once per frame
      void Update()
      {
         if (started < 1)
         {
            targetposition = targetCell.transform.position;
            ++started;
         }

         this.transform.position = Vector2.Lerp(this.transform.position, targetposition, Time.deltaTime * snapSrtength);
      }

      public void OnBeginDrag(PointerEventData eventData)
      {
         dragging = true;
         this.transform.SetAsLastSibling();
         startingCell = targetCell;
      }

      public void OnDrag(PointerEventData eventData)
      {
         if (dragging)
         {
            targetposition = eventData.position;
         }
      }

      public void OnEndDrag(PointerEventData eventData)
      {
         //Handle dropping properly
         if (dragging)
         {
            dragging = false;
            targetposition = targetCell.transform.position;
         }
      }

      public void OnPointerEnter(PointerEventData eventData)
      {
         GridCellMouseHandler.CurrentGridMousePos = targetCell.CellPosition;
         Debug.Log($"Drag over thing {targetCell.CellPosition}");
      }
   }
}