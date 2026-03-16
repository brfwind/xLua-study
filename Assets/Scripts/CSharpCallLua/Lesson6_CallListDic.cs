using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson6_CallListDic : MonoBehaviour
{
    void Start()
    {
        LuaMgr.Instance.Init();
        LuaMgr.Instance.DoLuaFile("Main");

        //同一类型List (是浅拷贝，不会影响lua里的数值)
        List<int> list = LuaMgr.Instance.Global.Get<List<int>>("testList");
        print("********List*********");
        for (int i = 0; i < list.Count; i++)
        {
            print(list[i]);
        }
        //不指定类型，其实就是泛型用Object代替

        //同一类型Dic （也是浅拷贝，不会影响lua里的数值)
        print("********Dic*********");
        Dictionary<string,int> dic = LuaMgr.Instance.Global.Get<Dictionary<string,int>>("testDic");
        foreach(string item in dic.Keys)
        {
            print(item + " " + dic[item]);
        }
        //不指定类型，也是泛型用Object代替
    }


    void Update()
    {

    }
}
