using UnityEngine;

public class ClothesEquiperPresenter : MonoBehaviour
{
    [SerializeField] private ClothesEquiper _clothesEquiper;
    [SerializeField] private ClothesProtectionShower _clothesProtectionShower;

    private void OnHeadClothesEquiped(int protection) => _clothesProtectionShower.ShowHeadProtection(protection);
    private void OnBodyClothesEquiped(int protection) => _clothesProtectionShower.ShowBodyProtection(protection);
    private void OnHeadClothesReseted() => _clothesProtectionShower.ShowResetedHeadProtection();
    private void OnBodyClothesReseted() => _clothesProtectionShower.ShowResetedBodyProtection();
    private void Update() => _clothesEquiper.TryResetEquipedClothes();

    private void OnEnable()
    {
        _clothesEquiper.HeadClothesEquiped += OnHeadClothesEquiped;
        _clothesEquiper.BodyClothesEquiped += OnBodyClothesEquiped;

        _clothesEquiper.HeadClothesReseted += OnHeadClothesReseted;
        _clothesEquiper.BodyClothesReseted += OnBodyClothesReseted;
    }

    private void OnDisable()
    {
        _clothesEquiper.HeadClothesEquiped -= OnHeadClothesEquiped;
        _clothesEquiper.BodyClothesEquiped -= OnBodyClothesEquiped;

        _clothesEquiper.HeadClothesReseted -= OnHeadClothesReseted;
        _clothesEquiper.BodyClothesReseted -= OnBodyClothesReseted;
    }
}
