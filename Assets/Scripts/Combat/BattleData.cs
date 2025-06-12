using NUnit.Framework;

using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BattleData", menuName = "ScriptableObjects/BattleData")]
public class BattleData : ScriptableObject
{
	[SerializeField]
	private List<BulletVisuals> _bulletBank = new List<BulletVisuals>();

	public BulletVisuals GetVisuals(string name)
	{
		return null;
	}
}


[Serializable]
public class AttackData
{
	[SerializeField]
	private TextAsset _xmlPattern;
	public TextAsset XmlPattern => _xmlPattern;

	[SerializeField]
	private AttackType _attackType;
	public AttackType AttackType => _attackType;

	[SerializeField]
	private float _duration;
	public float Duration => _duration;

	[SerializeField]
	private float _hpThreshold;
	public float HPThreshold => _hpThreshold;
}

[Serializable]
public class PhaseData
{
	[SerializeField]
	public List<AttackData> Attacks = new List<AttackData>();

	[SerializeField]
	private PhaseChoiceType _choiceType;
	public PhaseChoiceType ChoiceType => _choiceType;

	[SerializeField]
	private bool _loop;
	public bool Loop => _loop;

	[SerializeField]
	private float _hpThreshold;
	public float HPThreshold => _hpThreshold;
}

public enum AttackType
{
	Timed,
	HPThreshold
}

public enum PhaseChoiceType
{
	Ordered,
	Random
}