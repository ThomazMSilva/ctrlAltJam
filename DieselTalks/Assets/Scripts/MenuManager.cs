using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
   public void NewGame()
    {
        GameManager.Instance.NewGame();
    }
    public void LoadGame()
    {
        GameManager.Instance.LoadGame();
    }

    public void Options()
    {
        GameManager.Instance.SwitchOptionsScreen();
    }

    public void Credits()
    {
        GameManager.Instance.SwitchCreditsScreen();
    }

    public void Quit()
    {
        GameManager.Instance.Quit();
    }
}
