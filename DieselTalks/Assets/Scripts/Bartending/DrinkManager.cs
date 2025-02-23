﻿using System;
using UnityEngine;

namespace Assets.Scripts.Bartending
{
    [System.Serializable]
    public enum Texture { smooth, rough, creamy, dry }
    [System.Serializable]
    public enum Taste { sour, bitter, sweet, salty }

    public class DrinkManager : MonoBehaviour
    {

    //Propriedades
        public static Texture GetTexture => CurrentDrink.drinkTexture;

        public static Taste GetTaste => CurrentDrink.drinkTaste;

        [SerializeField] private DrinkMix drink;
        
        public static DrinkMix CurrentDrink { get; private set; }

        private static int[,] EffectIndices
        {
            get
            {
                int
                    textureLength = Enum.GetValues(typeof(Texture)).Length,
                    tasteLength = Enum.GetValues(typeof(Taste)).Length;

                int[,] array = new int[textureLength, tasteLength];

                int index = 0;
                for (int texture = 0; texture < textureLength; texture++) //x
                {
                    for (int taste = 0; taste < tasteLength; taste++) //y
                    {
                        array[texture, taste] = index;
                        index++;
                    }
                }
                return array;
            }
        }

        /// <summary>
        /// (sour; bitter; sweet; salty)
        /// <list type="table">
        ///     <listheader>
        ///         <term>so</term>
        ///         <term>bit</term>
        ///         <term>sw</term>
        ///         <term>sa</term>
        ///     </listheader>
        ///     <item>
        ///         <term>00</term>
        ///         <term>01</term>
        ///         <term>02</term>
        ///         <term>03</term>
        ///         <term>smooth</term>
        ///     </item>
        ///     <item>
        ///         <term>04</term>
        ///         <term>05</term>
        ///         <term>06</term>
        ///         <term>07</term>
        ///         <term>rough</term>
        ///     </item>
        ///     <item>
        ///         <term>08</term>
        ///         <term>09</term>
        ///         <term>10</term>
        ///         <term>11</term>
        ///         <term>creamy</term>
        ///     </item>
        ///     <item>
        ///         <term>12</term>
        ///         <term>13</term>
        ///         <term>14</term>
        ///         <term>15</term>
        ///         <term>dry</term>
        ///     </item>
        /// </list>
        /// </summary>
        public static int GetEffectIndex(Texture tex, Taste tas) => EffectIndices[(int)tex, (int)tas];


    //Setter
        public static void SetCurrentDrinkTexture(Texture tex) => CurrentDrink.drinkTexture = tex;

        public static void SetCurrentDrinkTaste(Taste tas) => CurrentDrink.drinkTaste = tas;
        
    //Metodos MonoBehaviour
        private void Start()
        { 
            CurrentDrink = drink;
        }
    }
}