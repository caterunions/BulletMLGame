using UnityEngine;
using BulletMLLib;

public class UnityBullet : MonoBehaviour
{
	private Bullet _bullet;

	public void Initialize(Bullet bullet)
	{
		_bullet = bullet;
	}

	private void Update()
	{
		_bullet.Update();
		transform.position = new Vector2(_bullet.X / 25, _bullet.Y / 25);
	}
}