using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D player;
    public float speed;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        player.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);
    }
}