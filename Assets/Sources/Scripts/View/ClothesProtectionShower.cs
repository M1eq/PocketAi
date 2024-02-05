using TMPro;
using UnityEngine;

public class ClothesProtectionShower : MonoBehaviour
{
    [SerializeField] private TMP_Text _headProtectionText;
    [SerializeField] private TMP_Text _bodyProtectionText;

    public void ShowHeadProtection(int protection) => _headProtectionText.text = protection.ToString();
    public void ShowBodyProtection(int protection) => _bodyProtectionText.text = protection.ToString();
    public void ShowResetedHeadProtection() => _headProtectionText.text = 0.ToString();
    public void ShowResetedBodyProtection() => _bodyProtectionText.text = 0.ToString();
}
