using UnityEngine;
using UnityEngine.UI;

public class ImageToggle : MonoBehaviour
{
	[SerializeField] private Sprite mutedImage;
	[SerializeField] private Sprite unmutedImage;
	private Image image;

	private void Awake()
	{
		image = GetComponent<Image>();
	}

	private void Start()
	{
		SetImage();
	}


	public void SetImage()
	{
		image.sprite = Settings.Instance.audioMuted ? mutedImage : unmutedImage;
	}
}
