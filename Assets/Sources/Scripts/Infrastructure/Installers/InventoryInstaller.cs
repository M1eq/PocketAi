using UnityEngine;
using Zenject;

public class InventoryInstaller : MonoInstaller
{
    [SerializeField] private Transform _gameAreaParent;
    [SerializeField] private Canvas _inventoryCanvasPrefab;
    [SerializeField] private ItemCreator _itemCreatorPrefab;
    [SerializeField] private InteractionPanelShower _interactionPanelPrefab;

    public override void InstallBindings()
    {
        Canvas inventoryCanvas = Instantiate(_inventoryCanvasPrefab, _gameAreaParent);
        InteractionPanelShower interactionPanel = Instantiate(_interactionPanelPrefab, inventoryCanvas.transform);

        Container.Bind<InteractionPanelShower>().FromInstance(interactionPanel).AsSingle();
        Container.Bind<Canvas>().FromInstance(inventoryCanvas).AsSingle();

        ItemCreator itemCreator = Container.InstantiatePrefabForComponent<ItemCreator>(_itemCreatorPrefab, inventoryCanvas.transform);
        Container.Bind<Cell[]>().FromInstance(itemCreator.InventoryCells).AsSingle();

        itemCreator.TryCreateStartItems();
        interactionPanel.transform.SetAsLastSibling();
    }
}