using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(SetMaxHealthBar))]

public class SetMaxHealthBar : MonoBehaviour
{
	[Header("Set Maximum..")]
	[SerializeField] private SetMaxEvent _setValueEvent;
	[Header("..or Send Error")]
	[SerializeField] private ErrorMaxConvert _errorConvert;

	private bool _isCheck;

	public void CheckConvertToFloat(string text)
	{
		_isCheck = float.TryParse(text, out float value);

		if (_isCheck)
		{
			_setValueEvent.Invoke(value);
		}
		else
		{
			_errorConvert.Invoke($"Invalid value entered.");
		}
	}
}

[System.Serializable]
public class SetMaxEvent : UnityEvent<float> { }

[System.Serializable]
public class ErrorMaxConvert : UnityEvent<string> { }
