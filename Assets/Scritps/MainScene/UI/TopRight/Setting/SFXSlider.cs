using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSlider :SliderBase
{
    float currentSFX = 0.7f;
    protected override void OnChange(float amount)
    {
        currentSFX = SoundManager.Instance.SetSFXGame(amount);
        slider.value = currentSFX;
        PlayerPrefs.SetFloat(StringSave.sfxSave,currentSFX);
    }

    protected override void Start()
    {
        base.Start();
        currentSFX=PlayerPrefs.GetFloat(StringSave.sfxSave,0.7f);
        slider.value = SoundManager.Instance.SetSFXGame(currentSFX);
    }


    // Update is called once per frame
    void Update()
    {
        if (SoundManager.Instance.IsResseted) StartCoroutine(CheckIsReset());
    }

    IEnumerator CheckIsReset()
    {
        currentSFX = 0.7f;

        slider.value = SoundManager.Instance.SetMusicGame(currentSFX);
        PlayerPrefs.SetFloat(StringSave.musicSave, currentSFX);

        yield return new WaitForSeconds(1f);

        SoundManager.Instance.IsResseted = false;
    }

}
