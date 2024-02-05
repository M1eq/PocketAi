using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ItemCreator : MonoBehaviour
{
    public Cell[] InventoryCells => _cells;

    [SerializeField] private InventoryItemPresenter[] _items;
    [SerializeField] private Cell[] _cells;

    private List<Cell> _emptyCells = new List<Cell>();
    private List<Cell> _notStackOccupiedCells = new List<Cell>();
    private InteractionPanelShower _interactionPanelShower;
    private Canvas _inventoryCanvas;
    private Health _playerHealth;
    private ClothesEquiper _clothesEquiper;
    private JsonSaveSystem _jsonSaveSystem;

    private bool CanCreateStartItems => _emptyCells.Count >= _items.Length;

    [Inject]
    private void Construct(InteractionPanelShower interactionPanel, Canvas inventoryCanvas, Health playerHealth, ClothesEquiper clothesEquiper)
    {
        _interactionPanelShower = interactionPanel;
        _inventoryCanvas = inventoryCanvas;
        _clothesEquiper = clothesEquiper;
        _playerHealth = playerHealth;
    }

    public void TryCreateStartItems(JsonSaveSystem jsonSaveSystem)
    {
        _jsonSaveSystem = jsonSaveSystem;

        InitializeCells();

        if (CanCreateStartItems)
        {
            for (int i = 0; i < _items.Length; i++)
            {
                CreateItem(_items[i], _emptyCells[i], _items[i].InventoryItem.StackCount);
                SaveCreatedItem(_items[i].InventoryItem.ItemID, _items[i].InventoryItem.StackCount);
            }
        }
    }

    public void TryRestoreSavedItems(JsonSaveSystem jsonSaveSystem, ClothesEquiper clothesEquiper)
    {
        _jsonSaveSystem = jsonSaveSystem;

        TryRestoreHeadClothes(clothesEquiper);
        TryRestoreBodyClothes(clothesEquiper);

        InitializeCells();

        for (int i = 0; i < _jsonSaveSystem.SaveData.ItemsId.Count; i++)
        {
            for (int j = 0; j < _items.Length; j++)
            {
                if (_jsonSaveSystem.SaveData.ItemsId[i] == _items[j].InventoryItem.ItemID)
                {
                    CreateItem(_items[j], _emptyCells[i], _jsonSaveSystem.SaveData.InventoryItemsCount[i]);
                }
            }
        }
    }

    public void TryCreateRandomLoot()
    {
        InitializeCells();

        if (_emptyCells.Count > 0)
        {
            int itemNumber = Random.Range(0, _items.Length);
            int cellNumber = Random.Range(0, _emptyCells.Count);

            CreateItem(_items[itemNumber], _emptyCells[cellNumber], _items[itemNumber].InventoryItem.StackCount);
            SaveCreatedItem(_items[itemNumber].InventoryItem.ItemID, _items[itemNumber].InventoryItem.StackCount);
        }
    }

    private void InitializeCells()
    {
        _emptyCells.Clear();
        _notStackOccupiedCells.Clear();

        foreach (Cell cell in _cells)
        {
            if (cell.Occupied == false && _emptyCells.Contains(cell) == false)
            {
                _emptyCells.Add(cell);
            }

            if (cell.Occupied == true && _emptyCells.Contains(cell) == false)
            {
                if (cell.OccupiedItem.ItemsCount < cell.OccupiedItem.StackCount)
                    _notStackOccupiedCells.Add(cell);
            }
        }
    }

    private void CreateItem(InventoryItemPresenter itemPrefab, Cell cell, int itemCount)
    {
        InventoryItemPresenter itemPresenter = Instantiate(itemPrefab);
        itemPresenter.Initialize(_interactionPanelShower, _inventoryCanvas);

        TryInitializeMedKit(itemPresenter);
        TryInitializeBodyClothes(itemPresenter);
        TryInitializeHeadClothes(itemPresenter);

        itemPresenter.InventoryItem.SetItemCount(itemCount);
        itemPresenter.InventoryItem.InitializeItem();

        cell.Occupie(itemPresenter.InventoryItem);
    }

    private InventoryItem CreateItem(InventoryItemPresenter itemPrefab, int itemCount)
    {
        InventoryItemPresenter itemPresenter = Instantiate(itemPrefab);
        itemPresenter.Initialize(_interactionPanelShower, _inventoryCanvas);

        TryInitializeMedKit(itemPresenter);
        TryInitializeBodyClothes(itemPresenter);
        TryInitializeHeadClothes(itemPresenter);

        itemPresenter.InventoryItem.SetItemCount(itemCount);
        itemPresenter.InventoryItem.InitializeItem();

        return itemPresenter.InventoryItem;
    }

    private void TryRestoreHeadClothes(ClothesEquiper clothesEquiper)
    {
        for (int i = 0; i < _items.Length; i++)
        {
            if (_jsonSaveSystem.SaveData.EquipedHeadClothesId == _items[i].InventoryItem.ItemID)
            {
                InventoryItem headClothes = CreateItem(_items[i], _items[i].InventoryItem.StackCount);
                clothesEquiper.EquipHeadClothes((HeadClothes)headClothes);
            }
        }
    }

    private void TryRestoreBodyClothes(ClothesEquiper clothesEquiper)
    {
        for (int i = 0; i < _items.Length; i++)
        {
            if (_jsonSaveSystem.SaveData.EquipedBodyClothesId == _items[i].InventoryItem.ItemID)
            {
                InventoryItem bodyClothes = CreateItem(_items[i], _items[i].InventoryItem.StackCount);
                clothesEquiper.EquipBodyClothes((BodyClothes)bodyClothes);
            }
        }
    }

    private void TryInitializeMedKit(InventoryItemPresenter itemPresenter)
    {
        if (itemPresenter.TryGetComponent<MedKitItemPresenter>(out MedKitItemPresenter medKitItemPresenter))
            medKitItemPresenter.SetPlayerHealth(_playerHealth);
    }

    private void TryInitializeBodyClothes(InventoryItemPresenter itemPresenter)
    {
        if (itemPresenter.TryGetComponent<BodyClothesItemPresenter>(out BodyClothesItemPresenter bodyClothesItemPresenter))
            bodyClothesItemPresenter.SetClothesEquiper(_clothesEquiper);
    }

    private void TryInitializeHeadClothes(InventoryItemPresenter itemPresenter)
    {
        if (itemPresenter.TryGetComponent<HeadClothesItemPresenter>(out HeadClothesItemPresenter headClothesItemPresenter))
            headClothesItemPresenter.SetClothesEquiper(_clothesEquiper);
    }

    private void SaveCreatedItem(string itemId, int itemsCount)
    {
        _jsonSaveSystem.SaveData.ItemsId.Add(itemId);
        _jsonSaveSystem.SaveData.InventoryItemsCount.Add(itemsCount);
    }
}
