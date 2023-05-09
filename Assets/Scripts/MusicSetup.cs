using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSetup : MonoBehaviour
{
    [SerializeField] private AudioSource sourceBackground;
    [SerializeField] private AudioSource soundSfx;
    
    // Start is called before the first frame update
    void Start()
    {
        setVolume(OptionData.Instance.musicVolume);
    }

    //Set volume for level
    private void setVolume(float volume)
    {
        sourceBackground.volume = volume;
        soundSfx.volume = volume;
    }
}
