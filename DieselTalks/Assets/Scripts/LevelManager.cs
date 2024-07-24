using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class LevelManager : MonoBehaviour, ISavable
    {
        public int level = 0;

        public delegate void LevelUp();
        public event LevelUp OnLevelUp;

        public void IncreaseLevel()
        {
            level++;
            OnLevelUp?.Invoke();
        }

       
        void ISavable.LoadData(SavedData data)
        {
            this.level = data.level;
        }

        void ISavable.SaveData(ref SavedData data)
        {
            data.level = this.level;
        }
    }
}