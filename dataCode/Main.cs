using Godot;
using System;

public class Main : Node{

	public override void _Ready(){
		OS.WindowMaximized = true;
	}

	public override void _Process(float delta){
	}
}
