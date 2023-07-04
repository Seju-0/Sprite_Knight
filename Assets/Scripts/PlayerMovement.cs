using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerMovement : MonoBehaviour
{
    public int moveSpeed;

    public Rigidbody2D rigidBody;

    private Vector3 movementInput;

    public Animator anim;
    // Start is called before the first frame update

    public int coinsCount;

    public int healthPoints;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
     void Update()
    {
        // if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("Backward");
        //}
        // if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("BackwardPause");
        //}
        //if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("Forward");
        //}
        //if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("ForwardPause");
        //}
        //if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("Left");
        //}
        //if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("LeftPause");
        //}
        //if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("Right");
        //}
        //if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("RightPause");
        //}
        //if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        //        {
        //    anim.enabled = false;
        //}
        anim.SetFloat("Horizontal", movementInput.x);
        anim.SetFloat("Vertical", movementInput.y);
        anim.SetFloat("Speed", movementInput.sqrMagnitude);
    }
    private void FixedUpdate()
    {
        rigidBody.velocity = movementInput * moveSpeed;
    }
    private void LateUpdate()
    {

    }
    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Speed"))
        {
            Transform col = collision.transform;
            col.transform.position = new Vector2(999, 999);
        }
        if (collision.CompareTag("Coins"))
        {
            Destroy(collision.gameObject);
            coinsCount++;
        }
        if (collision.CompareTag("Health"))
        {
            Destroy(collision.gameObject);
        }
    }
}
