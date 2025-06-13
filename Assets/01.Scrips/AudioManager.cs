using System;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region 싱글톤 구현
    private static AudioManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static AudioManager Instance
    {
        get
        {
            if( instance == null)
            {
                return null;
            }
            return instance;
        }
    }
    #endregion

    SFXPool audioPool;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource battleAudioSource;
    [SerializeField] AudioSource reactAudioSource;
    AudioSource backgroundAudioSource;

    private void Start()
    {
        audioPool = GetComponent<SFXPool>();
        backgroundAudioSource = GetComponent<AudioSource>();
    }

    #region 단발성 오디오 재생 메서드
    public void PlayAudioOnce(AudioClip[] audioClips, MagicSFXEnum enumSFX)
    {
        battleAudioSource.PlayOneShot(audioClips[(int)enumSFX]);
    }

    public void PlayAudioOnce(AudioClip[] audioClips, BuffSFXEnum enumSFX)
    {
        battleAudioSource.PlayOneShot(audioClips[(int)enumSFX]);
    }

    public void PlayAudioOnce(AudioClip[] audioClips, PyhsicsSFXEnum enumSFX)
    {
        battleAudioSource.PlayOneShot(audioClips[(int)enumSFX]);
    }

    public void PlayAudioOnce(AudioClip[] audioClips, ReactSFXEnum enumSFX)
    {
        reactAudioSource.PlayOneShot(audioClips[(int)enumSFX]);
    }

    public void PlayAudioOnce(AudioClip[] audioClips, UISFXEnum enumSFX)
    {
        audioSource.PlayOneShot(audioClips[(int)enumSFX]);
    }
    #endregion

    public void PlayBackGroundAudioOnStart(int stage)
    {
        StopAllCoroutines();
        IEnumerator changeAudio;

        int randNum = GetRandomClipNum(stage);

        backgroundAudioSource.clip = audioPool.BackGroundAudio[stage][randNum];

        changeAudio = ChangeAudio(stage);
        StartCoroutine(changeAudio);
    }

    private int GetRandomClipNum(int stage)
    {
        int randNum = UnityEngine.Random.Range(0, audioPool.BackGroundAudio[stage].Length);
        return randNum;
    }

    IEnumerator ChangeAudio(int stage)
    {
        while (true)
        {
            if(backgroundAudioSource.isPlaying == true)
            {
                yield return new WaitForSecondsRealtime(2.5f);
            }
            int randNum = GetRandomClipNum(stage);

            backgroundAudioSource.clip = audioPool.BackGroundAudio[stage][randNum];
            backgroundAudioSource.Play();
            yield return new WaitForSecondsRealtime(50f);
        }
    }


}
