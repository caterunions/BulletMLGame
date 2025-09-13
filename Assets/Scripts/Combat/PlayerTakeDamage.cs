using System;

using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
	public event Action<PlayerTakeDamage, HealthDamageReceiver, BulletVisuals> OnBulletHit;

	[SerializeField]
	private HealthDamageReceiver _hdr;

    private void OnTriggerEnter2D(Collider2D other)
	{
		BulletVisuals vis = other.gameObject.GetComponent<BulletVisuals>();

		if (vis == null) return;

		if (vis.Damage > 0 && !vis.HasHit)
		{
			vis.HasHit = true;
			_hdr.Damage(vis.Damage);
			OnBulletHit?.Invoke(this, _hdr, vis);
			Debug.Log("damage");
		}
	}
}
