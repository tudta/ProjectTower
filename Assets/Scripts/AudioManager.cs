using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    [SerializeField] private AudioSource audSource = null;
    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();

	// Use this for initialization
	void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Init() {
        PlayMainMenuMusic();
    }

    public void PlayMainMenuMusic() {
        PlaySound(audioClips[0]);
    }

    public void PlaySound(AudioClip audClip) {
        audSource.clip = audClip;
        audSource.Play();
    }
}
