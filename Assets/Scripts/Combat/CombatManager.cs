using UnityEngine;

public class CombatManager : MonoBehaviour
{
	[SerializeField]
	private BattleData _battleData;

	[SerializeField]
	private MaterialBank _materialBank;

	[SerializeField]
	private GameObject _combatPlayer;

	[SerializeField]
	private EnemyPatternManager _enemyPatternManager;

	private void OnEnable()
	{
		_enemyPatternManager.Initialize(_battleData, _materialBank, _combatPlayer);
	}
}
