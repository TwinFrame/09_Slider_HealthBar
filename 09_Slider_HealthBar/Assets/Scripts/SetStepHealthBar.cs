using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(SetStepHealthBar))]

public class SetStepHealthBar : MonoBehaviour
{
	[Header("SliderHealthBar")]
	[SerializeField] private Slider _slider;

	[Header("Set Step..")]
	[SerializeField] private SetStepEvent _setValueEvent;
	[Header("..or Send Error")]
	[SerializeField] private ErrorStepConvert _errorConvert;

	private bool _isCheck;

	public void CheckConvertToFloat(string text)
	{
		_isCheck = float.TryParse(text, out float value);

		if (_isCheck && value > 0 && value < _slider.maxValue)
			_setValueEvent.Invoke(value);
		else
			_errorConvert.Invoke($"Invalid value entered.\nCorrect step range value: 0,001 - {_slider.maxValue - 0.001f}");
	}
}

[System.Serializable]
public class SetStepEvent : UnityEvent<float> { }

[System.Serializable]
public class ErrorStepConvert : UnityEvent<string> { }
