using UnityEngine;
using Zenject;

public class InventoryInstaller : MonoInstaller
{
    [SerializeField] private Transform _gameAreaParent;
    [SerializeField] private Canvas _inventoryCanvasPrefab;
    [SerializeField] private ItemCreator _itemCreatorPrefab;
    [SerializeField] private InteractionPanelShower _interactionPanelPrefab;
    [SerializeField] private ClothesEquiper _clothesEquiperPrefab;

    public override void InstallBindings()
    {
        Canvas inventoryCanvas = Instantiate(_inventoryCanvasPrefab, _gameAreaParent);
        InteractionPanelShower interactionPanel = Instantiate(_interactionPanelPrefab, inventoryCanvas.transform);

        ClothesEquiper clothesEquiper = Container.InstantiatePrefabForComponent<ClothesEquiper>(
            _clothesEquiperPrefab, inventoryCanvas.transform);

        Container.Bind<ClothesEquiper>().FromInstance(clothesEquiper).AsSingle();
        Container.Bind<InteractionPanelShower>().FromInstance(interactionPanel).AsSingle();
        Container.Bind<Canvas>().FromInstance(inventoryCanvas).AsSingle();
        Container.Bind<Health>().FromNew().AsSingle();

        ItemCreator itemCreator = Container.InstantiatePrefabForComponent<ItemCreator>(_itemCreatorPrefab, inventoryCanvas.transform);
        Container.Bind<Cell[]>().FromInstance(itemCreator.InventoryCells).AsSingle();

        itemCreator.TryCreateStartItems();
        interactionPanel.transform.SetAsLastSibling();
    }
}