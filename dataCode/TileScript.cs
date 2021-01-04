using Godot;
using System;

public class TileScript : Sprite{
	string Info = "";
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
}
