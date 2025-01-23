using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio
;
public class AudioMan : MonoBehaviour
{
    public static AudioMan instance;

    [SerializeField] AudioMixer mixer;
    public const string BGMKey = "BgmVol";
    public const string SFXKey = "SfxVol";
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        
        loadVol();
    }


    void loadVol()
    {
        float bgmvol = PlayerPrefs.GetFloat(BGMKey, 1f);
        float sfxvol = PlayerPrefs.GetFloat(SFXKey, 1f);

        mixer.SetFloat(VolumeSettings.MixerBGM, Mathf.Log10(bgmvol) * 20);
        mixer.SetFloat(VolumeSettings.MixerSFX, Mathf.Log10(sfxvol) * 20);
    }
}
