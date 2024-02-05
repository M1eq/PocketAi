using UnityEngine;
using Zenject;

public class InventoryInstaller : MonoInstaller
{
    [SerializeField] private PlayerParameters _playerParameters;
    [Space(10), SerializeField] private Transform _gameAreaParent;
    [SerializeField] private Canvas _inventoryCanvasPrefab;
    [SerializeField] private ItemCreator _itemCreatorPrefab;
    [SerializeField] private InteractionPanelShower _interactionPanelPrefab;
    [SerializeField] private ClothesEquiper _clothesEquiperPrefab;
    [SerializeField] private LoseMenu _loseMenuPrefab;

    private Canvas _inventoryCanvas;
    private InteractionPanelShower _interactionPanel;
    private ClothesEquiper _clothesEquiper;
    private LoseMenu _loseMenu;
    private JsonSaveSystem _jsonSaveSystem;

    private bool CanCreateStartItems =>
        _jsonSaveSystem.SaveData.ItemsId.Count == 0 || _jsonSaveSystem.SaveData.ItemsId == null;

    public override void InstallBindings()
    {
        BindSaveSystem();
        InstantiateInventoryEnvironment();
        BindInventoryEnvironment();
        BindPlayerHealth();
        BindItemCreator();
        FixEvironmentHierarchy();
    }

    private void BindSaveSystem()
    {
        _jsonSaveSystem = new JsonSaveSystem();
        _jsonSaveSystem.Load();

        Container.Bind<JsonSaveSystem>().FromNew().AsSingle();
    }

    private void InstantiateInventoryEnvironment()
    {
        _inventoryCanvas = Instantiate(_inventoryCanvasPrefab, _gameAreaParent);
        _interactionPanel = Instantiate(_interactionPanelPrefab, _inventoryCanvas.transform);

        _clothesEquiper = Container.InstantiatePrefabForComponent<ClothesEquiper>(
            _clothesEquiperPrefab, _inventoryCanvas.transform);

        _loseMenu = Container.InstantiatePrefabForComponent<LoseMenu>(
             _loseMenuPrefab, _inventoryCanvas.transform);
    }

    private void BindInventoryEnvironment()
    {
        Container.Bind<LoseMenu>().FromInstance(_loseMenu).AsSingle();
        Container.Bind<ClothesEquiper>().FromInstance(_clothesEquiper).AsSingle();
        Container.Bind<InteractionPanelShower>().FromInstance(_interactionPanel).AsSingle();
        Container.Bind<Canvas>().FromInstance(_inventoryCanvas).AsSingle();
    }

    private void BindPlayerHealth()
    {
        Health health = new Health();
        health.Initialize(_playerParameters.MaxHealth, _jsonSaveSystem.SaveData.PlayerHealth);

        Container.Bind<Health>().FromInstance(health).AsSingle();
    }

    private void BindItemCreator()
    {
        ItemCreator itemCreator = Container.InstantiatePrefabForComponent<ItemCreator>(
            _itemCreatorPrefab, _inventoryCanvas.transform);

        Container.Bind<ItemCreator>().FromInstance(itemCreator).AsSingle();
        Container.Bind<Cell[]>().FromInstance(itemCreator.InventoryCells).AsSingle();

        if (CanCreateStartItems)
            itemCreator.TryCreateStartItems(_jsonSaveSystem);
        else
            itemCreator.TryRestoreSavedItems(_jsonSaveSystem);
    }

    private void FixEvironmentHierarchy()
    {
        _interactionPanel.transform.SetAsLastSibling();
        _loseMenu.transform.SetAsLastSibling();
    }
}