using Godot;
using System;

public class TileScript : Sprite{
	string Info = "";
	public override void _Ready(){
		GetNode<Node2D>("/root/Main/Arena/ViewMain").Call("updateTileInfo");
	}
	
}
