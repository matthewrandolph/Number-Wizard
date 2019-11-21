using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
	private static BackgroundMusic _instance;

	void Awake()
	{
		SetUpSingleton();
	}

	private void SetUpSingleton()
	{
		if (_instance == null)
		{
			_instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else if (this != _instance)
		{
			Destroy(gameObject);
		}
	}
}
