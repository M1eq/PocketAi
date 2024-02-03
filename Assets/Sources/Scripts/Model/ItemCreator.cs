using System.Collections.Generic;
using UnityEngine;

public class ItemCreator : MonoBehaviour
{
    [SerializeField] private InventoryItem[] _startItems;
    [SerializeField] private InventoryItem[] _lootItems;
    [SerializeField] private Cell[] _cells;

    private List<Cell> _emptyCells = new List<Cell>();

    private bool CanCreateStartItems => _emptyCells.Count >= _startItems.Length;

    public void TryCreateStartItems()
    {
        InitializeEmptyCells();

        if (CanCreateStartItems)
        {
            for (int i = 0; i < _startItems.Length; i++)
            {
                InventoryItem startItem = Instantiate(_startItems[i]);

                startItem.FillStack();
                startItem.InitializeItem();

                _emptyCells[i].Occupie(startItem);
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

    private void Awake()
    {
        TryCreateStartItems();
    }
}
