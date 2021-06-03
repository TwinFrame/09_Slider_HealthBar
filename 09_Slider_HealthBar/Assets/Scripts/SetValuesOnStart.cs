using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class SetValuesOnStart : MonoBehaviour
{
	[SerializeField] private GameObject _inputFieldMaximum;
	[SerializeField] private GameObject _inputFieldStep;
	[SerializeField] private GameObject _inputFieldSpeed;
	[SerializeField] private GameObject _slider;

	private SetMaxHealthBar _setMaxHealthBar;
	private SetStepHealthBar _setStepHealthBar;
	private SetSpeedValue _setSliderSpeed;

	private string _textMaximum;
	private string _textStep;
	private string _textSpeed;

	private void Awake()
	{
		_setMaxHealthBar = GetComponent<SetMaxHealthBar>();
		_setStepHealthBar = GetComponent<SetStepHealthBar>();
		_setSliderSpeed = GetComponent<SetSpeedValue>();


		_textMaximum = _inputFieldMaximum.GetComponent<TMP_InputField>().text;
		_textStep = _inputFieldStep.GetComponent<TMP_InputField>().text;
		_textSpeed = _inputFieldSpeed.GetComponent<TMP_InputField>().text;
	}

	private void Start()
	{
		_setMaxHealthBar.CheckConvertToFloat(_textMaximum);
		_setStepHealthBar.CheckConvertToFloat(_textStep);
		_setSliderSpeed.CheckConvertToFloat(_textSpeed);

		_slider.GetComponent<SetSliderValue>().SetTargetValue(
			_slider.GetComponent<Slider>().value = _slider.GetComponent<Slider>().maxValue / 2);
	}
}
