using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineColtroller : MonoBehaviour
{
   [Header("Fill")]
   public Image FillCircle;
   public float MineFillTime;
   public Button DispatchButton;

   [Header("Train")]
   public GameObject TrainPrefab;
   public float TrainSpeed;
   public Transform TrainStart, TrainEnd;
   public GameObject AutoDispatch;

   [Header("delivery")]
   public int MineDeliveryAmmount;

   private float MineFillPercent;

   // Start is called before the first frame update
   void Start()
   {

   }

   public bool TrainCanDispatch
   {
      get
      {
         return MineFillPercent >= 100;
      }
   }

   // Update is called once per frame
   void Update()
   {
      if (MineFillPercent < 100)
      {
         MineFillPercent += (60 / MineFillTime) * Time.deltaTime;
      }
      FillCircle.fillAmount = MineFillPercent / 100;
      DispatchButton.interactable = TrainCanDispatch;
   }

   public void DispatchTrain()
   {
      if (TrainCanDispatch)
      {
         MineTrain train = Instantiate(TrainPrefab, TrainStart.position, Quaternion.identity, this.transform).GetComponent<MineTrain>();
         train.destination = TrainEnd;
         train.OnTrainArrive.AddListener(() => Collection.ThingCollected.Invoke(Collection.TypeOfThing.Mine, MineDeliveryAmmount));
         train.speed = TrainSpeed;
         MineFillPercent = UnityEngine.Random.Range(-MineFillTime/10, MineFillTime/10);
      }
   }
}
