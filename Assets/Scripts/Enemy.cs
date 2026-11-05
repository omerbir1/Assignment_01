using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D rb;

    public Player player;

    private Vector2 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        direction = (player.transform.position - transform.position).normalized;
        rb.MovePosition(rb.position + Time.fixedDeltaTime * direction * speed );
    }
}
