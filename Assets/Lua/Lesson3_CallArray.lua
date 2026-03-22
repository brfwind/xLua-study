
print("*********Lua调用C# 数组 相关知识点*********")

--C# 里数组怎么用 lua里就怎么用
--不能用#去获取长度 索引从0开始（一切照C#语法）

--local obj = CS.Lesson3()  假设该类里有一个数组array
--obj.array.Length   访问数组长度
--for i=0,obj.array.Lengrh-1 do   注意最大值 一定要减1
--	  print(obj.array[i])
--end

--Lua中创建一个C#数组
--由于lua没有new 这里需要用一个方法来创建
--C#里 数组实际上是个Array类 有个方法Array.CreateInstance(Type,int)
local array = CS.System.Array.CreateInstance(typeof(CS.System.Int32),10)
--以上表示创建int类型 长度为10的一维数组

print(array.Length)