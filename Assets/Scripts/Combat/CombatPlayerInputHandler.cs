using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
	[SerializeField]
	private PlayerInput _playerInput;

	[SerializeField]
	private PlayerMovement _playerMovement;

	private void OnEnable()
	{
		_playerInput.actions.FindAction("Move").performed += HandleMove;
		_playerInput.actions.FindAction("Move").canceled += CancelMove;
	}

	private void OnDisable()
	{
		_playerInput.actions.FindAction("Move").performed -= HandleMove;
		_playerInput.actions.FindAction("Move").canceled -= CancelMove;
	}

	private void HandleMove(InputAction.CallbackContext ctx)
	{
		_playerMovement.HandleMove(ctx.ReadValue<Vector2>());
	}

	private void CancelMove(InputAction.CallbackContext ctx)
	{
		_playerMovement.HandleMove(Vector2.zero);
	}
}
