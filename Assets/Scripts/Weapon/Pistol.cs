using UnityEngine;

public class Pistol : WeaponBase
{
    public void Fire()
    {
        Debug.Log("Pistol: Pew pew!");
    }

    public void Reloaded()
    {
        throw new System.NotImplementedException();
    }

    public bool GetIsReloading()
    {
        throw new System.NotImplementedException();
    }
}
