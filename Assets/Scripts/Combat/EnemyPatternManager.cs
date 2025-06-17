using UnityEngine;
using BulletMLLib;
using System.Collections.Generic;
using System.Linq;

public class EnemyPatternManager : MonoBehaviour, IBulletManager
{
	public static EnemyPatternManager Instance { get; private set; }

	[SerializeField]
	private UnityBullet _bulletPrefab;

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

	private BattleData _battleData;

	private MaterialBank _materialBank;

	private GameObject _combatPlayer;

	private BulletPattern _pattern;

	private void OnEnable()
	{
		//IMSORRY yucky singleton but needed for equations :/
		Instance = this;
	}

	public void Initialize(BattleData battleData, MaterialBank matBank, GameObject combatPlayer)
	{
		_battleData = battleData;
		_materialBank = matBank;
		_combatPlayer = combatPlayer;
	}

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

		Bullet top = new Bullet(this, true);
		UnityBullet topBullet = Instantiate(_bulletPrefab);
		top.InitTopNode(Pattern.RootNode);

		topBullet.Initialize(top);

		_bullets.Add(top, topBullet);
	}

	public Bullet CreateBullet(Bullet source, bool top)
	{
		Bullet bullet = new Bullet(this, top);
		bullet.OnFinishSetup += InitializeUnityBullet;
		UnityBullet unityBullet = Instantiate(_bulletPrefab);
		unityBullet.CombatManager = this;

		_bullets.Add(bullet, unityBullet);

		return bullet;
	}

	public Vector2 PlayerPosition(Bullet targettedBullet)
	{
		return _combatPlayer.transform.position;
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
		UnityBullet uBullet = _bullets[bullet];

		uBullet.Initialize(bullet);

		if(!bullet.Top)
		{
			BulletVisuals vis = Instantiate(_battleData.GetVisuals(bullet.Visuals), uBullet.transform);
			uBullet.Visuals = vis;
			vis.SpriteRenderer.material = _materialBank.GetElementMaterial(bullet.ElementType);
		}

		bullet.OnFinishSetup -= InitializeUnityBullet;
	}
}