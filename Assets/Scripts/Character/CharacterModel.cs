using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterModel
{
    private int _health = Constants.ONE_HUNDRED;

    public int Health
    {
        get { return _health; }
        set { _health = value; }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Take Damage!!!");
        
        Health -= damage;
        if (Health <= Constants.ZERO)
        {
            SceneManager.LoadScene(Constants.ZERO);
        }
    }
}
