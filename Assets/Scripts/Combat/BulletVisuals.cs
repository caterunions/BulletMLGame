using UnityEngine;

// might need to store more stuff later
public class BulletVisuals : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer;
	public SpriteRenderer SpriteRenderer => _spriteRenderer;
}