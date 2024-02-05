using UnityEngine;
using Zenject;

public class InventoryInstaller : MonoInstaller
{
    [SerializeField] private Transform _gameAreaParent;
    [SerializeField] private Canvas _inventoryCanvasPrefab;
    [SerializeField] private ItemCreator _itemCreatorPrefab;
    [SerializeField] private InteractionPanelShower _interactionPanelPrefab;
    [SerializeField] private ClothesEquiper _clothesEquiperPrefab;
    [SerializeField] private LoseMenu _loseMenuPrefab;

    public override void InstallBindings()
    {
        Canvas inventoryCanvas = Instantiate(_inventoryCanvasPrefab, _gameAreaParent);
        InteractionPanelShower interactionPanel = Instantiate(_interactionPanelPrefab, inventoryCanvas.transform);

        ClothesEquiper clothesEquiper = Container.InstantiatePrefabForComponent<ClothesEquiper>(
            _clothesEquiperPrefab, inventoryCanvas.transform);

        LoseMenu loseMenu = Container.InstantiatePrefabForComponent<LoseMenu>(
            _loseMenuPrefab, inventoryCanvas.transform);

        Container.Bind<LoseMenu>().FromInstance(loseMenu).AsSingle();
        Container.Bind<ClothesEquiper>().FromInstance(clothesEquiper).AsSingle();
        Container.Bind<InteractionPanelShower>().FromInstance(interactionPanel).AsSingle();
        Container.Bind<Canvas>().FromInstance(inventoryCanvas).AsSingle();
        Container.Bind<Health>().FromNew().AsSingle();

        ItemCreator itemCreator = Container.InstantiatePrefabForComponent<ItemCreator>(_itemCreatorPrefab, inventoryCanvas.transform);
        Container.Bind<ItemCreator>().FromInstance(itemCreator).AsSingle();
        Container.Bind<Cell[]>().FromInstance(itemCreator.InventoryCells).AsSingle();

        itemCreator.TryCreateStartItems();
        interactionPanel.transform.SetAsLastSibling();
        loseMenu.transform.SetAsLastSibling();
    }
}