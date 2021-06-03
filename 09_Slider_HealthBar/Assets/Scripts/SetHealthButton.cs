using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class SetHealthButton : MonoBehaviour, IPointerClickHandler
{
	[SerializeField] private weightRatio _effectButton;
	[SerializeField] private OnClickFloatEvent _onClickFloatEvent;

	private int _weightRatio;
	private float _value;
	private TMP_Text _text;

	public enum weightRatio
	{
		add = 1,
		subtract = -1
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		_onClickFloatEvent.Invoke(_value);
	}

	private void Awake()
	{
		_text = GetComponentInChildren<TMP_Text>();

		switch (_effectButton)
		{
			case (weightRatio.add):
			default:
				_weightRatio = weightRatio.add.GetHashCode();
				break;
			case (weightRatio.subtract):
				_weightRatio = weightRatio.subtract.GetHashCode();
				break;
		}
	}

	public void SetButtonValue(float value)
	{
		_value = value * _weightRatio;

		SetButtonText(_value);
	}

	private void SetButtonText(float value)
	{
		if (_weightRatio > 0)
			_text.text = "+" + value.ToString();
		else
			_text.text = value.ToString();
	}
}

[System.Serializable]
public class OnClickFloatEvent : UnityEvent<float> { }
