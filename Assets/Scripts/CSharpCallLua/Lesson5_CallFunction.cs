using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

//无参无返回值的委托
public delegate void CustomCall();
//有参有返回的委托 (这是自定义的委托，需要加特性，并且要让XLua生成代码，才能被识别)
// [CSharpCallLua]
// public delegate int CustomCall2(int a);

[CSharpCallLua]  //多返回值委托（返回值根据Lua那边的实际情况定制）
public delegate int CustomCall3(int a,out int b,out bool c,out string d,out int e);

[CSharpCallLua]  //变长参数委托（返回值根据Lua那边的实际情况定制，不确定就用Object数组）
public delegate void CustomCall5(string a,params int[] args);

public class Lesson5_CallFunction : MonoBehaviour
{
    void Start()
    {
        LuaMgr.Instance.Init();
        LuaMgr.Instance.DoLuaFile("Main");

        //无参无返回的获取（用委托去接取）
        CustomCall call = LuaMgr.Instance.Global.Get<CustomCall>("testFun");
        call();
        //ps：Unity提供的无参无返回委托UnityAction 或者C#提供的委托Action，都可以接

        //有参有返回的获取
        // CustomCall2 call2 = LuaMgr.Instance.Global.Get<CustomCall2>("testFun2");
        // print(call2(10));
        //ps：Func也可以接，并且不用自定义委托再加属性，没那么麻烦
        Func<int,int> sFun = LuaMgr.Instance.Global.Get<Func<int,int>>("testFun2");
        print(sFun(10));

        //多返回值（C#是不支持多返回的）
        //C#里使用 out 和 ref 来接收多返回值
        //区别在于用out接时，接的变量不用初始化，ref要初始化
        CustomCall3 call3 = LuaMgr.Instance.Global.Get<CustomCall3>("testFun3");
        int b;
        bool c;
        string d;
        int e;
        print("返回的第一个参数：" + call3(100,out b,out c,out d,out e));
        print(b + " " + c + " " + d + " " + e);

        //变长参数
        CustomCall5 call5 = LuaMgr.Instance.Global.Get<CustomCall5>("testFun4");
        call5("123",1,3,5,7,9,2,4,6,8);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
