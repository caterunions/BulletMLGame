using System;

using UnityEngine;

public class HealthDamageReceiver : MonoBehaviour
{
	public event Action<HealthDamageReceiver, float> OnDamage;
	public event Action<HealthDamageReceiver, float, bool> OnHeal;

	[SerializeField]
	private float _maxHP;
	public float MaxHP => _maxHP;

	public float HP { get; private set; }

	public float Damage(float damage)
	{
		if (damage <= 0f) return 0f;

		HP -= damage;

		OnDamage?.Invoke(this, damage);

		return damage;
	}

	public float Heal(float heal)
	{
		if(heal <= 0f) return 0f;

		HP += heal;
		bool maxed = false;

		if (HP > MaxHP)
		{
			HP = MaxHP;
			maxed = true;
		}

		OnHeal?.Invoke(this, heal, maxed);

		return heal;
	}
}
