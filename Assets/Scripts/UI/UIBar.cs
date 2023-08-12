using TMPro;
using UnityEngine;

public class UIBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ammoText;
    [SerializeField] private TextMeshProUGUI _totalAmmoText;
    [SerializeField] private TextMeshProUGUI _killedText;
    [SerializeField] private TextMeshProUGUI _healthText;
    

    public void UpdateAmmoText(int currentAmmo, int maxAmmo)
    {
        _ammoText.text = currentAmmo.ToString();
        _totalAmmoText.text = maxAmmo.ToString();
    }
    
    public void UpdateKilledText(int killed)
    {
        _killedText.text = killed.ToString();
    }
    
    public void UpdateHealthText(int health)
    {
        _healthText.text = health.ToString();
    }
}