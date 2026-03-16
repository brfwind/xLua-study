using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class Lesson9_CallLuaTable : MonoBehaviour
{
    void Start()
    {
        LuaMgr.Instance.Init();
        LuaMgr.Instance.DoLuaFile("Main");

        LuaTable table = LuaMgr.Instance.Global.Get<LuaTable>("testClass");
        print(table.Get<int>("testInt"));
        print(table.Get<bool>("testBool"));
        table.Get<LuaFunction>("testFun").Call();
    }


    void Update()
    {
        
    }
}
