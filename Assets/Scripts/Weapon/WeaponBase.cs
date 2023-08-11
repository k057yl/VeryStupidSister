using UnityEngine;

public abstract class WeaponBase : MonoBehaviour, IWeapon
{
    public void Fire()
    {
        Debug.Log("Bang");
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
