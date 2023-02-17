using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _astreoid;
    private Camera _camera;
    private Vector2 _xPosCamera;

    private Vector2 _xPosMin, _xPosMax;


    private void Awake()
    {
        _camera = Camera.main;

    }
    private void Start()
    {
        _xPosMin = _camera.ViewportToWorldPoint(new Vector2(0, 0));
        _xPosMax = _camera.ViewportToWorldPoint(new Vector2(1, 0));

    }

    IEnumerator SpawnerAsteroid()
    {
        new WaitForSeconds(2f);
        while (true)
        {
            Transform astreoid = Instantiate(_astreoid, new Vector3(Random.Range(_xPosMin.x, _xPosMax.x), 5f, 0f), Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }

    }


}
