using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]private List<AudioClip> _audioClips;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int index)
    {
        if (_audioSource.isPlaying) return;
        _audioSource.clip = _audioClips.ToArray()[index];
        _audioSource.Play();
    }
    public void PlaySoundForced(int index)
    {
        _audioSource.clip = _audioClips.ToArray()[index];
        _audioSource.Play();
    }
}
