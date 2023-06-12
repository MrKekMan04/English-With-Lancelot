using Mini_games;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    
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
        var horizontalMovement = Input.GetAxis(GameConstants.HorizontalAxis);
        var verticalMovement = Input.GetAxis(GameConstants.VerticalAxis);
        
        var totalMovement = new Vector2(horizontalMovement, verticalMovement);
        
        animator.SetBool(GameConstants.PlayerIsWalkingKey, false);
        
        if (totalMovement != Vector2.zero)
        {
            animator.SetBool(GameConstants.PlayerIsWalkingKey, true);
            _player.velocity = totalMovement * speed;
        }
        
        if (Input.GetAxisRaw(GameConstants.HorizontalAxis) > 0)
            _renderer.flipX = true;
        else if (Input.GetAxisRaw(GameConstants.HorizontalAxis) < 0)
            _renderer.flipX = false;
    }
}