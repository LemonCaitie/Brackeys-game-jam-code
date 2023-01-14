using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    [SerializeField]
    private CountScore cs;

    public Animator animator;

    public static bool taskChosen = false;
    public static bool task1Complete = false;
    public static bool task2Complete = false;
    public static bool task3Complete = false;
    public static bool rep1Lost = false;
    public static bool rep2Lost = false;
    public static bool rep3Lost = false;
    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        taskChosen = true;
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        if (dialogue.name == "Gabriel" && task1Complete == true)
        {
            foreach (string sentence in dialogue.completed)
            {
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
        }
        else if (dialogue.name == "Raphael" && task2Complete == true)
        {
            foreach (string sentence in dialogue.completed)
            {
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
        }
        else if (dialogue.name == "Samael" && task3Complete == true)
        {
            foreach (string sentence in dialogue.completed)
            {
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
        }
        else 
        {
            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
        }
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
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
        if (nameText.text == "Gabriel" && task1Complete == true && rep1Lost == false)
        {
            cs.UpdateScoreValue(25);
            if (task1Complete == true)
            {
                rep1Lost = true;
            }
        }
        else if (nameText.text == "Raphael" && task2Complete == true && rep2Lost == false)
        {
            cs.UpdateScoreValue(25);
            if (task2Complete == true)
            {
                rep2Lost = true;
            }
        }
        else if (nameText.text == "Samael" && task3Complete == true && rep3Lost == false)
        {
            cs.UpdateScoreValue(25);
            if (task3Complete == true)
            {
                rep3Lost = true;
            }
        }
        animator.SetBool("IsOpen", false);
    }
}
