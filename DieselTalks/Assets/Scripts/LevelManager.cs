using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class LevelManager : MonoBehaviour, IDataHandler
    {
        public static LevelManager Instance;

        public int level = 0;

        public delegate void LevelUp();
        public event LevelUp OnLevelUp;

        public void IncreaseLevel()
        {
            level++;
            OnLevelUp?.Invoke();
        }

        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }

        void IDataHandler.LoadData(SavedData data)
        {
            this.level = data.level;
        }

        void IDataHandler.SaveData(ref SavedData data)
        {
            data.level = this.level;
        }
    }
}