using UnityEngine;
using BulletMLLib;

public class UnityBullet : MonoBehaviour
{
	private Bullet _bullet;

	[SerializeField]
	private SpriteRenderer _spriteRenderer;

	public void Initialize(Bullet bullet)
	{
		_spriteRenderer.enabled = true;
		_bullet = bullet;
	}

	public void Hide()
	{
		_spriteRenderer.enabled = false;
	}

	private void Awake()
	{
		_spriteRenderer.enabled = false;
	}

	private void Update()
	{
		_bullet.Update();
		transform.position = new Vector2(_bullet.X, _bullet.Y);
		//transform.rotation = Quaternion.Euler(0, 0, (Mathf.Rad2Deg * _bullet.Direction) - 180f);
	}
}