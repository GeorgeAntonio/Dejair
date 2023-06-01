using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private bool facingRight = true;

    public Animator anim;
    public float speed;
    public float boostedSpeed;
    public int vidaHeroi = 100;

    float tempo = 0;
    float delay = 0.5f;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (Time.time - tempo > delay)
            {
                tempo = Time.time;
                vidaHeroi -= 10;
                if (vidaHeroi <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleInput();

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.magnitude);

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? boostedSpeed : speed;
        movement = movement.normalized * currentSpeed * Time.deltaTime;
        playerRb.MovePosition(transform.position + movement);
    }

    private void HandleInput()
    {
        Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        if (dir.x > 0 && !facingRight || dir.x < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
