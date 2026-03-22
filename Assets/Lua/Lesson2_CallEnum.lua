
GameObject = CS.UnityEngine.GameObject

print("*********Lua调用C#枚举相关知识点*********")

--枚举调用
--调用Unity中的枚举
--调用规则和 类的调用 是一样的
--CS.命名空间.枚举名.枚举成员

PrimitiveType = CS.UnityEngine.PrimitiveType
local obj = GameObject.CreatePrimitive(PrimitiveType.Cube)

--枚举转换相关
--数值转枚举 字符串转枚举 （都用 枚举.__CastFrom()）
