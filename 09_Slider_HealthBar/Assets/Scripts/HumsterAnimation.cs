using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class HumsterAnimation : MonoBehaviour
{
	[SerializeField] private int _jumpForce;
	[SerializeField] private ContactFilter2D _filter;

	private Animator _animator;
	private Rigidbody2D _rigidbody2D;
	private Collider2D[] _colliders = new Collider2D[1];

	private void Awake()
	{
		_animator = GetComponent<Animator>();
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	public void ReactOnClickButton(float value)
	{
		if (value > 0)
		{
			DoJump();
			return;
		}

		if (value < 0)
		{
			DoDamage();
			return;
		}
	}

	private void DoJump()
	{
		_animator.SetTrigger("Jump");

		if (_rigidbody2D.OverlapCollider(_filter, _colliders) > 0)
		{
			_rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
		}
	}

	private void DoDamage()
	{
		_animator.SetTrigger("Damage");
	}
}
