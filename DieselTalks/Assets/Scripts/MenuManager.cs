using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class MenuManager : MonoBehaviour
    {

        [SerializeField]
        private GameObject
            pauseScreen,
            brewingScreen;
        private bool
            isPaused = false,
            isBrewing = false;
        public void SwitchBrewingScreen()
        {
            isBrewing = !isBrewing;
            brewingScreen.SetActive(isBrewing);
        }

        public void SwitchPauseScreen()
        {
            isPaused = !isPaused;
            pauseScreen.SetActive(isPaused);
        }

        


    }
}