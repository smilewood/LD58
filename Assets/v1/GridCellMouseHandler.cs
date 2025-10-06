using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace LD58.v1
{

   public class GridCellMouseHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
   {
      private GridCell thisCell;
      public static Vector2Int CurrentGridMousePos;

      // Start is called before the first frame update
      void Start()
      {
         GetComponentInChildren<TMP_Text>().text = this.gameObject.name;
         thisCell = GetComponent<GridCell>();
      }

      // Update is called once per frame
      void Update()
      {

      }

      public void OnPointerEnter(PointerEventData eventData)
      {
         CurrentGridMousePos = thisCell.CellPosition;
         Debug.Log($"Drag over {thisCell.CellPosition}");
      }

      public void OnPointerExit(PointerEventData eventData)
      {
      }

      public void OnPointerMove(PointerEventData eventData)
      {
         if (eventData.hovered.Contains(this.gameObject) && !(CurrentGridMousePos == thisCell.CellPosition))
         {
            CurrentGridMousePos = thisCell.CellPosition;
            Debug.Log($"Pointer over {thisCell.CellPosition}");
         }
      }
   }
}
