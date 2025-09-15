using UnityEngine;

public class CameraScreenShake : MonoBehaviour
{
	private Vector3 _origPos;

	private float _duration = 0;
	private float _curDuration = 0;
	private float _intensity = 0;

	private void OnEnable()
	{
		_origPos = transform.position;
	}

	public void ApplyScreenShake(float intensity, float duration)
	{
		_duration = duration;
		_curDuration = duration;
		_intensity = intensity;
	}

	private void Update()
	{
		if(_curDuration > 0)
		{
			float intensity = _intensity * (_curDuration / _duration);
			Vector3 randVec = new Vector3(Random.Range(-intensity, intensity), Random.Range(-intensity, intensity), 0f);
			transform.position = _origPos + randVec;
			_curDuration -= Time.deltaTime;
		}
		else
		{
			transform.position = _origPos;
		}
	}
}
