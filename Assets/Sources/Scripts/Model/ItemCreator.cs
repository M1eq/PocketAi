using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ItemCreator : MonoBehaviour
{
    public Cell[] InventoryCells => _cells;

    [SerializeField] private InventoryItemPresenter[] _startItems;
    [SerializeField] private InventoryItemPresenter[] _lootItems;
    [SerializeField] private Cell[] _cells;

    private const int NewLootValue = 1;
    private const int IncreaseLootValue = 0;
    private List<Cell> _emptyCells = new List<Cell>();
    private List<Cell> _notStackOccupiedCells = new List<Cell>();
    private InteractionPanelShower _interactionPanelShower;
    private Canvas _inventoryCanvas;
    private Health _playerHealth;
    private ClothesEquiper _clothesEquiper;

    private bool CanCreateStartItems => _emptyCells.Count >= _startItems.Length;

    [Inject]
    private void Construct(InteractionPanelShower interactionPanel, Canvas inventoryCanvas, Health playerHealth, ClothesEquiper clothesEquiper)
    {
        _interactionPanelShower = interactionPanel;
        _inventoryCanvas = inventoryCanvas;
        _clothesEquiper = clothesEquiper;
        _playerHealth = playerHealth;
    }

    public void TryCreateStartItems()
    {
        InitializeCells();

        if (CanCreateStartItems)
        {
            for (int i = 0; i < _startItems.Length; i++)
            { 
                CreateItem(_startItems[i], _emptyCells[i]);
            }
        }
    }

    public void TryCreateRandomLoot()
    {
        InitializeCells();
        int lootValue = Random.Range(0, 2);

        if (_notStackOccupiedCells.Count > 0 && lootValue == IncreaseLootValue)
        {
            int itemNumber = Random.Range(0, _notStackOccupiedCells.Count);
            _notStackOccupiedCells[itemNumber].OccupiedItem.TryIncreaseCount();
        }
        else if (_emptyCells.Count > 0 && lootValue == NewLootValue)
        {
            int itemNumber = Random.Range(0, _lootItems.Length);
            int cellNumber = Random.Range(0, _emptyCells.Count);
            CreateItem(_lootItems[itemNumber], _emptyCells[cellNumber]);
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

    private void CreateItem(InventoryItemPresenter itemPrefab, Cell cell)
    {
        InventoryItemPresenter itemPresenter = Instantiate(itemPrefab);
        itemPresenter.Initialize(_interactionPanelShower, _inventoryCanvas);

        TryInitializeMedKit(itemPresenter);
        TryInitializeBodyClothes(itemPresenter);
        TryInitializeHeadClothes(itemPresenter);

        itemPresenter.InventoryItem.FillStack();
        itemPresenter.InventoryItem.InitializeItem();

        cell.Occupie(itemPresenter.InventoryItem);
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
}
