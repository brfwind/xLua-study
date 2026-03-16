using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua.LuaDLL;

public class Lesson4_CallVariable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaMgr.Instance.Init();
        LuaMgr.Instance.DoLuaFile("Main");

        //使用lua解析器luaenv中的 Global属性
        //读取lua里的全局变量的值（i是值拷贝，i改变，不影响lua里原来的值）
        int i = LuaMgr.Instance.Global.Get<int>("testNumber");
        Debug.Log("testNUmber:" + i);

        //改值
        LuaMgr.Instance.Global.Set("testNumber",55);
        i = LuaMgr.Instance.Global.Get<int>("testNumber");
        Debug.Log("testNUmber:" + i);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
