using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

public class Lesson2_Loader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaEnv env = new LuaEnv();

        //xLua提供的一个 路径重定向的方法
        //允许我们自定义 加载 Lua文件的规则
        //当我们执行Lua语言 require 时 相当于执行一个Lua脚本
        //它就会 执行 我们自定义传入的这个函数
        //ps：以下的传参是一个委托，可能含多个函数
        env.AddLoader(MyCustomLoader);

        //当执行require时 会先自动执行AddLoader里传入的委托里的函数
        //若返回值有效，则执行脚本 
        //若均无效，则在默认路径里寻找（Resources文件夹里）
        env.DoString("require('Main')");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //自动执行。通过函数内部逻辑，返回文件路径
    private byte[] MyCustomLoader(ref string filePath)
    {
        //传入的参数是require执行的lua脚本文件名
        //拼接一个Lua文件所在路径
        string path = Application.dataPath + "/Lua/" + filePath + ".lua";
        print(path);

        //有路径 就去加载文件
        //File知识点 C# 提供的文件读写类
        if(File.Exists(path))
        {
            return File.ReadAllBytes(path);
        }
        else
        {
            Debug.Log("MyCustomLoader重定向失败，文件名为" + filePath);
        }

        return null;
    }
}
