using Godot;
using System;

public class UnderLine : Area2D{
	private bool IsOverlaping = false;
	private float ModulateObjective = 1f;
	public override void _Process(float delta){
		if(IsOverlaping){
			ModulateObjective = 0.4f;
			GetParent().GetNode<Sprite>("TileBase").Visible = false;
			GetNode<Sprite>("UnderLineSprite").Visible = true;
			
			if((GetParent().GetNode<Sprite>("Filter").Modulate.a - ModulateObjective) < 0.01f){
				GetParent().GetNode<Sprite>("Filter").Modulate =
				new Color(1, 1, 1, ModulateObjective);
			}else{
				GetParent().GetNode<Sprite>("Filter").Modulate =
				new Color(1, 1, 1, (float)(GetParent().GetNode<Sprite>("Filter").Modulate.a-((GetParent().GetNode<Sprite>("Filter").Modulate.a - ModulateObjective)*3f*delta)));
			}
		}else{
			ModulateObjective = 1f;
			GetNode<Sprite>("UnderLineSprite").Visible = false;
			GetParent().GetNode<Sprite>("TileBase").Visible = true;
			if((ModulateObjective - GetParent().GetNode<Sprite>("Filter").Modulate.a) < 0.01f){
				GetParent().GetNode<Sprite>("Filter").Modulate =
				new Color(1, 1, 1, ModulateObjective);
			}else{
				GetParent().GetNode<Sprite>("Filter").Modulate =
					new Color(1, 1, 1, (float)(GetParent().GetNode<Sprite>("Filter").Modulate.a+((ModulateObjective - GetParent().GetNode<Sprite>("Filter").Modulate.a)*1.8f*delta)));
			}
		}
	}
	private void _on_Area_mouse_entered(){
		IsOverlaping = true;
	}

	private void _on_Area_mouse_exited(){
		IsOverlaping = false;
	}

}
