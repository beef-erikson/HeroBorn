/********************************
 * PlayerBehavior.cs
 * Handles player movement, jumping, shooting.
 * Last Edit: 3-3-23
 * Troy Martin
 *
 * Private Methods:
 * private bool IsGrounded() - Returns whether the player is on the ground or not.
 * 
 ********************************/

using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    public float jumpVelocity = 5f;
    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;

    public GameObject bullet;
    public float bulletSpeed = 100f;

    public delegate void JumpingEvent();
    public event JumpingEvent PlayerJump;
    
    private float _vInput;
    private float _hInput;
    private Rigidbody _rb;
    private CapsuleCollider _collider;
    private bool _isJumping;
    private bool _isShooting;
    
    private GameBehavior _gameManager;

    /// <summary>
    /// Grabs components
    /// </summary>
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameBehavior>();
    }

    /// <summary>
    /// Inputs
    /// </summary>
    private void Update()
    {
        _vInput = Input.GetAxis("Vertical") * moveSpeed;
        _hInput = Input.GetAxis("Horizontal") * rotateSpeed;

        _isJumping |= Input.GetKeyDown(KeyCode.Space);
        _isShooting |= Input.GetMouseButtonDown(0);

        /* 
        // Using translate and rotate for movement
        this.transform.Translate(Vector3.forward * _vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * _hInput * Time.deltaTime);
        */
    }

    // FixedUpdate for rigidbodies
    private void FixedUpdate()
    {
        // Movement
        var rotation = Vector3.up * _hInput;
        var angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        var thisTransform = this.transform;
        _rb.MovePosition(thisTransform.position + thisTransform.forward * (_vInput * Time.fixedDeltaTime));
        _rb.MoveRotation(_rb.rotation * angleRot);

        // Jumping
        if (IsGrounded() && _isJumping)
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            PlayerJump!();
        }

        _isJumping = false;

        // Shooting
        if (_isShooting)
        {
            var newBullet = Instantiate(bullet, this.transform.position + new Vector3(0,0,1), this.transform.rotation);
            var bulletRb = newBullet.GetComponent<Rigidbody>();

            // velocity is used here so gravity isn't affecting the bullet
            bulletRb.velocity = this.transform.forward * bulletSpeed;
        }

        _isShooting = false;
    }

    /// <summary>
    /// Takes away a hit point if collision is with Enemy.
    /// </summary>
    /// <param name="collision">Other object in collision.</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            _gameManager.HP -= 1;
        }
    }

    /// <summary>
    /// Returns whether the player is on the ground or not
    /// </summary>
    /// <returns>Is the object grounded?</returns>
    private bool IsGrounded()
    {
        // center x, min y, center z is the bottom of the capsule
        var bounds = _collider.bounds;
        var capsuleBottom = new Vector3(bounds.center.x, bounds.min.y, bounds.center.z);

        // start of capsule, end of capsule, radius, layer mask, query trigger
        var grounded = Physics.CheckCapsule(bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);

        return grounded;
    }
}
