using UnityEngine;

public class Settings : MonoBehaviour {

	public static Settings Instance;

	[Header("Audio")]
	public bool audioMuted = true;
	public bool audioInitialized = false;
	public float[] audioLevels;

	private void Awake()
	{
		SetUpSingleton();
	}

	private void SetUpSingleton()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(this);
		}
		else if (this != Instance)
		{
			Destroy(this.gameObject);
		}
	}

	public void InitializeAudioSettings()
	{
		audioMuted = true;
		audioLevels = new float[AudioManager.Instance.VolumeParameters.Length];
		for (var i = 0; i < AudioManager.Instance.VolumeParameters.Length; i++)
		{
			AudioManager.Instance.mixer.GetFloat(AudioManager.Instance.VolumeParameters[i], out audioLevels[i]);
		}
		audioInitialized = true;
	}
}
