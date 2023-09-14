using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MyCodeStyle : MonoBehaviour
{
    // Constants: Uppercase SnakeCase
    public const int CONSTANT_FEILD = 10;

    // Propertiers: PascalCase
    public static MyCodeStyle Instance { get; private set; }

    // Events: PascalCase
    public event EventHandler OnSomthingHappened;

    // Fields: camelCase
    private float memberVariable;

    // Function Names: PascalCase
    private void Awake()
    {

        Instance = this;

        DoSomthing(10f);
    }

    // Function Params: camelCase
    private void DoSomthing(float time)
    {
        // some code ...
        memberVariable = time + Time.deltaTime;
        if (memberVariable > 0)
        {
            // do somthing
        }
    }
}
