using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;


public enum CharacterExpression
{
    happy,
    neutral,
    upset
}

[System.Serializable]
public class Dialogue
{
    [TextArea] public string text;
    [SerializeField] public float typingDelaySpeed;
    public bool hasBackground;
    public CharacterExpression characterMood;
    public CharacterKey characterKey;
}

public class DialogueBehaviour : MonoBehaviour
{
    [SerializeField] CharacterManager characterManager;

    public List<Dialogue> dialogueList = new();

    private int currentIndex;

    private bool isTextFinished;

    private TextMeshProUGUI textMeshPro;
    private UnityEngine.UI.Image characterIMG;
    private AudioSource audioSource;

    public UnityEvent OnTextFinished;

    public void ChangeText()
    {
        StopAllCoroutines();

        if (!isTextFinished)
        {
            textMeshPro.text = (dialogueList[currentIndex].hasBackground ? "<font=\"LiberationSans SDF\"> <mark=#000000 padding=10,20,5,5>" : "") + dialogueList[currentIndex].text;
            isTextFinished = true;
        }

        else
        {
            textMeshPro.text = "";

            if (currentIndex + 1 < dialogueList.Count)
            {
                currentIndex++;

                StartTypingCurrentDialogue();
            }
            else
            {
                OnTextFinished?.Invoke();
            }   

        }
    }

    private void OnEnable()
    {
        TextMeshProClickHandler.OnTextClickedEvent += ChangeText;

        textMeshPro = CanvasReference.instance.tmp;
        characterIMG = CanvasReference.instance.image;
        audioSource = CanvasReference.instance.audioSource;

        textMeshPro.gameObject.SetActive(true);

        currentIndex = 0;
        StartTypingCurrentDialogue();
    }

    private void OnDisable()
    {
        TextMeshProClickHandler.OnTextClickedEvent -= ChangeText;
        //textMeshPro.gameObject.SetActive(false);
    }

    private IEnumerator TypeText(string newText, float typingInterval = 0.1f, bool hasBackground = false, CharacterKey characterKey = CharacterKey.Barman, CharacterExpression characterMood = CharacterExpression.happy)
    {
        isTextFinished = false;
        textMeshPro.text = hasBackground ? "<font=\"LiberationSans SDF\"> <mark=#000000 padding=10,20,5,5>" : "";
        WaitForSeconds interval = new(typingInterval);
            
        ChangeSprite(characterKey, characterMood);


        for (int i = 0; i < newText.Length; i++)
        {
            if (newText[i] == '<')
            {
                textMeshPro.text += FullTag(newText, ref i);
            }
            else
            {
                PlaySound(characterKey);
                textMeshPro.text += newText[i];
            }

            yield return interval;
        }
        isTextFinished = true;

        yield return null;
    }

    private void StartTypingCurrentDialogue()
    {
        Dialogue currentDialogue = dialogueList[currentIndex];

        StartCoroutine(
            TypeText
            (
                currentDialogue.text,
                currentDialogue.typingDelaySpeed,
                currentDialogue.hasBackground,
                currentDialogue.characterKey,
                currentDialogue.characterMood
            )
        );
    }

    private void PlaySound(CharacterKey charKey)
    {
        CharacterProperties characterToSpeak = characterManager.GetCharacter(charKey);

        //audioSource.clip = currentCharacter.characterVoiceAudioClip;
        audioSource.pitch = 1 + Random.Range(-characterToSpeak.voicePitchVariation, characterToSpeak.voicePitchVariation);
        audioSource.PlayOneShot(characterToSpeak.characterVoiceAudioClip);
    }

    string FullTag(string text, ref int index)
    {
        string fullTag = "";

        while (index < text.Length) 
        {
            fullTag += text[index];

            if (text[index] == '>')
                return fullTag;

            index++;
        }

        return "";
    }

    private void ChangeSprite(CharacterKey charKey, CharacterExpression charMood)
    {
        CharacterProperties characterToChange = characterManager.GetCharacter(charKey);

        switch (charMood)
        {
            case CharacterExpression.happy:
                characterIMG.sprite = characterToChange.characterHappyIMG;
                break;
            case CharacterExpression.neutral:
                characterIMG.sprite = characterToChange.characterNeutralIMG;
                break;
            case CharacterExpression.upset:
                characterIMG.sprite = characterToChange.characterUpsetIMG;
                break;

            default: break;
        }
    }
}
