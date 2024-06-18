using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioDoor : MonoBehaviour
{
    [SerializeField] private AudioSource _compAudioSource;
    [SerializeField] private AudioSource audioDoor;
    public Image image;
    [SerializeField] private SoundConfig music;
    [SerializeField] private SoundConfig sfx;
    [SerializeField] private Color currentColor;
    [SerializeField] private Color starColor;


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            _compAudioSource.clip = music.SoundClip;
            _compAudioSource.Play();
            audioDoor.clip = sfx.SoundClip;
            audioDoor.Play();
            StartCoroutine(FadeInWait());
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            _compAudioSource.Stop();
            audioDoor.Stop();
            audioDoor.Play();
            StartCoroutine(FadeInWait());
        }
    }
    IEnumerator FadeInWait()
    {
        currentColor = starColor;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            currentColor.a = alpha;
            image.color = currentColor;
            yield return new WaitForSeconds(0.05f); 
        }
    }
}
