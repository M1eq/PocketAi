using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthCountShower : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthCountText;
    [SerializeField] private Image _healthBar;

    public void Show(int currentHealth, int maxHealth)
    {
        _healthCountText.text = currentHealth.ToString();
        _healthBar.fillAmount = (currentHealth * 1) / (maxHealth * 1);
    }
}
