using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowCount : MonoBehaviour
{
    public Text scoreText;
    [SerializeField]
    private string itemCounted;
    public static int scoreValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = itemCounted+": " + scoreValue;
        if (scoreValue == 12)
        {
            DialogueManager.task2Complete = true;
        }
    }
}
