using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;

        public int level = 0;

        public void IncreaseLevel() => level++;

        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
    }
}