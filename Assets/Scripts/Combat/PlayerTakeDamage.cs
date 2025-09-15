using System;

using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
	public event Action<PlayerTakeDamage, HealthDamageReceiver, BulletVisuals> OnBulletHit;

	[SerializeField]
	private HealthDamageReceiver _hdr;
	[SerializeField]
	private AudioSource _audioSource;
	[SerializeField]
	private CameraScreenShake _cameraScreenShake;

    private void OnTriggerEnter2D(Collider2D other)
	{
		BulletVisuals vis = other.gameObject.GetComponentInChildren<BulletVisuals>();

		if (vis == null) return;

		if (vis.Damage > 0 && !vis.HasHit)
		{
			vis.HasHit = true;
			_hdr.Damage(vis.Damage);
			_audioSource.Play();
			_cameraScreenShake.ApplyScreenShake(0.3f, 0.3f);
			OnBulletHit?.Invoke(this, _hdr, vis);
			Debug.Log("damage");
		}
	}
}
