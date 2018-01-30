using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

    public enum SoundTypes {
        NONE,
        MASTER,
        MUSIC,
        DIALOGUE,
        MENU,
        GAME
    }

    private static AudioManager instance = null;
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
    private List<AudioSource> globalAudSources = new List<AudioSource>();
    private List<AudioSource> tmpAudSources = new List<AudioSource>();
    private AudioSource tmpAudSource = null;

    public static AudioManager Instance { get { return instance; } set { instance = value; } }

    // Use this for initialization
    void Start () {
        Init();
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void Init() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(this);
        }
        LoadAudioClips();
    }

    public void ChangeVolume(SoundTypes sType, float volume) {
        switch (sType) {
            case SoundTypes.MASTER:
                masterVolume = volume;
                break;
            case SoundTypes.MUSIC:
                musicVolume = volume;
                break;
            case SoundTypes.DIALOGUE:
                dialogueVolume = volume;
                break;
            case SoundTypes.MENU:
                menuEffectVolume = volume;
                break;
            case SoundTypes.GAME:
                gameEffectVolume = volume;
                break;
        }
    }

    private AudioSource GetPooledGlobalAudioSource() {
        foreach (AudioSource gAudSource in globalAudSources) {
            if (!gAudSource.enabled) {
                gAudSource.enabled = true;
                return gAudSource;
            }
        }
        tmpAudSource = gameObject.AddComponent<AudioSource>();
        globalAudSources.Add(tmpAudSource);
        return tmpAudSource;
    }

    private AudioSource GetPooledLocalAudioSource(GameObject audObj) {
        tmpAudSources = GetLocalAudioSourceList(audObj);
        if (tmpAudSources.Count == 0) {
            return audObj.AddComponent<AudioSource>();
        }
        else {
            foreach (AudioSource audSource in tmpAudSources) {
                if (!audSource.enabled) {
                    audSource.enabled = true;
                    return audSource;
                }
            }
            return audObj.AddComponent<AudioSource>();
        }
    }

    private void ReturnAudioSourceToPool(AudioSource source) {
        source.enabled = false;
    }

    private List<AudioSource> GetLocalAudioSourceList(GameObject audObj) {
        tmpAudSources.Clear();
        tmpAudSources.AddRange(audObj.GetComponents<AudioSource>());
        return tmpAudSources;
    }

    private AudioSource GetPlayingGlobalSoundSource(AudioClip clip) {
        foreach (AudioSource audSource in globalAudSources) {
            if (audSource.enabled && audSource.clip == clip) {
                return audSource;
            }
        }
        return null;
    }

    private AudioSource GetPlayingLocalSoundSource(AudioClip clip, GameObject audObj) {
        tmpAudSources = GetLocalAudioSourceList(audObj);
        foreach (AudioSource audSource in tmpAudSources) {
            if (audSource.enabled && audSource.clip == clip) {
                return audSource;
            }
        }
        return null;
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
        else if (gameEffectClips.Contains(audClip)) {
            return gameEffectVolume;
        }
        return 0.0f;
    }

    private IEnumerator StartSoundLifetime(AudioSource audSource) {
        yield return new WaitForSeconds(audSource.clip.length);
        ReturnAudioSourceToPool(audSource);
    }

    public void PlayGlobalSound(AudioClip audClip, bool isLooping, bool canPlayMultiple) {
        if (!canPlayMultiple) {
            tmpAudSource = GetPlayingGlobalSoundSource(audClip);
            if (tmpAudSource == null) {
                tmpAudSource = GetPooledGlobalAudioSource();
            }
        }
        else {
            tmpAudSource = GetPooledGlobalAudioSource();
        }
        tmpAudSource.clip = audClip;
        tmpAudSource.loop = isLooping;
        tmpAudSource.volume = masterVolume * GetSoundTypeVolume(audClip);
        tmpAudSource.Play();
        if (!isLooping) {
            StartCoroutine(StartSoundLifetime(tmpAudSource));
        }
    }

    public void PlayLocalSound(AudioClip audClip, GameObject audObj, bool isLooping, bool canPlayMultiple) {
        if (!canPlayMultiple) {
            tmpAudSource = GetPlayingLocalSoundSource(audClip, audObj);
            if (tmpAudSource == null) {
                tmpAudSource = GetPooledLocalAudioSource(audObj);
            }
        }
        else {
            tmpAudSource = GetPooledLocalAudioSource(audObj);
        }
        tmpAudSource.clip = audClip;
        tmpAudSource.loop = isLooping;
        tmpAudSource.volume = masterVolume * GetSoundTypeVolume(audClip);
        tmpAudSource.Play();
        if (!isLooping) {
            StartCoroutine(StartSoundLifetime(tmpAudSource));
        }
    }

    public void PlayMainMenuMusic() {
        PlayGlobalSound(musicClips[0], true, false);
    }
}
