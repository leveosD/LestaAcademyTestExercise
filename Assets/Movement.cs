using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float defSpeed;
    [SerializeField] float jumpForce;
    float speed;
    [SerializeField] bool IsGrounded; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = defSpeed;
        IsGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        this.transform.position += moveVec * speed * Time.deltaTime;
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            speed = 7f;
            //rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            IsGrounded = true;
            speed = defSpeed;
        }
    }

    void OnCollisionExit(Collision collsiion)
    {
        if(collsiion.collider.tag == "Ground")
        {
            IsGrounded = false;
        }
    }
}
