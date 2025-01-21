using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BottomBarController : MonoBehaviour
{
    public TextMeshProUGUI barText;
    public TextMeshProUGUI personNameText;

    private int sentenceIndex = -1;
    private StoryScene currentScene;
    private State state = State.COMPLETED;

    private bool skipTyping = false; // Flag untuk skip typing

    private enum State
    {
        PLAYING, COMPLETED
    }

    public void PlayScene(StoryScene scene)
    {
        currentScene = scene;
        sentenceIndex = -1;
        PlayNextSentence();
    }

    public void PlayNextSentence()
    {
        if (state != State.COMPLETED) return;

        sentenceIndex++;
        if (sentenceIndex >= currentScene.sentences.Count) return;

        // Tampilkan kalimat baru
        personNameText.text = currentScene.sentences[sentenceIndex].speaker.speakerName;
        personNameText.color = currentScene.sentences[sentenceIndex].speaker.textColor;
        StartCoroutine(TypeText(currentScene.sentences[sentenceIndex].text));
    }

    public bool IsCompleted()
    {
        return state == State.COMPLETED;
    }

    public bool IsLastSentence()
    {
        return sentenceIndex + 1 == currentScene.sentences.Count;
    }

    private IEnumerator TypeText(string text)
    {
        barText.text = "";
        state = State.PLAYING;
        skipTyping = false; // Reset flag skip

        for (int i = 0; i < text.Length; i++)
        {
            if (skipTyping) // Jika skip, langsung tampilkan seluruh teks
            {
                barText.text = text;
                break;
            }

            barText.text += text[i];
            yield return new WaitForSeconds(0.05f);
        }

        state = State.COMPLETED;
    }

    public void SkipOrCompleteText()
    {
        if (state == State.PLAYING)
        {
            skipTyping = true; // Aktifkan skip
        }
    }
}
