using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test
{
    public void Speak(string str)
    {
        Debug.Log("Test1:" + str);
    }
}

namespace MrYang
{
    public class Test2
    {
        public void Speak(string str)
        {
            Debug.Log("Test2:" + str);
        }
    }
}


public class LuaCallCSharp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
