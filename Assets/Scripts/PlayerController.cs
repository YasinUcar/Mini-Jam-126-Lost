using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private float _horizontalInput, _verticalInput;

    Vector3 _moveDirection;
    Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.freezeRotation = true;
    }
    private void Update()
    {
        MyInput();
    }
    void MyInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

    }
    private void FixedUpdate()
    {
        Movement();
    }
    void Movement()
    {
        _moveDirection = transform.forward * _verticalInput + transform.right * _horizontalInput;
        rigidbody.AddForce(_moveDirection.normalized * _moveSpeed * 10f, ForceMode.Force);
    }
}
