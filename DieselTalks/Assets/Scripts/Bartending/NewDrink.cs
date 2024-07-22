﻿using UnityEngine;

namespace Assets.Scripts.Bartending
{
    public class NewDrink : MonoBehaviour
    {
        public Texture drinkTexture;
        public Taste drinkTaste;
        public int drinkSensation { get; private set; }

        public void FinishDrink()
        {
            drinkSensation = DrinkManager.GetEffectIndex(drinkTexture, drinkTaste);

            switch (drinkSensation)
            {
                case 0:
                    break;

                case 1:
                    break;

                case 2: 
                    break;
                
                case 3: 
                    break;
                
                case 4: 
                    break;
                
                case 5: 
                    break;
                
                case 6: 
                    break;
                
                case 7: 
                    break;
                
                case 8: 
                    break;
                
                case 9: 
                    break;
                
                case 10: 
                    break;
                
                case 11: 
                    break;
                
                case 12: 
                    break;
                
                case 13: 
                    break;
                
                case 14:     
                    break;
                
                case 15: 
                    break;

                default: break;
            }

        }
    }

}