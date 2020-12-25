using Godot;
using System;

public class UnderLine : Area2D{
	private byte IsOverlaping = 3;
	private float ModulateObjective = 1f;
	public override void _Process(float delta){
		if(IsOverlaping == 1){
			ModulateObjective = 0.4f;
			GetNode<Sprite>("UnderLineSprite").Visible = true;
			
			if((GetParent().GetChild<Sprite>(0).Modulate.a - ModulateObjective) < 0.08f){
				GetParent().GetChild<Sprite>(0).Modulate =
				new Color(1, 1, 1, ModulateObjective);
				IsOverlaping = 3;
			}else{
				GetParent().GetChild<Sprite>(0).Modulate =
				new Color(1, 1, 1, (float)(GetParent().GetChild<Sprite>(0).Modulate.a-((GetParent().GetChild<Sprite>(0).Modulate.a - ModulateObjective)*3f*delta)));
			}
		}else if(IsOverlaping == 0){
			ModulateObjective = 1f;
			GetNode<Sprite>("UnderLineSprite").Visible = false;
			if((ModulateObjective - GetParent().GetChild<Sprite>(0).Modulate.a) < 0.08f){
				GetParent().GetChild<Sprite>(0).Modulate =
				new Color(1, 1, 1, ModulateObjective);
				IsOverlaping = 3;
			}else{
				GetParent().GetChild<Sprite>(0).Modulate =
					new Color(1, 1, 1, (float)(GetParent().GetChild<Sprite>(0).Modulate.a+((ModulateObjective - GetParent().GetChild<Sprite>(0).Modulate.a)*1.8f*delta)));
			}
		}
	}
	private void _on_Area_mouse_entered(){
		IsOverlaping = 1;
	}

	private void _on_Area_mouse_exited(){
		IsOverlaping = 0;
	}
}
