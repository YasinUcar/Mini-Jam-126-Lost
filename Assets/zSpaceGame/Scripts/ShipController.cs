using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rg;
    private Camera _mainCam;
    private Vector2 _minBounds, _maxBounds;
    private void Awake()
    {
        _rg = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        InitBounds();
    }
    void InitBounds()
    {
        _mainCam = Camera.main;
        _minBounds = _mainCam.ViewportToWorldPoint(new Vector2(0, 0));
        _maxBounds = _mainCam.ViewportToWorldPoint(new Vector2(1, 1));

    }

    void Update()
    {
        Movement();
    }
    void Movement()
    {
        float xInput = Input.GetAxis("Horizontal") * Time.deltaTime * _speed;
        float yInput = Input.GetAxis("Vertical") * Time.deltaTime * _speed;
        Vector2 newPos = new Vector2();

        newPos.x = Mathf.Clamp(transform.position.x + xInput, _minBounds.x + 0.2f, _maxBounds.x - 0.2f);
        newPos.y = Mathf.Clamp(transform.position.y + yInput, _minBounds.y + 0.2f, _maxBounds.y - 0.2f);

        transform.position = newPos;


    }
}
