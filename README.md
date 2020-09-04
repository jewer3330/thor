# thor
thor is a xlua ui extension. feel free to use :) 索尔是一个基于xlua的UI拓展，欢迎入坑  
预览  

![1](doc/1.png)  

生成样式如下
```lua
local bindings = function(table)
	 table.bindings = {}
	 table.bindings.Button_Button = table.map:Get('Button_Button'):GetComponent(typeof(CS.UnityEngine.UI.Button))
	 table.bindings.Image_Button = table.map:Get('Image_Button'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 table.bindings.Image_Background = table.map:Get('Image_Background'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 table.bindings.Image_Checkmark = table.map:Get('Image_Checkmark'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 table.bindings.Image_Dropdown = table.map:Get('Image_Dropdown'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 table.bindings.Image_Arrow = table.map:Get('Image_Arrow'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 table.bindings.Image_Template = table.map:Get('Image_Template'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 table.bindings.Image_Viewport = table.map:Get('Image_Viewport'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 table.bindings.Image_ItemBackground = table.map:Get('Image_ItemBackground'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 table.bindings.Image_ItemCheckmark = table.map:Get('Image_ItemCheckmark'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 table.bindings.Image_Scrollbar = table.map:Get('Image_Scrollbar'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 table.bindings.Image_Handle = table.map:Get('Image_Handle'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 table.bindings.Image_Dropdown1 = table.map:Get('Image_Dropdown1'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 table.bindings.Image_Arrow1 = table.map:Get('Image_Arrow1'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 table.bindings.Image_Template1 = table.map:Get('Image_Template1'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 table.bindings.Image_Viewport1 = table.map:Get('Image_Viewport1'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 table.bindings.Image_ItemBackground1 = table.map:Get('Image_ItemBackground1'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 table.bindings.Image_ItemCheckmark1 = table.map:Get('Image_ItemCheckmark1'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 table.bindings.Image_Scrollbar1 = table.map:Get('Image_Scrollbar1'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 table.bindings.Image_Handle1 = table.map:Get('Image_Handle1'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 table.bindings.Text_Text = table.map:Get('Text_Text'):GetComponent(typeof(CS.UnityEngine.UI.Text))
	 table.bindings.Text_Label = table.map:Get('Text_Label'):GetComponent(typeof(CS.UnityEngine.UI.Text))
	 table.bindings.Text_Label1 = table.map:Get('Text_Label1'):GetComponent(typeof(CS.UnityEngine.UI.Text))
	 table.bindings.Text_ItemLabel = table.map:Get('Text_ItemLabel'):GetComponent(typeof(CS.UnityEngine.UI.Text))
	 table.bindings.Toggle_Toggle = table.map:Get('Toggle_Toggle'):GetComponent(typeof(CS.UnityEngine.UI.Toggle))
	 table.bindings.Toggle_Item = table.map:Get('Toggle_Item'):GetComponent(typeof(CS.UnityEngine.UI.Toggle))
	 table.bindings.Toggle_Item1 = table.map:Get('Toggle_Item1'):GetComponent(typeof(CS.UnityEngine.UI.Toggle))
	 table.bindings.Scrollbar_Scrollbar = table.map:Get('Scrollbar_Scrollbar'):GetComponent(typeof(CS.UnityEngine.UI.Scrollbar))
	 table.bindings.Scrollbar_Scrollbar1 = table.map:Get('Scrollbar_Scrollbar1'):GetComponent(typeof(CS.UnityEngine.UI.Scrollbar))
	 table.bindings.Dropdown_Dropdown = table.map:Get('Dropdown_Dropdown'):GetComponent(typeof(CS.UnityEngine.UI.Dropdown))
end
return bindings
```

* 自动生成代码自动绑定
* TODO  有生之年