using Godot;
using System;

public class Main : Node{

	private PackedScene ArenaCoder_scene = (PackedScene)ResourceLoader.Load("res://dataScenes/ArenaCoder.tscn");

	public override void _Ready(){
		CallDeferred("add_child", ArenaCoder_scene.Instance());
	}

	public override void _Process(float delta){
	}
}
