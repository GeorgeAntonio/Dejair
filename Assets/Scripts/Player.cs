using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool facingRight = true;

    public Animator anim;
    public float speed;

    float tempo = 0;
    float delay = 0.5f;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (Time.time - tempo > delay)
            {
                tempo = Time.time;
                GameController gameController = FindObjectOfType<GameController>();
                int life = gameController.getLife() - 10;
                gameController.setLife(life);
                if (life <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.magnitude);

        transform.position = transform.position + movement * speed * Time.deltaTime;
        
    }

    private void HandleInput(){      
        Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        if(dir.x > 0 && !facingRight || dir.x < 0 && facingRight){
            Flip();
        }
    }
    
    private void Flip(){
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
