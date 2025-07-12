using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSlider : SliderBase
{

    float currentVolume=0.7f;
    protected override void OnChange(float amount)
    {
        currentVolume = SoundManager.Instance.SetMusicGame(amount);
        slider.value = currentVolume;
        PlayerPrefs.SetFloat(StringSave.musicSave,currentVolume);

        //PlayerPrefs.DeleteKey(StringSave.muiscSave);
    }




    protected override void Start()
    {
        base.Start();
        currentVolume=PlayerPrefs.GetFloat(StringSave.musicSave,0.7f);
        
        slider.value = SoundManager.Instance.SetMusicGame(currentVolume);
    }

    private void Update()
    {
        if(SoundManager.Instance.IsResseted) StartCoroutine(CheckIsReset());
    }

    IEnumerator CheckIsReset()
    {
        currentVolume = 0.7f;

        slider.value = SoundManager.Instance.SetMusicGame(currentVolume);
        PlayerPrefs.SetFloat(StringSave.musicSave, currentVolume);

        yield return new WaitForSeconds(1f);

        SoundManager.Instance.IsResseted = false;
    }


}
