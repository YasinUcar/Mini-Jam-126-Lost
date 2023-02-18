using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private Transform _astreoid;
    [SerializeField] private GameObject _laser;
    private SpaceGameManager _spaceGameManagerr;
    public float _speedSpawn = 0.5f;
    private Camera _camera;
    private Vector2 _xPosCamera;
    private Vector2 _xPosMin, _xPosMax;
    private void Awake()
    {
        _camera = Camera.main;

        _spaceGameManagerr = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SpaceGameManager>();

    }
    private void Start()
    {
        _xPosMin = _camera.ViewportToWorldPoint(new Vector2(0, 0));
        _xPosMax = _camera.ViewportToWorldPoint(new Vector2(1, 0));
        StartCoroutine(SpawnerAsteroid());
    }
    private void Update()
    {
        int getTimeInt = (int)_spaceGameManagerr.GameTime;
        switch (getTimeInt)
        {
            case 30:
                _speedSpawn = 0.5f;
                break;
            case 25:
                _speedSpawn = 0.3f;
                break;
            case 15:
                _speedSpawn = 0.2f;
                break;
            case 10:
                _speedSpawn = 0.1f;
                break;

        }
       

    }
    IEnumerator SpawnerAsteroid()
    {
        new WaitForSeconds(1f);
        while (true)
        {
            Transform astreoid = Instantiate(_astreoid, new Vector3(Random.Range(_xPosMin.x, _xPosMax.x), 5f, 0f), Quaternion.identity);
            Destroy(astreoid.gameObject, 5f);
            yield return new WaitForSeconds(_speedSpawn);
        }

    }
   

}
