using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimento : MonoBehaviour
{
    [SerializeField] float delay;
    [SerializeField] float velocidade;

    float movx = 0;
    float movy = 0;
    

    float tempo;
    

    //float movx = 0;
    //float movy = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - tempo > delay)
        {
            tempo = Time.time;
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                movy = +velocidade;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                movx = -velocidade;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                movy = -velocidade;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                movx = +velocidade;
            }
            transform.Translate(movx / 10, movy / 10, 0);
            movx = 0;
            movy = 0;
        }
    }
}
