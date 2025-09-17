using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer audioMixer;
    

    void Start()
    {
        if (volumeSlider != null)
        {
            float volume;
            audioMixer.GetFloat("MasterVolume", out volume);
            volumeSlider.value = Mathf.Pow(10, volume / 20f);
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
        
    }

    
    void SetVolume(float value)
    {

        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
        audioMixer.SetFloat("MasterVolume", dB);
    }
    
}
