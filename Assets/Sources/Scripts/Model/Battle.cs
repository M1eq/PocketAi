using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Battle : MonoBehaviour
{
    public event UnityAction BattleLoopLaunched;
    public event UnityAction BattleLoopEnded;

    private PlayerCharacter _playerCharacter;
    private EnemyCharacter _enemyCharacter;

    public void LaunchBattleLoop() => StartCoroutine(BattleLoopCoroutine());

    public void Initialize(PlayerCharacter playerCharacter, EnemyCharacter enemyCharacter)
    {
        _playerCharacter = playerCharacter;
        _enemyCharacter = enemyCharacter;

        _playerCharacter.Health.RefillHealth();
        _enemyCharacter.Health.RefillHealth();
    }

    private IEnumerator BattleLoopCoroutine()
    {
        BattleLoopLaunched?.Invoke();

        _enemyCharacter.Health.TakeDamage(_playerCharacter.WeaponEquiper.EquippedWeapon.GetShootDamage());
        yield return new WaitForSeconds(1);

        _playerCharacter.Health.TakeDamage(10);
        BattleLoopEnded?.Invoke();
    }
}
