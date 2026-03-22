
print("*********Lua调用C#类相关知识点*********")

--固定套路
--CS.命名空间.类名
--Unity的类。比如GameObject、Transform  都在CS.UnityEngine.类名

--通过C#中的类 实例化一个对象
--lua中没有new 所以直接类名括号就是实例化对象
--默认调用的 相当于是无参构造
local obj1 = CS.UnityEngine.GameObject();
local obj2 = CS.UnityEngine.GameObject("Brf");

--为了方便使用 以及节约性能
--可以定义全局变量存储C#中的类
GameObject = CS.UnityEngine.GameObject
local obj3 = GameObject("brf_wind")

--类中的静态对象 可以直接使用.来调用
local obj4 = GameObject.Find("Brf")

--得到对象中的成员变量 直接对象.即可
print(obj4.transform.position)


Vector3 = CS.UnityEngine.Vector3
--如果使用对象中的成员方法！！！ 一定要加：
obj4.transform:Translate(Vector3.right)

--自定义类的使用 类似于CS.路径
local t = CS.Test()
t:Speak("说话")

local t2 = CS.MrYang.Test2()
t2:Speak("说话")

--继承了Mono的类（不能直接new）
--用AddComponent添加脚本
local obj5 = GameObject("加脚本测试")
--xlua提供了一个重要方法 typeof 可以得到类的Type
--（AddComponent里传Type是一个重载，Unity里一般传泛型）
obj5:AddComponent(typeof(CS.UnityEngine.Rigidbody))