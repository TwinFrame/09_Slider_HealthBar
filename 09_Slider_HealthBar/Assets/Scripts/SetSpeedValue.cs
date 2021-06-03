using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SetSpeedValue : MonoBehaviour
{
	[Header("Set Speed..")]
	[SerializeField] private SetSpeedEvent _setValueEvent;
	[Header("..or Send Error")]
	[SerializeField] private ErrorSpeedConvert _errorConvert;

	private bool _isCheck;

	public void CheckConvertToFloat(string text)
	{
		_isCheck = float.TryParse(text, out float value);

		if (_isCheck)
		{
			if (value <= 0)
			{
				value = 0.01f;
			}
			_setValueEvent.Invoke(value);
		}
		else
		{
			_errorConvert.Invoke($"Invalid value entered.");
		}
	}
}

[System.Serializable]
public class SetSpeedEvent : UnityEvent<float> { }

[System.Serializable]
public class ErrorSpeedConvert : UnityEvent<string> { }