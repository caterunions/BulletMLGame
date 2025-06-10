using UnityEngine;
using BulletMLLib;

public class UnityBullet : MonoBehaviour
{
	private Bullet _bullet;

	public ElementType ElementType { get; private set; }

	[SerializeField]
	private SpriteRenderer _spriteRenderer;

	private bool top = false;

	[SerializeField]
	private Material _neutralMaterial;
	[SerializeField]
	private Material _physMaterial;
	[SerializeField]
	private Material _fireMaterial;
	[SerializeField]
	private Material _iceMaterial;
	[SerializeField]
	private Material _elecMaterial;
	[SerializeField]
	private Material _holyMaterial;
	[SerializeField]
	private Material _curseMaterial;

	public void Initialize(Bullet bullet)
	{
		_bullet = bullet;

		// no visuals for top
		if (top) return;

		_spriteRenderer.enabled = true;

		ElementType = _bullet.ElementType;

		SetElementMaterial();
	}

	private void SetElementMaterial()
	{
		switch(ElementType) {
			case ElementType.Neutral:
			{
				_spriteRenderer.material = _neutralMaterial;
				break;
			}
			case ElementType.Physical:
			{
				_spriteRenderer.material = _physMaterial;
				break;
			}
			case ElementType.Fire:
			{
				_spriteRenderer.material = _fireMaterial;
				break;
			}
			case ElementType.Ice:
			{
				_spriteRenderer.material = _iceMaterial;
				break;
			}
			case ElementType.Electric:
			{
				_spriteRenderer.material = _elecMaterial;
				break;
			}
			case ElementType.Holy:
			{
				_spriteRenderer.material = _holyMaterial;
				break;
			}
			case ElementType.Curse:
			{
				_spriteRenderer.material = _curseMaterial;
				break;
			}
		}
	}

	public void Hide()
	{
		_spriteRenderer.enabled = false;
		top = true;
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