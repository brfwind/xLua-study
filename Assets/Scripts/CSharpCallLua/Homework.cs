using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using XLua.LuaDLL;

public class Homework : MonoBehaviour
{
    public Transform father; 

    void Start()
    {
        LuaMgr.Instance.Init();
        LuaMgr.Instance.DoLuaFile("Main");

        Func<Transform,string,Transform[]> sFun = LuaMgr.Instance.Global.Get<Func<Transform,string,Transform[]>>("findChildrenObject");

        Transform[] son1s = sFun(father,"Son1");

        foreach(Transform i in son1s)
        {
            print(i.name);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
