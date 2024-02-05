using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BattlePresenter : MonoBehaviour
{
    [SerializeField] private Battle _battle;
    [SerializeField] private Button _shootButton;
    [SerializeField] private Button _equipPistolButton;
    [SerializeField] private Button _equipAutomaticGunButton;
    [SerializeField] private Outline _pistolButtonOutline;
    [SerializeField] private Outline _automaticGunButtonOutline;

    private PlayerCharacter _playerCharacter;

    private void OnAmmoInserted() => _shootButton.interactable = true;
    private void OnAmmoInsertBreaked() => _shootButton.interactable = false;
    private void OnBattleLoopLaunched() => _shootButton.gameObject.SetActive(false);

    private void OnBattleLoopEnded()
    {
        _playerCharacter.WeaponEquiper.EquippedWeapon.TryInsertAmmo();
        _shootButton.gameObject.SetActive(true);
    }

    [Inject]
    private void Construct(PlayerCharacter playerCharacter, EnemyCharacter enemyCharacter)
    {
        _battle.Initialize(playerCharacter, enemyCharacter);

        _playerCharacter = playerCharacter;
        _playerCharacter.WeaponEquiper.WeaponEquipped += OnWeaponEquipped;
        OnEquipPistolButtonPressed();
    }

    private void OnWeaponEquipped()
    {
        _playerCharacter.WeaponEquiper.EquippedWeapon.AmmoInserted += OnAmmoInserted;
        _playerCharacter.WeaponEquiper.EquippedWeapon.AmmoInsertBreaked += OnAmmoInsertBreaked;
        _playerCharacter.WeaponEquiper.EquippedWeapon.TryInsertAmmo();
    }

    private void OnEquipPistolButtonPressed()
    {
        TryRemoveWeaponListeners();
        _playerCharacter.WeaponEquiper.EquipPistol();
        ActivateOutline(true, false);
    }

    private void OnEquipAutomaticGunButtonPressed()
    {
        TryRemoveWeaponListeners();
        _playerCharacter.WeaponEquiper.EquipAutomaticWeapon();
        ActivateOutline(false, true);
    }

    private void ActivateOutline(bool activatePistolOutline, bool activateAutomaticGunOutline)
    {
        _pistolButtonOutline.enabled = activatePistolOutline;
        _automaticGunButtonOutline.enabled = activateAutomaticGunOutline;
    }

    private void TryRemoveWeaponListeners()
    {
        if (_playerCharacter.WeaponEquiper.EquippedWeapon != null)
        {
            _playerCharacter.WeaponEquiper.EquippedWeapon.AmmoInserted -= OnAmmoInserted;
            _playerCharacter.WeaponEquiper.EquippedWeapon.AmmoInsertBreaked -= OnAmmoInsertBreaked;
        }
    }

    private void OnEnable()
    {
        _equipPistolButton.onClick.AddListener(() => OnEquipPistolButtonPressed());
        _equipAutomaticGunButton.onClick.AddListener(() => OnEquipAutomaticGunButtonPressed());
        _shootButton.onClick.AddListener(() => _battle.LaunchBattleLoop());

        _battle.BattleLoopLaunched += OnBattleLoopLaunched;
        _battle.BattleLoopEnded += OnBattleLoopEnded;

    }

    private void OnDisable()
    {
        _equipPistolButton.onClick.RemoveAllListeners();
        _equipAutomaticGunButton.onClick.RemoveAllListeners();
        _shootButton.onClick.RemoveAllListeners();

        _battle.BattleLoopLaunched -= OnBattleLoopLaunched;
        _battle.BattleLoopEnded -= OnBattleLoopEnded;
        _playerCharacter.WeaponEquiper.WeaponEquipped -= OnWeaponEquipped;
        TryRemoveWeaponListeners();
    }
}
