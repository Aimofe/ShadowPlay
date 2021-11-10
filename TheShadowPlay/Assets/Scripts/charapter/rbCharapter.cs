using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbCharapter : MonoBehaviour
{

    public float Speed = 5f;
    public float JumpHeight = 2f;
    public float GroundDistance = 0.2f;
    public float DashDistance = 5f;
    public LayerMask Ground;

    private Rigidbody _body;
    private Vector3 _inputs = Vector3.zero;
    public bool _isGrounded = false;
    private Transform _groundChecker;

    void Start()
    {
        _body = GetComponent<Rigidbody>();

    }

    void Update()
    {

     
        
            if (Input.GetButtonDown("Jump"))
        {
            _body.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.Impulse);
        }


        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxis("Horizontal");
        _inputs = Vector3.ClampMagnitude(_inputs, 1);
        if (_inputs != Vector3.zero)
        {
            //transform.position += _inputs * Time.deltaTime;
            transform.forward = _inputs;

        }



    }
    void FixedUpdate()
    {
        _body.MovePosition(_body.position + _inputs * Speed * Time.fixedDeltaTime);
    }
}
