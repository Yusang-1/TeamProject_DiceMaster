using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAudioTrigger : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip audioClip;
    public SFXPool SFXPool;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Debug.Log((int)MagicSFXEnum.Wind);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (audioClip == collision.gameObject.GetComponent<AttachedAudio>().GetAudio())
        {
            Debug.Log("°°Àº À½¾Ç");
            return;
        }

        audioClip = collision.gameObject.GetComponent<AttachedAudio>().GetAudio();

        audioSource.clip = audioClip;

        audioSource.Play();
    }
}
