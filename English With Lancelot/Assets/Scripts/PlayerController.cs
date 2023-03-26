using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";
    
    [SerializeField] private float speed;

    private Rigidbody2D _player;

    private void Start() => _player = GetComponent<Rigidbody2D>();

    private void FixedUpdate() => Move();

    private void Move()
    {
        var horizontalMovement = Input.GetAxis(HorizontalAxis);
        var verticalMovement = Input.GetAxis(VerticalAxis);
        
        var totalMovement = new Vector2(horizontalMovement, verticalMovement);
        
        _player.velocity = totalMovement * speed;
    }
}