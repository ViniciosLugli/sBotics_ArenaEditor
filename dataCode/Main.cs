using Godot;
using System;

public class Main : Node{

	public override void _Ready(){
		VisualServer.SetDefaultClearColor(new Color("#222222"));
		OS.WindowMaximized = true;
	}

	// public override void _Process(float delta){
	// }
}
