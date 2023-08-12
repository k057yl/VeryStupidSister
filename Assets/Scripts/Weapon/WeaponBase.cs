using UnityEngine;

public abstract class WeaponBase : MonoBehaviour, IWeapon
{
    public void Fire()
    {
    }

    public void Reloaded()
    {
        
    }

    public bool GetIsReloading()
    {
        return false;
    }
}
