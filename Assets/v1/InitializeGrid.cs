using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace LD58.v1
{

   public class InitializeGrid : MonoBehaviour
   {
      public GameObject cellPrefab;
      public int RowCount;

      // Start is called before the first frame update
      void Start()
      {
         GameGrid grid = GetComponent<GameGrid>();
         for (int i = 0; i < RowCount; ++i)
         {
            for (int j = 0; j < GetComponent<GridLayoutGroup>().constraintCount; ++j)
            {
               GameObject cell = Instantiate(cellPrefab, this.transform);
               cell.name = $"Cell {j}, {i}";
               GridCell gridCellObject = cell.GetComponent<GridCell>();
               gridCellObject.CellPosition = new Vector2Int(j, i);
               grid.AddCellToGrid(gridCellObject, new Vector2Int(j, i));
            }
         }
      }

   }
}