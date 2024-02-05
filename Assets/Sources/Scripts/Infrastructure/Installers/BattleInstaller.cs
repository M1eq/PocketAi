using UnityEngine;
using Zenject;

public class BattleInstaller : MonoInstaller
{
    [SerializeField] private EnemyCharacter _enemyCharacterPrefab;
    [SerializeField] private PlayerCharacter _playerCharacterPrefab;
    [SerializeField] private BattlePresenter _battlePresenterPrefab;
    [SerializeField] private Canvas _battleCanvasPrefab;
    [SerializeField] private Transform _gameAreaParent;

    public override void InstallBindings()
    {
        Canvas battleCanvas = Instantiate(_battleCanvasPrefab, _gameAreaParent);

        PlayerCharacter playerCharacter = Container.InstantiatePrefabForComponent<PlayerCharacter>(
            _playerCharacterPrefab, battleCanvas.transform);

        EnemyCharacter enemyCharacter = Container.InstantiatePrefabForComponent<EnemyCharacter>(
            _enemyCharacterPrefab, battleCanvas.transform);

        Container.Bind<PlayerCharacter>().FromInstance(playerCharacter).AsSingle();
        Container.Bind<EnemyCharacter>().FromInstance(enemyCharacter).AsSingle();
        Container.InstantiatePrefabForComponent<BattlePresenter>(_battlePresenterPrefab, battleCanvas.transform);
    }
}
