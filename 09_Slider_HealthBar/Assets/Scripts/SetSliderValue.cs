using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SetSliderValue : MonoBehaviour
{
	[SerializeField] private AnimationEvent _animationEvent;

	private float _targetValue;
	private Slider _slider;
	private float _speed;

	private void Awake()
	{
		_slider = GetComponent<Slider>();
	}

	private void FixedUpdate()
	{
		_slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _speed);
	}

	public void SetSpeed(float value)
	{
		_speed = value;
	}

	public void SetValue(float value)
	{
		if ((_slider.value + value) < _slider.minValue)
		{
			if (_slider.value > _slider.minValue)
				_animationEvent.Invoke(value);

			_targetValue = _slider.minValue;

			return;
		}

		if ((_slider.value + value) > _slider.maxValue)
		{
			if (_slider.value < _slider.maxValue)
				_animationEvent.Invoke(value);

			_targetValue = _slider.maxValue;

			return;
		}

		_targetValue = _slider.value + value;

		_animationEvent.Invoke(value);
	}

	public void SetTargetValue(float value)
	{
		_targetValue = value;
	}
}

[System.Serializable]
public class AnimationEvent : UnityEvent<float> { }
