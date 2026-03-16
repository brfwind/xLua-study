using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//引用命名空间
using XLua;

public class Lesson1_LuaEnv : MonoBehaviour
{
    void Start()
    {
        //Lua解析器 可以让我们在Unity中执行Lua
        //一般情况下 保持其唯一性
        LuaEnv env = new LuaEnv();

        //执行Lua语言
        env.DoString("print('你好世界')");
        //一般都用Lua里的 require 多脚本执行 来执行一个Lua脚本
        //Lua脚本默认路径是在Resources文件夹下
        //另外.lua后缀的文件，Resources是识别不了的，要改成.lua.txt后缀
        env.DoString("require('Main')");

        //帮助我们清除Lua中没有被手动释放的对象 垃圾回收
        //帧更新中定时执行 或者 切场景时执行
        env.Tick();

        //销毁Lua解析器
        env.Dispose();
    }

    void Update()
    {
        
    }
}
