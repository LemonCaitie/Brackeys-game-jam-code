using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundPickUp : MonoBehaviour
{
    [SerializeField]
    public new AudioSource soundClip;
    [SerializeField]
    public AudioClip impact;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void PickUp()
    {
        Debug.Log("Audio should play");
        soundClip.PlayOneShot(impact, 1.0f);
    }
}
