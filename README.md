# thor
thor is a xlua ui extension. feel free to use :) 索尔是一个基于xlua的UI拓展，欢迎入坑  
预览  

![1](doc/1.png)  

生成样式如下
```lua
local bindings = function(t)
	 t.bindings = {}
	 t.bindings.Button_Button = t.map:Get('Button_Button'):GetComponent(typeof(CS.UnityEngine.UI.Button))
	 t.bindings.Image_Button = t.map:Get('Image_Button'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 t.bindings.Image_Background = t.map:Get('Image_Background'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 t.bindings.Image_Checkmark = t.map:Get('Image_Checkmark'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 t.bindings.Image_Dropdown = t.map:Get('Image_Dropdown'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 t.bindings.Image_Arrow = t.map:Get('Image_Arrow'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 t.bindings.Image_Template = t.map:Get('Image_Template'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 t.bindings.Image_Viewport = t.map:Get('Image_Viewport'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 t.bindings.Image_ItemBackground = t.map:Get('Image_ItemBackground'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 t.bindings.Image_ItemCheckmark = t.map:Get('Image_ItemCheckmark'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 t.bindings.Image_Scrollbar = t.map:Get('Image_Scrollbar'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 t.bindings.Image_Handle = t.map:Get('Image_Handle'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 t.bindings.Image_Dropdown1 = t.map:Get('Image_Dropdown1'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 t.bindings.Image_Arrow1 = t.map:Get('Image_Arrow1'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 t.bindings.Image_Template1 = t.map:Get('Image_Template1'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 t.bindings.Image_Viewport1 = t.map:Get('Image_Viewport1'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 t.bindings.Image_ItemBackground1 = t.map:Get('Image_ItemBackground1'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 t.bindings.Image_ItemCheckmark1 = t.map:Get('Image_ItemCheckmark1'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 t.bindings.Image_Scrollbar1 = t.map:Get('Image_Scrollbar1'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 t.bindings.Image_Handle1 = t.map:Get('Image_Handle1'):GetComponent(typeof(CS.UnityEngine.UI.Image))
	 t.bindings.Text_Text = t.map:Get('Text_Text'):GetComponent(typeof(CS.UnityEngine.UI.Text))
	 t.bindings.Text_Label = t.map:Get('Text_Label'):GetComponent(typeof(CS.UnityEngine.UI.Text))
	 t.bindings.Text_Label1 = t.map:Get('Text_Label1'):GetComponent(typeof(CS.UnityEngine.UI.Text))
	 t.bindings.Text_ItemLabel = t.map:Get('Text_ItemLabel'):GetComponent(typeof(CS.UnityEngine.UI.Text))
	 t.bindings.Toggle_Toggle = t.map:Get('Toggle_Toggle'):GetComponent(typeof(CS.UnityEngine.UI.Toggle))
	 t.bindings.Toggle_Item = t.map:Get('Toggle_Item'):GetComponent(typeof(CS.UnityEngine.UI.Toggle))
	 t.bindings.Toggle_Item1 = t.map:Get('Toggle_Item1'):GetComponent(typeof(CS.UnityEngine.UI.Toggle))
	 t.bindings.Scrollbar_Scrollbar = t.map:Get('Scrollbar_Scrollbar'):GetComponent(typeof(CS.UnityEngine.UI.Scrollbar))
	 t.bindings.Scrollbar_Scrollbar1 = t.map:Get('Scrollbar_Scrollbar1'):GetComponent(typeof(CS.UnityEngine.UI.Scrollbar))
	 t.bindings.Dropdown_Dropdown = t.map:Get('Dropdown_Dropdown'):GetComponent(typeof(CS.UnityEngine.UI.Dropdown))
end
return bindings
```

* 自动生成代码自动绑定
* TODO  有生之年