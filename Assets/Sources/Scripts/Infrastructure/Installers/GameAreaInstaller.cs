using UnityEngine;
using Zenject;

public class GameAreaInstaller : MonoInstaller
{
    [SerializeField] private Transform _gameAreaParent;
    [SerializeField] private Canvas _fightCanvasPrefab;
    [SerializeField] private Canvas _inventoryCanvasPrefab;
    [SerializeField] private ItemCreator _itemCreatorPrefab;
    [SerializeField] private InteractionPanelShower _interactionPanelPrefab;

    public override void InstallBindings()
    {
        Instantiate(_fightCanvasPrefab, _gameAreaParent);
        Canvas inventoryCanvas = Instantiate(_inventoryCanvasPrefab, _gameAreaParent);

        InteractionPanelShower interactionPanel = Instantiate(_interactionPanelPrefab, inventoryCanvas.transform);

        Container.Bind<InteractionPanelShower>().FromInstance(interactionPanel).AsSingle();
        Container.Bind<Canvas>().FromInstance(inventoryCanvas).AsSingle();

        ItemCreator itemCreator = Container.InstantiatePrefabForComponent<ItemCreator>(_itemCreatorPrefab, inventoryCanvas.transform);
        itemCreator.TryCreateStartItems();
        interactionPanel.transform.SetAsLastSibling();
    }
}