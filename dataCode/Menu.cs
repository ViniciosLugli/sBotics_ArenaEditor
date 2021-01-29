using Godot;
using System;

public class Menu : Control{
	private PackedScene Notification_scene = (PackedScene)ResourceLoader.Load("res://dataScenes/Notification.tscn");

	private ulong CooldownSet = (ulong)OS.GetSystemTimeMsecs();
	private ulong CooldownGet = (ulong)OS.GetSystemTimeMsecs();

	public override void _Ready(){

	}

	private void _on_ToggleMenuButton_pressed(){
		if(!GetNode<Control>("LeftSide").GetNode<AnimationPlayer>("AnimationPlayer").IsPlaying()){
			if(GetNode<Control>("LeftSide").RectPosition.x < 0){
				GetNode<Control>("LeftSide").GetNode<AnimationPlayer>("AnimationPlayer").Play("InLeftMenu");
			}else{
				GetNode<Control>("LeftSide").GetNode<AnimationPlayer>("AnimationPlayer").Play("OutLeftMenu");
			}
		}
	}


	private void _on_ImportArenaButton_pressed(){
		if((ulong)OS.GetSystemTimeMsecs() > CooldownSet){
			try{
				GetNode<Node2D>("/root/Main/Arena/Editor").Call("regenerateArena", OS.Clipboard);
			}catch{
				GD.Print("Problem to import from clipboard");
			}
			CooldownSet = (ulong)OS.GetSystemTimeMsecs() + 1000;
		}
	}


	private void _on_ExportArenaButton_pressed(){
		if((ulong)OS.GetSystemTimeMsecs() > CooldownGet){
			try{
				OS.Clipboard = (string)GetNode<Node2D>("/root/Main/Arena/Editor").Call("decodeArena");
			}catch{
				GD.Print("Problem in copy to clipboard");
			}
			CooldownGet = (ulong)OS.GetSystemTimeMsecs() + 500;
		}
	}


	private void _on_ConfigArenaButton_pressed(){
	}


}
