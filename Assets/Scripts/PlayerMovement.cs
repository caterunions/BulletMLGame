using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Vector2 _lastKnownMove;

	[SerializeField]
	private Rigidbody2D _rb;

	[SerializeField]
	private float _moveSpeed = 5f;

	public void HandleMove(Vector2 moveInfo)
	{
		_lastKnownMove = moveInfo.normalized;
	}

	private void Update()
	{
		_rb.linearVelocity = _lastKnownMove * _moveSpeed;
	}
}
