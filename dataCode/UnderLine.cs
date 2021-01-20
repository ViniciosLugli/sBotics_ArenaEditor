using Godot;
using System;

public class UnderLine : Area2D{

	bool MouseInside = false;

	private void _on_Area_mouse_entered(){
		MouseInside = true;
		if (GetNode<Tween>("Tween").IsActive()){
			return;
		}
		GetNode<Sprite>("UnderLineSprite").Visible = true;
		GetNode<Tween>("Tween").InterpolateProperty(GetParent().GetNode<Sprite>("Filter"), "modulate:a", GetParent().GetNode<Sprite>("Filter").Modulate.a, 0.4f, 0.2f, 0, 0);
		GetNode<Tween>("Tween").Start();
	}

	private void _on_Area_mouse_exited(){
		MouseInside = false;
		if (GetNode<Tween>("Tween").IsActive()){
			return;
		}
		GetNode<Sprite>("UnderLineSprite").Visible = false;
		GetNode<Tween>("Tween").InterpolateProperty(GetParent().GetNode<Sprite>("Filter"), "modulate:a", GetParent().GetNode<Sprite>("Filter").Modulate.a, 1f, 0.2f, 0, 0);
		GetNode<Tween>("Tween").Start();
	}

	private void _on_Tween_tween_all_completed(){
		if(!MouseInside && GetParent().GetNode<Sprite>("Filter").Modulate.a < 1f){
			GetNode<Sprite>("UnderLineSprite").Visible = false;
			GetNode<Tween>("Tween").InterpolateProperty(GetParent().GetNode<Sprite>("Filter"), "modulate:a", GetParent().GetNode<Sprite>("Filter").Modulate.a, 1f, 0.2f, 0, 0);
			GetNode<Tween>("Tween").Start();
		}
	}
}
