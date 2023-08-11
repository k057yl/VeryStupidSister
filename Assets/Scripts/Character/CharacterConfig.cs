using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStatsConfig",menuName = "Configs")]
public class CharacterConfig : ScriptableObject
{
    public float JumpHeight;
    public float Speed;
    public LayerMask GroundMask;
    public float GroundCheckDistance;
    public float FallGravityScale;
}
