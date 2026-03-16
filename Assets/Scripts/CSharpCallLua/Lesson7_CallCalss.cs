using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Lesson7_CallCalss : MonoBehaviour
{
    public class CallLuaClass
    {
        //想用类去接table
        //这个类里申明的成员变量 名字一定要和Lua那边一样  
        public int testInt;
        public bool testBool;
        public Action testFun;
        //这个自定义中的变量，可以更多也可以更少，无非是省略或者忽略
    }


    void Start()
    {
        LuaMgr.Instance.Init();
        LuaMgr.Instance.DoLuaFile("Main");

        CallLuaClass obj = LuaMgr.Instance.Global.Get<CallLuaClass>("testClass");
        print(obj.testInt);
        print(obj.testBool);
        obj.testFun();
    }


    void Update()
    {
        
    }
}
