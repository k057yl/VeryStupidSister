using System.Threading.Tasks;
using UnityEngine;

public class AmmoSystem
{
    private int _maxAmmo;
    private int _magazineSize;
    private int _currentAmmo;
    private bool _isReloading;
    public bool IsReloading
    {
        get { return _isReloading; }
    }
    private UIBar _uiBar;

    public AmmoSystem(int maxAmmo, int magazineSize, UIBar uiBar)
    {
        _maxAmmo = maxAmmo;
        _magazineSize = magazineSize;
        _currentAmmo = _magazineSize;
        _uiBar = uiBar;
    }

    public int GetCurrentAmmo()
    {
        return _currentAmmo;
    }
    
    public int GetMaxAmmo()
    {
        return _maxAmmo;
    }
    
    public bool CanFire()
    {
        return _currentAmmo > Constants.ZERO && !_isReloading;
    }

    public void Fire()
    {
        if (CanFire())
        {
            _currentAmmo--;

            Debug.Log("Осталось патронов: " + _currentAmmo);
            
            _uiBar.UpdateAmmoText(GetCurrentAmmo(), GetMaxAmmo());

            if (_currentAmmo == Constants.ZERO)
            {
                Debug.Log("Обойма пуста. Необходима перезарядка.");
                ReloadAsync();
            }
        }
        else
        {
            Debug.Log("Невозможно произвести выстрел. Обойма пуста или идет перезарядка.");
        }
    }
    
    public async Task ReloadAsync()
    {
        if (!_isReloading)
        {
            _isReloading = true;

            Debug.Log("Начинается перезарядка...");
            await Task.Delay(Constants.THREE_THOUSAND);

            int ammoToAdd = Mathf.Min(_maxAmmo - _currentAmmo, _magazineSize);
            _currentAmmo += ammoToAdd;
            _maxAmmo -= ammoToAdd;

            Debug.Log("Обойма перезаряжена. Патронов: " + _currentAmmo);

            _isReloading = false;

            _uiBar.UpdateAmmoText(GetCurrentAmmo(), GetMaxAmmo());
        }
    }
    
    public async void ReloadByButton()
    {
        if (!_isReloading && _currentAmmo < _magazineSize)
        {
            _isReloading = true;

            Debug.Log("Начинается перезарядка по нажатию кнопки R...");
            await ReloadAsync();

            await Task.Delay(Constants.THREE_THOUSAND);

            int ammoToAdd = Mathf.Min(_magazineSize - _currentAmmo, _maxAmmo);
            _currentAmmo += ammoToAdd;
            _maxAmmo -= ammoToAdd;

            _isReloading = false;

            Debug.Log("Обойма перезаряжена. Патронов: " + _currentAmmo);

            _uiBar.UpdateAmmoText(GetCurrentAmmo(), GetMaxAmmo());
        }
    }
}