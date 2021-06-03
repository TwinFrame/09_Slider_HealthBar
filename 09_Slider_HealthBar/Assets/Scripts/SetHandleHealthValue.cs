using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TMP_Text))]

public class SetHandleHealthValue : MonoBehaviour
{
	private TMP_Text _healthValue;

	private void Awake()
	{
		_healthValue = GetComponent<TMP_Text>();
	}

	public void PublishHealthValue(float value)
	{
		_healthValue.text = value.ToString();
	}
}
