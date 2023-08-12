using UnityEngine;

public class Pistol : WeaponBase
{
    public void Fire()
    {
        Debug.Log("Pistol: Pew pew!");
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
