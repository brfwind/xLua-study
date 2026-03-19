
function findChildrenObject(parent,targetName)
	local results = {}

	local function fun(obj)
		if obj.name == targetName then
			table.insert(results,obj)
		end

		local num = obj.childCount

		if num > 0 then
			for i = 0, obj.childCount - 1 do
    			local child = obj:GetChild(i)  --注意调取函数用冒号
    			fun(child) 
			end
		end
	end

	fun(parent)

	return results
end

print("Homework读取成功")