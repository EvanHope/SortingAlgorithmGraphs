using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound(float pitchBasedOnValue)
    {
        audioSource.pitch = pitchBasedOnValue;
        audioSource.PlayOneShot(audioSource.clip);
    }
}
