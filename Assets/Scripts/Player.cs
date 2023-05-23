using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField] private float moveSpeed;

    private Rigidbody2D playerRb;
    //private Animator playerAnimator;
    private bool facingRight = true;
    //private Vector2 moveVector;

    public Animator anim;
    public float speed;

    
    
    private void Start(){
        playerRb = GetComponent<Rigidbody2D>();
        //playerAnimator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        HandleInput();
        //HandleAnimation();
        
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.magnitude);

        transform.position = transform.position + movement * speed * Time.deltaTime;
        
    }

    private void HandleInput(){
        //moveVector.x = Input.GetAxisRaw("Horizontal");
        //moveVector.y = Input.GetAxisRaw("Vertical");
        
        Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        if(dir.x > 0 && !facingRight || dir.x < 0 && facingRight){
            Flip();
        }
    }
    
    private void Flip(){
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    
    /*private void HandleAnimation(){
        playerAnimator.SetFloat("Speed", Mathf.Abs(moveVector.x) + Mathf.Abs(moveVector.y));
    }

    private void FixedUpdate(){
        Vector2 _velocity = moveVector.normalized * moveSpeed;
        playerRb.velocity = _velocity;
    }*/
}
