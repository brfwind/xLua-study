using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua.LuaDLL;

public class Lesson3_LuaMgr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //初始化解析器
        LuaMgr.Instance.Init();

        LuaMgr.Instance.DoLuaFile("Main");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
