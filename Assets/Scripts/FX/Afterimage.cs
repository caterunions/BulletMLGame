using UnityEngine;

public class Afterimage : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _spr;

	private float _lifetime;
	private float _startOpacity;
	private float _endOpacity;
	private Vector3 _velocity;
	private float _aliveTime = 0f;

	public void Initialize(float lifetime, float startOpacity, float endOpacity, Vector2 velocity, SpriteRenderer spr)
	{
		_lifetime = lifetime;
		_startOpacity = startOpacity;
		_endOpacity = endOpacity;
		_velocity = velocity;
		_spr.sprite = spr.sprite;
		_spr.flipX = spr.flipX;
		_spr.flipY = spr.flipY;
		_spr.color = spr.color;
		_spr.material = spr.material;
	}

	private void Update()
	{
		_aliveTime += Time.deltaTime;
		if (_aliveTime >= _lifetime)
		{
			Destroy(gameObject);
		}
		_spr.color = new Color(_spr.color.r, _spr.color.g, _spr.color.b, Mathf.Lerp(_startOpacity, _endOpacity, _aliveTime / _lifetime));
		transform.position += (_velocity * Time.deltaTime);
	}
}
