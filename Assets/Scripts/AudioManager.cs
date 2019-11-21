using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	[SerializeField] private AudioClip buttonClick;
	[SerializeField] private AudioClip winSound;
	[SerializeField] private GameObject audioPack;
	
	private const float MinVolume = -80f;

	public static AudioManager Instance;
	public AudioMixer mixer;
	
	[SerializeField] private string[] volumeParameters = {"masterVolume", "musicVolume"};
	public string[] VolumeParameters
	{
		get { return volumeParameters; }
	}

	private void Awake()
	{
		Instance = GetComponent<AudioManager>();
	}

	private void Start()
	{
		if (!Settings.Instance.audioInitialized)
		{
			Settings.Instance.InitializeAudioSettings();
			Instance.mixer.SetFloat(volumeParameters[0], MinVolume);
		}
	}

	public void ToggleMasterVolumeMute()
	{
		if (Settings.Instance.audioMuted)
		{
			Instance.mixer.SetFloat(volumeParameters[0], Settings.Instance.audioLevels[0]);
			Settings.Instance.audioMuted = false;
		}
		else
		{
			Instance.mixer.SetFloat(volumeParameters[0], MinVolume);
			Settings.Instance.audioMuted = true;
		}
	}

	public void PlayButtonClick()
	{
		GameObject ap = Instantiate(audioPack);
		PlaySfx audioScript = ap.GetComponent<PlaySfx>();
		audioScript.soundFile = buttonClick;
		audioScript.Play();
	}

	public void PlayWinSound()
	{
		GameObject ap = Instantiate(audioPack);
		PlaySfx audioScript = ap.GetComponent<PlaySfx>();
		audioScript.soundFile = winSound;
		audioScript.Play();
	}

	public void PlayMusic()
	{
		Instance.mixer.SetFloat(volumeParameters[1], Settings.Instance.audioLevels[1]);
	}

	public void StopMusic()
	{
		Instance.mixer.SetFloat(volumeParameters[1], MinVolume);
	}
}
