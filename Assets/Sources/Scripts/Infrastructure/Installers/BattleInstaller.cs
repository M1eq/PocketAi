using UnityEngine;
using Zenject;

public class BattleInstaller : MonoInstaller
{
    [SerializeField] private EnemyCharacter _enemyCharacterPrefab;
    [SerializeField] private PlayerCharacter _playerCharacterPrefab;
    [SerializeField] private BattlePresenter _battlePresenterPrefab;
    [SerializeField] private Canvas _battleCanvasPrefab;
    [SerializeField] private Transform _gameAreaParent;

    private Canvas _battleCanvas;
    private PlayerCharacter _playerCharacter;
    private EnemyCharacter _enemyCharacter;

    public override void InstallBindings()
    {
        InstantiatePrefabsForBinding();
        BindBattle();
    }

    private void InstantiatePrefabsForBinding()
    {
         _battleCanvas = Instantiate(_battleCanvasPrefab, _gameAreaParent);

          _playerCharacter = Container.InstantiatePrefabForComponent<PlayerCharacter>(
              _playerCharacterPrefab, _battleCanvas.transform);

         _enemyCharacter = Container.InstantiatePrefabForComponent<EnemyCharacter>(
            _enemyCharacterPrefab, _battleCanvas.transform);
    }

    private void BindBattle()
    {
        Container.Bind<PlayerCharacter>().FromInstance(_playerCharacter).AsSingle();
        Container.Bind<EnemyCharacter>().FromInstance(_enemyCharacter).AsSingle();
        Container.InstantiatePrefabForComponent<BattlePresenter>(_battlePresenterPrefab, _battleCanvas.transform);
    }
}
