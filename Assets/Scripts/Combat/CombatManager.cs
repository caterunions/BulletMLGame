using UnityEngine;
using BulletMLLib;
using System.Collections.Generic;
using System.Linq;

public class CombatManager : MonoBehaviour, IBulletManager
{
	[SerializeField]
	private UnityBullet _bulletPrefab;

	private UnityBullet _topBullet;

	private Dictionary<Bullet, UnityBullet> _bullets = new Dictionary<Bullet, UnityBullet>();

	private BulletPattern Pattern
	{
		get
		{
			if (_pattern == null)
			{
				_pattern = new BulletPattern();
			}
			return _pattern;
		}
	}

	private BulletPattern _pattern;

	public void StopPattern()
	{
		ClearBullets();
		_pattern = new BulletPattern();
	}

	public void ClearBullets()
	{
		// store count before modification
		int count = _bullets.Count;

		for(int i = 0; i < count; i++)
		{
			RemoveBullet(_bullets.First().Key);
		}
	}

	public void StartPattern(string path)
	{
		ClearBullets();
		_pattern = new BulletPattern();
		Pattern.ParseXML(path);

		Bullet top = new Bullet(this);
		_topBullet = Instantiate(_bulletPrefab);
		top.InitTopNode(Pattern.RootNode);

		_topBullet.Initialize(top);
		_topBullet.Hide();

		_bullets.Add(top, _topBullet);
	}

	public Bullet CreateBullet(Bullet source, bool top)
	{
		Bullet bullet = new Bullet(this);
		bullet.OnFinishSetup += InitializeUnityBullet;
		UnityBullet unityBullet = Instantiate(_bulletPrefab);
		unityBullet.CombatManager = this;
		if(top)
		{
			unityBullet.Hide();
		}

		_bullets.Add(bullet, unityBullet);

		return bullet;
	}

	public Vector2 PlayerPosition(Bullet targettedBullet)
	{
		return Vector2.zero;
	}

	public void RemoveBullet(Bullet deadBullet)
	{
		Destroy(_bullets[deadBullet].gameObject);
		_bullets.Remove(deadBullet);
	}

	public void Trigger(Bullet source, string name)
	{
		throw new System.NotImplementedException();
	}

	public void InitializeUnityBullet(Bullet bullet)
	{
		_bullets[bullet].Initialize(bullet);

		bullet.OnFinishSetup -= InitializeUnityBullet;
	}
}