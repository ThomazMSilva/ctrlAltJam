using TMPro;
using UnityEngine;

public class CanvasReference : MonoBehaviour
{
    public static CanvasReference instance;
    public UnityEngine.UI.Image image;
    public TextMeshProUGUI tmp;
    public AudioSource audioSource;

    private void Awake() => instance = this;

}
