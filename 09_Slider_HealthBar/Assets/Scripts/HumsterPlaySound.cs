using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class HumsterPlaySound : MonoBehaviour
{
	[SerializeField] private AudioClip _getHealth;
	[SerializeField] private AudioClip _getDamage;

	private AudioSource _audioSource;

	private void Awake()
	{
		_audioSource = GetComponent<AudioSource>();
	}

	public void PlaySound(float value)
	{
		if (_audioSource.isPlaying)
			_audioSource.Stop();

		if (value > 0)
		{
			_audioSource.PlayOneShot(_getHealth);
			return;
		}

		if (value < 0)
		{
			_audioSource.PlayOneShot(_getDamage);
			return;
		}
	}
}
