using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundConfig", menuName = "ScriptableObjects/SoundConfig", order = 0)]

public class SoundConfig : ScriptableObject
{
    [SerializeField] private AudioClip music;
    public AudioClip SoundClip => music;
}
