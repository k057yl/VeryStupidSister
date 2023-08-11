using UnityEngine;
using Zenject;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    
    private Transform _targetTransform;

    [Inject]
    private void Construct(CharController charController)
    {
        _targetTransform = charController.transform;
    }

    private void LateUpdate()
    {
        FollowCharacter();
    }

    private void FollowCharacter()
    {
        transform.position = _targetTransform.position + _offset;
    }
}
