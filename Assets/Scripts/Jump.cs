using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody rb;
    
    public float jumpForce = 5.0f;
    public bool isGrounded = true;

    public AudioSource clip;

    public float rayDistance = 1.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        isGrounded = Physics.Raycast(rb.position + Vector3.up * 0.2f, transform.localScale.x * Vector3.down, rayDistance, LayerMask.GetMask("Ground"));

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            clip.Play();
        }
    }
}
