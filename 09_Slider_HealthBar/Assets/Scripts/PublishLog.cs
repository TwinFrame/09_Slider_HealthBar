using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(PublishLog))]
[RequireComponent(typeof(TMP_Text))]

public class PublishLog : MonoBehaviour
{
	[SerializeField] private float _viewTextTime;
	[SerializeField] private float _FadeOutTextTime;

	private TMP_Text _text;
	private WaitForSeconds _waitForSeconds;
	private float _currentTime;
	private Color _color;
	private Coroutine _publishTextJob;

	private void Awake()
	{
		_text = GetComponent<TMP_Text>();

		_waitForSeconds = new WaitForSeconds(_viewTextTime);

		_color = _text.color;
	}

	public void PublishText(string text)
	{
		if (_publishTextJob != null)
		{
			StopCoroutine(_publishTextJob);
		}

		_publishTextJob = StartCoroutine(FadeOutText(text));
	}

	private IEnumerator FadeOutText(string text)
	{
		_text.text = text;
		yield return _waitForSeconds;

		while (_currentTime <= _FadeOutTextTime)
		{
			_color.a = 1 - (_currentTime / _FadeOutTextTime);

			_text.color = _color;

			_currentTime += Time.deltaTime;

			yield return null;
		}

		_currentTime = 0f;
		_text.text = "";
		_color.a = 1f;
		_text.color = _color;
	}
}
