using Assets.Scripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    Button[] buttons;

    private void Start()
    {
        buttons = FindObjectsOfType<Button>(true);
        foreach (Button button in buttons)
        {
            button.AddComponent<ButtonOnPointerEnter>();
        }
    }
}
