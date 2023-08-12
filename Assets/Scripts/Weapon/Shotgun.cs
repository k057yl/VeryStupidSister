using UnityEngine;

public class Shotgun : WeaponBase
{
    private int _ammoCount = 5;

    public void Fire()
    {
        if (_ammoCount > 0)
        {
            Debug.Log("Shotgun: Boom!");
            _ammoCount--;
        }
        else
        {
            Debug.Log("Shotgun: Out of ammo!");
        }
    }

    public void Reloaded()
    {
        Debug.Log("Reload");
    }

    public bool GetIsReloading()
    {
        return false;
    }
}
