using System;
using UnityEngine;
using Zenject;


[RequireComponent(typeof(Rigidbody2D))]
public class CharController : MonoBehaviour
{
    [SerializeField] private CharacterConfig _characterConfig;

    private CharacterModel _characterModel;//----------
    public CharacterModel CharacterModel => _characterModel;//---------------
    private Rigidbody2D _rigidbody2D;
    private IInput _input;
    private CharacterView _characterView;

    private bool _isGrounded;
    private UIBar _uiBar;//----------
    
    [Inject]
    private void Construct(IInput input, UIBar uiBar)//-------------
    {
        _input = input;
        _uiBar = uiBar;//-----------
    }
    
    private Vector2 _previousDirection = Vector2.zero;
    private bool _isFacingRight = false;
    
    
    private void Awake()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        _characterModel = new CharacterModel();//----------------
        
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _characterView = GetComponent<CharacterView>();
        
        SetUIHealth();
    }
    
    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        HandleInput();
        CharacterFlip();
    }

    private void SetUIHealth()//------------------
    {
        _uiBar.UpdateHealthText(CharacterModel.Health);
    }
    
    private void Move()
    {
        Vector2 movement = _input.GetMovementInput() * _characterConfig.Speed;
        _rigidbody2D.velocity = new Vector2(movement.x, _rigidbody2D.velocity.y);

        UpdateGroundedState();
        
        if (_isGrounded)
        {
            HandleGroundedMovement();
        }
        else
        {
            HandleAirborneMovement();
        }
    }

    private void UpdateGroundedState()
    {
        float groundCheckDistance = _characterConfig.GroundCheckDistance;
        Vector2 raycastOrigin = transform.position;
        Vector2 raycastDirection = Vector2.down;
        LayerMask groundMask = _characterConfig.GroundMask;

        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, raycastDirection, groundCheckDistance, groundMask);
        _isGrounded = hit.collider != null;
    }
    
    private void HandleInput()
    {
        if (_input.IsJumpTriggered() && _isGrounded)
        {
            Jump();
        }
    }
    
    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _characterConfig.JumpHeight, ForceMode2D.Impulse);
    }
    
    private void HandleGroundedMovement()
    {
        _rigidbody2D.gravityScale = Constants.ONE;
    }
    
    private void HandleAirborneMovement()
    {
        _rigidbody2D.gravityScale = _characterConfig.FallGravityScale;
    }
    
    private void CharacterFlip()
    {
        Vector2 direction = _input.GetMovementInput();

        if (direction != Vector2.zero && direction != _previousDirection)
        {
            bool isMovingRight = direction.x > Constants.ZERO;

            if (isMovingRight != _isFacingRight)
            {
                _isFacingRight = isMovingRight;
                _characterView.FlipCharacter(isMovingRight);
            }
        }
        _previousDirection = direction;
    }
//------------------
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(Constants.ENEMY))
        {
            CharacterModel.TakeDamage(Constants.TEN);
            SetUIHealth();
        }
    }
}
/*
public class CharController : MonoBehaviour
{
    [SerializeField] private CharacterConfig _characterConfig;

    private Rigidbody2D _rigidbody2D;
    private IInput _input;
    private CharacterView _characterView;

    private bool IsGrounded
    {
        get
        {
            float groundCheckDistance = _characterConfig.GroundCheckDistance;
            Vector2 raycastOrigin = transform.position;
            Vector2 raycastDirection = Vector2.down;
            LayerMask groundMask = _characterConfig.GroundMask;

            RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, raycastDirection, groundCheckDistance, groundMask);
            return hit.collider != null;
        }
    }
    
    private Vector2 _previousDirection = Vector2.zero;//----------------
    private bool _isFacingRight = false;//---------------

    [Inject]
    private void Construct(IInput input)
    {
        _input = input;
    }

    private void Awake()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _characterView = GetComponent<CharacterView>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        HandleInput();
        CharacterFlip();
    }

    private void Move()
    {
        Vector2 movement = _input.GetMovementInput() * _characterConfig.Speed;
        _rigidbody2D.velocity = new Vector2(movement.x, _rigidbody2D.velocity.y);

        if (IsGrounded)
        {
            HandleGroundedMovement();
        }
        else
        {
            HandleAirborneMovement();
        }
    }

    private void HandleInput()
    {
        if (_input.IsJumpTriggered() && IsGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _characterConfig.JumpHeight, ForceMode2D.Impulse);
    }

    private void HandleGroundedMovement()
    {
        _rigidbody2D.gravityScale = Constants.ONE;
    }

    private void HandleAirborneMovement()
    {
        _rigidbody2D.gravityScale = _characterConfig.FallGravityScale;
    }
//-----------    
    private void CharacterFlip()
    {
        Vector2 direction = _input.GetMovementInput();

        if (direction != Vector2.zero && direction != _previousDirection)
        {
            bool isMovingRight = direction.x > Constants.ZERO;

            if (isMovingRight != _isFacingRight)
            {
                _isFacingRight = isMovingRight;
                _characterView.FlipCharacter(isMovingRight);
            }
        }

        _previousDirection = direction;
    }
}
*/