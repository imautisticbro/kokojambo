using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]private List<AudioClip> _audioClips;
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(int index)
    {
        _audioSource.clip = _audioClips.ToArray()[index];
    }
}
