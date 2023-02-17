using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _mouseSens;
    private Transform _player;
    private float _xRotation;
    void Start()
    {
        _player = transform.parent;
    }


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * _mouseSens;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * _mouseSens;

        _player.Rotate(Vector3.up * mouseX);

        _xRotation  -= mouseY;

        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
    }
}
