using UnityEngine;

public class SpawnAfterimages : MonoBehaviour
{
	[SerializeField]
	private Afterimage _afterimagePrefab;
	[SerializeField]
	private float _timeBetweenSpawns;
	[SerializeField]
	private float _afterimageLifetime;
	[SerializeField]
	private float _startOpacity;
	[SerializeField]
	private float _endOpacity;
	[SerializeField]
	private SpriteRenderer _referencedSpriteRenderer;
	[SerializeField]
	private Vector2 _afterimageVelocity;

	private float _accumulatedDeltaTime;

	private void OnEnable()
	{
		
	}

	private void Update()
	{
		_accumulatedDeltaTime += Time.deltaTime;

		if(_accumulatedDeltaTime >= _timeBetweenSpawns)
		{
			_accumulatedDeltaTime -= _timeBetweenSpawns;
			Afterimage spawn = Instantiate(_afterimagePrefab, transform.position, transform.rotation);
			spawn.Initialize(_afterimageLifetime, _startOpacity, _endOpacity, _afterimageVelocity, _referencedSpriteRenderer);
		}
	}
}
