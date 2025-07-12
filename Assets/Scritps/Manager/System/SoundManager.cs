using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : SingletonBase<SoundManager>
{
  

    [Header("list sound background")]
    [SerializeField]
    private AudioClip musicGame;

    [Header("list sound effect")]
    [SerializeField]private AudioClip[] sfxList;

    private AudioSource musicSource;
    private AudioSource sfxSoucre;

    private Dictionary<string,AudioClip> sfxDic=new Dictionary<string,AudioClip>();

    private static bool isResseted=false;

    public bool IsResseted { get => isResseted; set => isResseted = value; }

   protected override void Awake()
    {
        base.Awake();
        musicSource =transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        sfxSoucre =transform.GetChild(1).gameObject.GetComponent<AudioSource>();
    }
    private void OnSceneLoaded(Scene sceen ,LoadSceneMode sceneMode) 
    {

        musicGame = Resources.Load<AudioClip>("Sound/BackGround/BackgroudMusic");
        sfxList = Resources.LoadAll<AudioClip>("Sound/SoundEffect");
        PlayMusic(musicGame);
        foreach (AudioClip sfx in sfxList)
        {
            if (sfx != null && !sfxDic.ContainsKey(sfx.name))
            {
                sfxDic.Add(sfx.name, sfx);
            }
        }
    }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    // Start is called before the first frame update
   

    public void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;
        musicSource.clip = clip;
        musicSource.volume = PlayerPrefs.GetFloat(StringSave.musicSave,0.7f);
        musicSource.Play();
       
    }

    private void Update()
    {
       
    }

    public void PlaySfx(string nameClip) 
    {
        if (sfxDic.TryGetValue(nameClip, out AudioClip clip))
        { 
            sfxSoucre.PlayOneShot(clip,sfxSoucre.volume);
        }
        else
        {
            Debug.LogWarning($"SFX '{nameClip}' not found!");
        }
    }

    public float SetMusicGame(float amount)
    {
        amount = Mathf.Clamp01(amount);
        musicSource.volume = amount;
        return musicSource.volume;
    }
       public float SetSFXGame(float amount)
    {
        amount = Mathf.Clamp01(amount);
        sfxSoucre.volume = amount;
        return amount;
    }


    public void ResetMusicAll()
    {
        PlaySfx(TagInGame.buttonClick);
        isResseted = true;
        
        PlayerPrefs.DeleteKey(StringSave.musicSave);
        PlayerPrefs.DeleteKey(StringSave.sfxSave);

        float defaultVolume = 0.7f;

        SetMusicGame(defaultVolume);
        SetSFXGame(defaultVolume);

        PlayerPrefs.SetFloat(StringSave.musicSave,defaultVolume);
        PlayerPrefs.SetFloat(StringSave.sfxSave, defaultVolume);

    }

}
