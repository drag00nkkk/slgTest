using System;
using System.Collections;
using System.Collections.Generic;
using SLGLib;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    [SerializeField] public IManager[] ManagerList =
    {
        InputManager.Instance,
    };

    [SerializeField] private Controller _controller = null;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var manager in ManagerList)
        {
            manager.OnInitScene();
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var manager in ManagerList)
        {
            manager.Update();
        }
    }

    private void OnEnable()
    {
        StartGame();
    }

    void StartGame()
    {
        // CheckerManager.Instance.Init();
        _controller.OnGameStart();
    }
}