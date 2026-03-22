using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

/// <summary>
/// Lua管理器
/// 提供 Lua解析器
/// 保证解析器的唯一性
/// </summary>
public class LuaMgr : BaseManager<LuaMgr> //继承单例
{
    //执行Lua语言的函数
    //释放垃圾
    //销毁
    //重定向
    private LuaEnv luaEnv;

    //得到Lua中的大G表
    public LuaTable Global
    {
        get
        {
            return luaEnv.Global;
        }
    }

    // 初始化解析器
    public void Init()
    {
        if (luaEnv != null)
            return;
        luaEnv = new LuaEnv();
        luaEnv.AddLoader(MyCustomLoader);
        luaEnv.AddLoader(MyCustomABLoader);
    }

    //从路径获取lua脚本
    private byte[] MyCustomLoader(ref string filePath)
    {
        string path = Application.dataPath + "/Lua/" + filePath + ".lua";
        //Debug.Log(path);

        if (File.Exists(path))
        {
            return File.ReadAllBytes(path);
        }
        else
        {
            Debug.Log("MyCustomLoader重定向失败，文件名为" + filePath);
        }

        return null;
    }

    //从AB包获取lua脚本
    private byte[] MyCustomABLoader(ref string filePath)
    {
        TextAsset lua = ABManager.Instance.LoadRes<TextAsset>("lua", filePath + ".lua");

        if (lua != null)
            return lua.bytes;
        else
            Debug.Log("MyCustomABLoader重定向失败，文件名为：" + filePath);

        return null;
    }

    //传Lua文件名 执行Lua脚本
    public void DoLuaFile(string fileName)
    {
        string str = string.Format("require('{0}')",fileName);
        DoString(str);
    }

    // 执行Lua语言
    public void DoString(string str)
    {
        if (luaEnv == null)
        {
            Debug.Log("解析器未初始化");
            return;
        }
        luaEnv.DoString(str);
    }

    // 释放Lua垃圾
    public void Tick()
    {
        if (luaEnv == null)
        {
            Debug.Log("解析器未初始化");
            return;
        }
        luaEnv.Tick();
    }

    // 销毁解析器
    public void Dispose()
    {
        if (luaEnv == null)
        {
            Debug.Log("解析器未初始化");
            return;
        }
        luaEnv.Dispose();
        luaEnv = null;
    }
}
