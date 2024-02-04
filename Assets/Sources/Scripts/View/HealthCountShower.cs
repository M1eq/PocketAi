using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthCountShower : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthCountText;
    [SerializeField] private Image _healthBar;

    public void Show(int currentHealth)
    {
        _healthCountText.text = currentHealth.ToString();
        _healthBar.fillAmount = currentHealth / 100;
    }
}
