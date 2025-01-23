using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider BGM;
    [SerializeField] Slider SFX;

    public const string MixerBGM = "BMG";
    public const string MixerSFX= "SFX";
    private void Awake()
    {
        BGM.onValueChanged.AddListener(SetMusic);
        SFX.onValueChanged.AddListener(SetSFX);
    }

    private void Start()
    {
        BGM.value = PlayerPrefs.GetFloat(AudioMan.BGMKey, 1f);
        SFX.value = PlayerPrefs.GetFloat(AudioMan.SFXKey, 1f);
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioMan.BGMKey, BGM.value);
        PlayerPrefs.SetFloat(AudioMan.SFXKey, SFX.value);
        PlayerPrefs.Save();
    }
    void SetMusic(float value)
    {
        mixer.SetFloat(MixerBGM,Mathf.Log10(value)*20);
    }

    void SetSFX(float value)
    {
        mixer.SetFloat(MixerSFX, Mathf.Log10(value) * 20);
    }
}
