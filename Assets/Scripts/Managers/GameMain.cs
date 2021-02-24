using System;
using System.Collections;
using System.Collections.Generic;
using Factory;
using SLGLib;
using UnityEngine;
using UnityEngine.UI;

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

        RunTest();
    }

    void RunTest()
    {
        JojoFactory jojoFamily = new JojoFactory();
        DioFactory dioFamily = new DioFactory();
        
        jojoFamily.SpawnPerson();
        dioFamily.SpawnPerson();
        Debug.Log("=====> JoJo and Dio is spawned!");
        
        var jojoStand = jojoFamily.SpawnStand();
        var dioStand = dioFamily.SpawnStand();
        Debug.Log("=====> JoJo and Dio is spawned!");
        
        dioStand.Attack();
        jojoStand.Attack();
        
        Debug.Log("=====> to be continued");
    }
}
