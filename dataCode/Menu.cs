using Godot;
using System;

public class Menu : Control{
	private void _on_TextureRect_gui_input(object @event){
		if (@event is InputEventMouseButton eventKey){
			if (eventKey.IsPressed() && ((ButtonList)eventKey.ButtonIndex == ButtonList.Left)){
				if(!GetNode<Control>("LeftSide").GetNode<AnimationPlayer>("AnimationPlayer").IsPlaying()){
					if(GetNode<Control>("LeftSide").RectPosition.x < 0){
						GetNode<Control>("LeftSide").GetNode<AnimationPlayer>("AnimationPlayer").Play("InLeftMenu");
					}else{
						GetNode<Control>("LeftSide").GetNode<AnimationPlayer>("AnimationPlayer").Play("OutLeftMenu");
					}
				}
			}
		}
	}
}
