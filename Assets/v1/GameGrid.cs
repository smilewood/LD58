using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LD58.v1
{

   public class GameGrid : MonoBehaviour
   {
      private Dictionary<Vector2Int, GridCell> gridOfCells = new Dictionary<Vector2Int, GridCell>();

      // Start is called before the first frame update
      void Start()
      {

      }

      // Update is called once per frame
      void Update()
      {

      }

      public void AddCellToGrid(GridCell cellToAdd, Vector2Int gridposition)
      {
         gridOfCells[gridposition] = cellToAdd;
      }

      public List<GridCell> GetCellsInRow(int row)
      {
         return gridOfCells.Keys.Where(pos => pos.y == row).OrderBy(pos => pos.x).Select(key => gridOfCells[key]).ToList();
      }

      public List<GridCell> GetCellsInColumn(int col)
      {
         return gridOfCells.Keys.Where(pos => pos.x == col).OrderBy(pos => pos.y).Select(key => gridOfCells[key]).ToList();
      }
   }
}
