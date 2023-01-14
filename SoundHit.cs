using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundHit : MonoBehaviour
{
    [SerializeField]
    new AudioSource soundClip;
    [SerializeField]
    private AudioClip impact;

    // Start is called before the first frame update
    void Start()
    {
        soundClip = (AudioSource)gameObject.AddComponent<AudioSource>();
    }
    
    void OnMouseDown()
    {
        soundClip.PlayOneShot(impact, 1.0f);
    } 

    public void PickUp()
    {
        soundClip.PlayOneShot(impact, 1.0f);
    }
    
}
