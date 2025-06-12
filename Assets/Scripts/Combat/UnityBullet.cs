using UnityEngine;
using BulletMLLib;

public class UnityBullet : MonoBehaviour
{
	private Bullet _bullet;
	public CombatManager CombatManager { get; set; }

	public ElementType ElementType { get; private set; }

	public BulletVisuals Visuals { get; set; }

	private bool _top = false;
	private float _lifetime = 0;

	public void Initialize(Bullet bullet)
	{
		_bullet = bullet;

		_lifetime = _bullet.Lifetime / 1000;
		if (_lifetime == 0)
		{
			_lifetime = float.MaxValue;
		}

		transform.position = new Vector2(_bullet.X, _bullet.Y);
		ElementType = _bullet.ElementType;
	}

	private void Update()
	{
		_bullet.Update();
		transform.position = new Vector2(_bullet.X, _bullet.Y);
		_lifetime -= Time.deltaTime;
		if(_lifetime <= 0)
		{
			CombatManager.RemoveBullet(_bullet);
		}
		if(_bullet.FaceDirection)
		{
			Visuals.transform.rotation = Quaternion.Euler(0, 0, (Mathf.Rad2Deg * _bullet.Direction) - 180f);
		}
	}
}