using Godot;
using System;

public class UnderLine : Area2D{
	private bool IsOverlaping = false;

	public override void _Process(float delta){
		if(IsOverlaping){
			GetParent().GetNode<Sprite>("TileBase").Visible = false;
			GetNode<Sprite>("UnderLineSprite").Visible = true;
		}else{
			GetNode<Sprite>("UnderLineSprite").Visible = false;
			GetParent().GetNode<Sprite>("TileBase").Visible = true;
		}
	}
	private void _on_Area_mouse_entered(){
		IsOverlaping = true;
	}

	private void _on_Area_mouse_exited(){
		IsOverlaping = false;
	}

}
