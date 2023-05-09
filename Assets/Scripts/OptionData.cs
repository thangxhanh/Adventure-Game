using UnityEngine;
using UnityEngine.UI;

public class OptionData : MonoBehaviour
{
    public static OptionData Instance { get; private set; }

    public float musicVolume { get; private set; }
    
    [SerializeField] private Slider sliderVolume;

    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) 
        { 
            Destroy(this);
        } 
        else 
        { 
            Instance = this; 
        }
    }
    
    void Start()
    {
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }

    public void SetVolume()
    {
        musicVolume = sliderVolume.value;
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }
}
