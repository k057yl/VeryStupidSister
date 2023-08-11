using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    
    private string _walkAnimationParameter = "Walk";
    
    
    public void PlayWalkAnimation(Vector2 direction)
    {
        _anim.SetFloat(_walkAnimationParameter, direction.magnitude);
    }
  
    public void FlipCharacter(bool isFacingRight)
    {
        transform.localScale = new Vector3(isFacingRight ? Constants.ONE : Constants.MINUS_ONE, Constants.ONE, Constants.ONE);
    }
    
    public void PlayJumpTrigger()
    {
        _anim.SetTrigger("Jump");
    }
    
    public void DisableWalkAnimation()
    {
        _anim.SetFloat(_walkAnimationParameter, Constants.ZERO);
    }
}