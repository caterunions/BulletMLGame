using System;

using UnityEngine;

public class PlayerGrazeHandler : MonoBehaviour
{
	public event Action<PlayerGrazeHandler, BulletVisuals> OnGraze;

	[SerializeField]
	private SpriteRenderer _spr;
	[SerializeField]
	private Gradient _gradient;
	[SerializeField]
	private float _fadeTime;
	[SerializeField]
	private AudioSource _audioSource;

	private float _curFadeTime;

	private void OnTriggerEnter2D(Collider2D other)
	{
		BulletVisuals vis = other.gameObject.GetComponentInChildren<BulletVisuals>();

		if (vis == null) return;

		if (vis.Damage > 0 && !vis.HasGrazed)
		{
			vis.HasGrazed = true;
			_audioSource.Play();
			_curFadeTime = _fadeTime;
			_spr.color = _gradient.Evaluate(0);
		}
	}

	private void Update()
	{
		if(_curFadeTime > 0)
		{
			_curFadeTime -= Time.deltaTime;
			_spr.color = _gradient.Evaluate(1  - (_curFadeTime / _fadeTime));
		}
	}
}
