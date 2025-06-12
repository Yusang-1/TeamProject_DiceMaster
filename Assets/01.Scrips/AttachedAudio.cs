using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachedAudio : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    public AudioClip GetAudio()
    {
        //AudioSource audioSource = gameObject.AddComponent<AudioSource>();

        return audioClip;
    }
}
