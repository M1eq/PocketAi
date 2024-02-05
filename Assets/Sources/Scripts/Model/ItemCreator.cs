using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ItemCreator : MonoBehaviour
{
    public Cell[] InventoryCells => _cells;

    [SerializeField] private InventoryItemPresenter[] _startItems;
    [SerializeField] private InventoryItemPresenter[] _lootItems;
    [SerializeField] private Cell[] _cells;

    private List<Cell> _emptyCells = new List<Cell>();
    private InteractionPanelShower _interactionPanelShower;
    private Canvas _inventoryCanvas;
    private Health _playerHealth;

    private bool CanCreateStartItems => _emptyCells.Count >= _startItems.Length;

    [Inject]
    private void Construct(InteractionPanelShower interactionPanel, Canvas inventoryCanvas, Health playerHealth)
    {
        _interactionPanelShower = interactionPanel;
        _inventoryCanvas = inventoryCanvas;
        _playerHealth = playerHealth;
    }

    public void TryCreateStartItems()
    {
        InitializeEmptyCells();

        if (CanCreateStartItems)
        {
            for (int i = 0; i < _startItems.Length; i++)
            {
                InventoryItemPresenter startItemPresenter = Instantiate(_startItems[i]);
                startItemPresenter.Initialize(_interactionPanelShower, _inventoryCanvas);

                if (startItemPresenter.TryGetComponent<MedKitItemPresenter>(out MedKitItemPresenter medKitItemPresenter))
                    medKitItemPresenter.InitializeHealth(_playerHealth);

                startItemPresenter.InventoryItem.FillStack();
                startItemPresenter.InventoryItem.InitializeItem();

                _emptyCells[i].Occupie(startItemPresenter.InventoryItem);
            }
        }
    }

    public void TryCreateRandomLoot()
    {
        InitializeEmptyCells();
    }

    private void InitializeEmptyCells()
    {
        _emptyCells.Clear();

        foreach (Cell cell in _cells)
        {
            if (cell.Occupied == false && _emptyCells.Contains(cell) == false)
                _emptyCells.Add(cell);
        }
    }
}
