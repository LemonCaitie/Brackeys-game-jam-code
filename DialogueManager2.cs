using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager2 : MonoBehaviour
{
    public GameObject FireAnimator;
    public GameObject Fire2Animator;
    public SpriteRenderer spriteRenderer;
    public Sprite DemonCrow;

    public Text dialogueText;
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue2 dialogue)
    {
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            DemonTransition();
            //StartCoroutine(waiter());
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }


    void EndDialogue()
    {
        //Debug.Log("End of conversation");
        SceneManager.LoadScene("Menu");
    }

    void DemonTransition()
    {
        FireAnimator.SetActive(true);
        Invoke("ChangeSprite", 0.5f);
    }

    void ChangeSprite()
    {
        spriteRenderer.sprite = DemonCrow;
        FireAnimator.SetActive(false);
        Fire2Animator.SetActive(true);
        Invoke("ShowDemon", 0.5f);
    }

    void ShowDemon()
    {
        Fire2Animator.SetActive(false);
        Invoke("EndDialogue", 2);
    }
}
