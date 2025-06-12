using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MagicSFXEnum
{
    Fire,
    Ice,
    Thunder,
    Water,
    Wind,
    Earth,
    Charge,
    Poision
}
public class SFXPool : MonoBehaviour
{
    public List<AudioClip> MagicSFXClips = new List<AudioClip>();


}
