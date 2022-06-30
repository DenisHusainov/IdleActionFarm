using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameWindow : Window
{
   [SerializeField]
   private TextMeshPro _maxCountBlocks = null;
   [SerializeField] 
   private TextMeshPro _currentCountBlocks = null;


   private void OnEnable()
   {
      PlayerController.Sold += PlayerController_Sold;
      Harvest.TookTheGrass += Harvest_TookTheGrass;
   }

   private void OnDisable()
   {
      PlayerController.Sold -= PlayerController_Sold;
      Harvest.TookTheGrass -= Harvest_TookTheGrass;
   }
   
   private void PlayerController_Sold()
   {
      _currentCountBlocks.text = 0.ToString();
   }
   
   private void Harvest_TookTheGrass()
   {
      // _currentCountBlocks.text = Harvest._countBlocks.ToString();
   }
}
