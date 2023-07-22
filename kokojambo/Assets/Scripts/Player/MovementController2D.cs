using UnityEngine;

public class MovementController2D : MonoBehaviour
{
   
[SerializeField]private float _maximalSpeed = 3.4f;
[SerializeField]private float jumpHeight = 6.5f;
[SerializeField]private float gravityScale = 1.5f;
[SerializeField]private Camera mainCamera;

private float _speedAccuracy = 0.01f;
private bool _facingRight = true;
private float _moveVelocity = 0;
private bool _isGrounded = false;
private Vector3 _cameraPosition;
private Rigidbody2D _rigidBody;
private CapsuleCollider2D _mainCollider;
private Transform  _transform;

// Use this for initialization
void Start()
{
     _transform = transform;
    _rigidBody = GetComponent<Rigidbody2D>();
    _mainCollider = GetComponent<CapsuleCollider2D>();
    _rigidBody.freezeRotation = true;
    _rigidBody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    _rigidBody.gravityScale = gravityScale;
    _facingRight =  _transform.localScale.x > 0;

    if (mainCamera)
    {
        _cameraPosition = mainCamera.transform.position;
    }
}

// Update is called once per frame
void Update()
{
    // Movement controls
    if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && (_isGrounded || Mathf.Abs(_rigidBody.velocity.x) > _speedAccuracy))///Movement system dlya daunov?
    {
        _moveVelocity = Input.GetKey(KeyCode.A) ? -1 : 1;
    }
    else
    {
        if (_isGrounded || _rigidBody.velocity.magnitude < _speedAccuracy) //Round if velocity too small ///spasibo blyat' luche by magicheskie chisla ubral eblan
        {
            _moveVelocity = 0;
        }
    }

    // Change facing direction
    if (_moveVelocity != 0)
    {
        if (_moveVelocity > 0 && !_facingRight)
        {
            _facingRight = true;
             _transform.localScale = new Vector3(Mathf.Abs( _transform.localScale.x),  _transform.localScale.y, transform.localScale.z);
        }
        if (_moveVelocity < 0 && _facingRight)
        {
            _facingRight = false;
             _transform.localScale = new Vector3(-Mathf.Abs( _transform.localScale.x),  _transform.localScale.y,  _transform.localScale.z);
        }
    }

    // Jumping
    if (Input.GetKeyDown(KeyCode.W) && _isGrounded)
    {
        _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, jumpHeight);
    }

    // Camera follow
    if (mainCamera)
    {
        mainCamera.transform.position = new Vector3( _transform.position.x, _cameraPosition.y, _cameraPosition.z);
    }
}

void FixedUpdate()
{
    Bounds colliderBounds = _mainCollider.bounds;
    float colliderRadius = _mainCollider.size.x * 0.4f * Mathf.Abs(transform.localScale.x);///WTF Ebanye magicheskie chisla chto za daun eto pisal ya ustal refactorit' ego kod
    Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0); ///dolboeb X2 cho za chisla suka (>~<)
    // Check if player is grounded
    Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);
    //Check if any of the overlapping colliders are not player collider, if so, set _isGrounded to true
    _isGrounded = false;
    if (colliders.Length > 0)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i] != _mainCollider)
            {
                _isGrounded = true;
                break;
            }
        }
    }

    // Apply movement velocity
    _rigidBody.velocity = new Vector2((_moveVelocity) * _maximalSpeed, _rigidBody.velocity.y);

    // Simple debug
    Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, colliderRadius, 0), _isGrounded ? Color.green : Color.red);
    Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(colliderRadius, 0, 0), _isGrounded ? Color.green : Color.red);
}
}
