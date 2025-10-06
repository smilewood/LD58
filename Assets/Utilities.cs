using System.Collections;
using Unity.Mathematics;
using UnityEngine;


public class Utilities
{
   private static string[] numberSuffixes = { "", "k", "M", "G", "T", "P", "E", "Z", "Y"};

   public static string FormatNumber(float number, bool decemil)
   {
      int mag = 0;
      if(number < 10000)
      {
         if (decemil)
         {
            return $"{number:0.00}";
         }
         else
         {
            return $"{number:0}";
         }
      }
      if (number > 100000)
      {
         while (number > 1000)
         {
            ++mag;
            number /= 1000;
         }
      }
      mag = math.min(mag, numberSuffixes.Length-1);
      if (decemil)
      {
         return $"{number:0.00}{numberSuffixes[mag]}";
      }
      else
      {
         return $"{number:0}{numberSuffixes[mag]}";
      }
   }
}
