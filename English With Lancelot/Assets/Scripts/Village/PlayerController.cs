using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";
    
    [SerializeField] private Animator animator;
    [SerializeField] private float speed;
    
    private Rigidbody2D _player;
    private SpriteRenderer _renderer;

    private void Start()
    {
        _player = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    } 

    private void FixedUpdate() => Move();

    private void Move()
    {
        var horizontalMovement = Input.GetAxis(HorizontalAxis);
        var verticalMovement = Input.GetAxis(VerticalAxis);
        
        var totalMovement = new Vector2(horizontalMovement, verticalMovement);
        
        animator.SetBool("isWalking", false);
        
        if (totalMovement != Vector2.zero)
        {
            animator.SetBool("isWalking", true);
            _player.velocity = totalMovement * speed;
        }
        
        if (Input.GetAxisRaw("Horizontal") > 0)
            _renderer.flipX = true;
        else if (Input.GetAxisRaw("Horizontal") < 0)
            _renderer.flipX = false;
    }
}