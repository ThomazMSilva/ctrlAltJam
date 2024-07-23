using System;
using UnityEngine;

namespace Assets.Scripts.Bartending
{
    [System.Serializable]
    public enum Texture { smooth, rough, creamy, dry }
    [System.Serializable]
    public enum Taste { sour, bitter, sweet, salty }

    public class DrinkManager : MonoBehaviour
    {
        public static Texture GetTexture => currentDrink.drinkTexture;

        public static Taste GetTaste => currentDrink.drinkTaste;

        
        [SerializeField] private NewDrink[] drinks;
        
        public static NewDrink currentDrink;

        public static void SetCurrentDrinkTexture(Texture tex) => currentDrink.drinkTexture = tex;

        public static void SetCurrentDrinkTaste(Taste tas) => currentDrink.drinkTaste = tas;

        /*private static readonly int[,] effectIndices = new int[,]
        {
            { 0, 1, 2, 3 },  // smooth
            { 4, 5, 6, 7 },  // rough
            { 8, 9, 10, 11 },// creamy
            { 12, 13, 14, 15}// dry
        };*/

        private static int[,] EffectIndices
        {
            get
            {
                int
                    textureLength = Enum.GetValues(typeof(Texture)).Length,
                    tasteLength = Enum.GetValues(typeof(Taste)).Length;

                int[,] array = new int[textureLength, tasteLength];

                int index = 0;
                for (int y = 0; y < tasteLength; y++)
                {
                    for (int x = 0; x < textureLength; x++)
                    {
                        array[x, y] = index;
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

        private void Start()
        {
            UpdateCurrentDrink();
            currentDrink.gameObject.SetActive(true);
        }

        private void OnEnable()
        {
            LevelManager.Instance.OnLevelUp += UpdateCurrentDrink;
        }

        private void OnDisable()
        {
            LevelManager.Instance.OnLevelUp -= UpdateCurrentDrink;
        }

        public void UpdateCurrentDrink()
        {
            currentDrink = drinks[LevelManager.Instance.level];
        }
    }
}