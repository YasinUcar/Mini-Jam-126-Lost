using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MektupManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GorevManager _gorevManager;

    private void OnEnable()
    {
        _player.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.gameObject.SetActive(false);

        }
    }
    private void OnDisable()
    {
        _gorevManager.StringLevelName = "Puzzle";
        _player.SetActive(true);
    }
}
