using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanelTabs : MonoBehaviour
{
   public List<Button> buttons;
   public string StartingTabName;

   private void Start()
   {
      buttons = new List<Button>();
      foreach (Transform child in this.transform)
      {
         if (child.GetComponent<Button>() is Button button)
         {
            buttons.Add(button);
         }
      }
      SetButtonStates(StartingTabName);
   }

   public void SetButtonStates(string buttonName)
   {
      foreach (Button b in buttons)
      {
         bool enable = b.gameObject.name == buttonName;
         b.interactable = !enable;
         foreach(Transform child in b.transform)
         {
            if (child.gameObject.CompareTag("Panel"))
            {
               child.gameObject.SetActive(true);
               CanvasGroup canvas = child.GetComponent<CanvasGroup>();
               canvas.alpha = enable ? 1 : 0;
               canvas.interactable = enable;
               canvas.blocksRaycasts = enable;
            }
         }
      }
   }
}
