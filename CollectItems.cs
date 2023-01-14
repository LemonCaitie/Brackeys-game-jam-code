using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class CollectItems : MonoBehaviour
{
    public SoundPickUp cs;
    private bool pickUpAllowed;
    [SerializeField] private bool itemHalo;
    [SerializeField] private bool itemArrow;
    [SerializeField] private bool itemHorn;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.Return)) {
            PickUp();
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Crow"))
        {
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Crow"))
        {
            pickUpAllowed = false;
        }
    }

    private void PickUp()
    {
        cs.PickUp();
        if (itemHalo == true)
        {
            HaloCount.scoreValue += 1;
        }
        else if (itemArrow == true)
        {
            ArrowCount.scoreValue += 1;
        }
        else if (itemHorn == true)
        {
            HornCount.scoreValue += 1;
        }
        Destroy(gameObject, cs.impact.length);
        //CountScore.UpdateScoreValue(1);
    }
}
