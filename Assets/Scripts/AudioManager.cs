using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {
    [SerializeField] [Range(0, 1)] private float masterVolume = 0.0f;
    [SerializeField] [Range(0, 1)] private float musicVolume = 0.0f;
    [SerializeField] [Range(0, 1)] private float dialogueVolume = 0.0f;
    [SerializeField] [Range(0, 1)] private float menuEffectVolume = 0.0f;
    [SerializeField] [Range(0, 1)] private float gameEffectVolume = 0.0f;
    [SerializeField] private string musicClipsPath = "Sound/Music";
    [SerializeField] private string dialogueClipsPath = "Sound/Dialogue";
    [SerializeField] private string menuEffectClipsPath = "Sound/SoundEffectsMenu";
    [SerializeField] private string gameEffectClipsPath = "Sound/SoundEffectsGame";
    [SerializeField] private List<AudioClip> musicClips = new List<AudioClip>();
    [SerializeField] private List<AudioClip> dialogueClips = new List<AudioClip>();
    [SerializeField] private List<AudioClip> menuEffectClips = new List<AudioClip>();
    [SerializeField] private List<AudioClip> gameEffectClips = new List<AudioClip>();
    [SerializeField] private AudioSource globalAudSource = null;

    // Use this for initialization
    void Start () {
        Init();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Init() {
        LoadAudioClips();
        //Change this to occur when MainMenu scene is loaded. SceneManager.sceneLoaded
        PlayMainMenuMusic();
    }

    public void LoadAudioClips() {
        Object[] tmpObjs;
        tmpObjs = Resources.LoadAll(musicClipsPath);
        foreach (Object obj in tmpObjs) {
            musicClips.Add(obj as AudioClip);
        }
        tmpObjs = Resources.LoadAll(dialogueClipsPath);
        foreach (Object obj in tmpObjs) {
            dialogueClips.Add(obj as AudioClip);
        }
        tmpObjs = Resources.LoadAll(menuEffectClipsPath);
        foreach (Object obj in tmpObjs) {
            menuEffectClips.Add(obj as AudioClip);
        }
        tmpObjs = Resources.LoadAll(gameEffectClipsPath);
        foreach (Object obj in tmpObjs) {
            gameEffectClips.Add(obj as AudioClip);
        }
    }

    public float GetSoundTypeVolume(AudioClip audClip) {
        if (musicClips.Contains(audClip)) {
            return musicVolume;
        }
        else if (dialogueClips.Contains(audClip)) {
            return dialogueVolume;
        }
        else if (menuEffectClips.Contains(audClip)) {
            return menuEffectVolume;
        }
        else {
            return gameEffectVolume;
        }
    }

    public void PlaySound(AudioClip audClip) {
        globalAudSource.clip = audClip;
        globalAudSource.volume = masterVolume * GetSoundTypeVolume(audClip);
        globalAudSource.Play();
    }

    public void PlaySound(AudioClip audClip, AudioSource audSource) {
        audSource.clip = audClip;
        audSource.volume = masterVolume * GetSoundTypeVolume(audClip);
        audSource.Play();
    }

    public void PlayMainMenuMusic() {
        PlaySound(musicClips[0]);
    }
}
