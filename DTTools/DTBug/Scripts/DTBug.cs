using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IConsole))]
public class DTBug : MonoBehaviour
{
    DTLogHandler dTLogHandler;

    public GameObject _console;
    private void Awake()
    {
        Debug.Log("Assembling DTBug");

        dTLogHandler = new DTLogHandler();
        var consolePrefab =  Instantiate(_console);
        dTLogHandler.console = consolePrefab.GetComponent<IConsole>();
        dTLogHandler.console.Init();

        Debug.Log("DTBug active");
    }

    private void OnDestroy()
    {
        dTLogHandler.OnDestroy();
    }
}
