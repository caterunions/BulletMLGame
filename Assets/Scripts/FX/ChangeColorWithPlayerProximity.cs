using UnityEngine;

public class ChangeColorWithPlayerProximity : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _spr;
	[SerializeField]
	private Color _color;

	private Color _origColor;

	private void OnEnable()
	{
		_origColor = _spr.color;	
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			_spr.color = _color;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			_spr.color = _origColor;
		}
	}
}
