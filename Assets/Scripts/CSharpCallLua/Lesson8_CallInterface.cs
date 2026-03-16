using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

[CSharpCallLua]
public interface ICSharpCallInterface
{
    int testInt
    {
        get;
        set;
    }

    bool testBool
    {
        get;
        set;
    }

    Action testFun
    {
        get;
        set;
    }
}

public class Lesson8_CallInterface : MonoBehaviour
{
    void Start()
    {
        LuaMgr.Instance.Init();
        LuaMgr.Instance.DoLuaFile("Main");

        ICSharpCallInterface obj = LuaMgr.Instance.Global.Get<ICSharpCallInterface>("testClass");
        print(obj.testInt);
        print(obj.testBool);
        obj.testFun();
    }

    void Update()
    {
        
    }
}
