using Godot;
using System;

public class TileScript : Sprite{
	string Info = "";
	string Name = "-";
	Color Color = new Color(1f, 1f, 1f);
	/*type:
		0 = Normal
		1 = Elevado
		2 = Conjunto
		3 = Elevado e Conjunto
		4 = Gangorra	
	*/

	bool UpdateInfo = false;

	public override void _Ready(){
		if(UpdateInfo){
			GetNode<Node2D>("/root/Main/Arena/ViewMain").Call("updateTileInfo");
		}
		if((Info.Substring(4, 1) == "r") && ((int)GetNode<Node2D>("/root/Main/Arena/Editor").Call("getIndex", (string)Info.Substring(5, 1)) == 73)){
			if((int)GetNode<Node2D>("/root/Main/Arena/Editor").Get("RescueTyp") != 0){
				Offset = (Vector2)GetNode<Node2D>("/root/Main/Arena/Editor").Get("OffsetRescue");
			}
			ZIndex = 1;
		}
	}
	private void _on_TileBase_visibility_changed(){
		if(this.Name.Contains("@")){
			this.CallDeferred("free");
		}
	}
}
