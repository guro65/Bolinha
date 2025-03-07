using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float velocidade = 6;
    private Rigidbody2D rb;
    private float moveH;
    private Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {

        }

        if(Input.GetKey(KeyCode.D))
        {

        }

        /*moveH = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(moveH * velocidade * Time.deltaTime,0));*/
    }
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(horizontal, vertical);


        Vector2 movePosition = (velocidade * Time.fixedDeltaTime * moveDirection.normalized) + rb.position;
        rb.MovePosition(movePosition); 
    }

}
        



