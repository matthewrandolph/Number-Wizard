using System.Collections;
using UnityEngine;

public class PlaySfx : MonoBehaviour {
	
	public AudioClip soundFile;

	private AudioSource audioSource;
	private const string OutputMixer = "SFX";

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	public void Play ()
	{
		StartCoroutine(ResolveAudio());
	}
	
	private IEnumerator ResolveAudio()
	{
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = soundFile;
		audioSource.outputAudioMixerGroup = AudioManager.Instance.mixer.FindMatchingGroups(OutputMixer)[0];
		audioSource.Play();
		yield return new WaitForSeconds(soundFile.length);
		Destroy(gameObject);
	}
}
