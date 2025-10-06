using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class smokepuff : MonoBehaviour
{
   public float lifetimeBase;
   public float lifetimemod;

   private float lifetimeRemaining;
   private Vector3 vector;
   private Image image;
   // Start is called before the first frame update
   void Start()
   {
      image = GetComponent<Image>();
      lifetimeRemaining = lifetimeBase + (lifetimemod * Random.Range(-1, 1));
      vector = new Vector3(Random.Range(-10, 10), Random.Range(10, 25), 0);
   }

   // Update is called once per frame
   void Update()
   {
      if (lifetimeRemaining < 0)
      {
         Destroy(this.gameObject);
      }
      lifetimeRemaining -= Time.deltaTime;
      this.transform.position = this.transform.position + vector * Time.deltaTime;
      Color c = image.color;
      c.a = lifetimeRemaining / lifetimeBase;
      image.color = c;
   }
}
