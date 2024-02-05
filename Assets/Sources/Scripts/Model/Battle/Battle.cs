using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Battle : MonoBehaviour
{
    public event UnityAction BattleLoopLaunched;
    public event UnityAction BattleLoopEnded;

    private PlayerCharacter _playerCharacter;
    private EnemyCharacter _enemyCharacter;
    private bool _playerHeadWasPunched;

    public void LaunchBattleLoop() => StartCoroutine(BattleLoopCoroutine());

    public void Initialize(PlayerCharacter player, EnemyCharacter enemy, ItemCreator itemCreator, JsonSaveSystem jsonSaveSystem)
    {
        _playerCharacter = player;
        _enemyCharacter = enemy;

        _playerCharacter.Initialize();
        _enemyCharacter.Initialize(itemCreator, jsonSaveSystem);
    }

    private IEnumerator BattleLoopCoroutine()
    {
        BattleLoopLaunched?.Invoke();
        _enemyCharacter.Health.TakeDamage(_playerCharacter.WeaponEquiper.EquippedWeapon.GetShootDamage());

        yield return new WaitForSeconds(1);

        if (_playerHeadWasPunched == false)
        {
            ApplyDamageToPlayer(
                _enemyCharacter.Damage - GetPlayerProtection(_playerCharacter.ClothesEquiper.HeadClothes), true);
        }
        else
        {
            ApplyDamageToPlayer(
                _enemyCharacter.Damage - GetPlayerProtection(_playerCharacter.ClothesEquiper.BodyClothes), false);
        }

        _playerCharacter.SavePlayerData();
        _enemyCharacter.SaveEnemyData();

        BattleLoopEnded?.Invoke();
    }

    private int GetPlayerProtection(HeadClothes headClothes)
    {
        if (headClothes != null)
            return headClothes.Protection;
        else
            return 0;
    }

    private int GetPlayerProtection(BodyClothes bodyClothes)
    {
        if (bodyClothes != null)
            return bodyClothes.Protection;
        else
            return 0;
    }

    private void ApplyDamageToPlayer(int damage, bool headWasPunched)
    {
        _playerCharacter.Health.TakeDamage(damage);
        _playerHeadWasPunched = headWasPunched;
    }
}
