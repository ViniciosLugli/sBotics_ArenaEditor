using Godot;
using System;

public class Menu : Control{
	private PackedScene Notification_scene = (PackedScene)ResourceLoader.Load("res://dataScenes/Notification.tscn");

	private ulong CooldownSet = (ulong)OS.GetSystemTimeMsecs();
	private ulong CooldownGet = (ulong)OS.GetSystemTimeMsecs();

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
			bool CheckImport = false;
			try{
				CheckImport = (bool)GetNode<Node2D>("/root/Main/Arena/Editor").Call("regenerateArena", OS.Clipboard);
			}catch{
				GD.Print("Problem to import from clipboard");
				CheckImport = false;
				return;
			}
			Label Notification_instance = (Label)Notification_scene.Instance();
			if(CheckImport){
				Notification_instance.Text = "Arena importada com sucesso";
				Notification_instance.Set("custom_colors/font_color", new Color(0, 0.8f, 0));
			}else{
				Notification_instance.Text = "Não foi possível importar a arena";
				Notification_instance.Set("custom_colors/font_color", new Color(0.8f, 0, 0));
			}
			CallDeferred("add_child", Notification_instance);
			CooldownSet = (ulong)OS.GetSystemTimeMsecs() + 500;
		}
	}


	private void _on_ExportArenaButton_pressed(){
		if((ulong)OS.GetSystemTimeMsecs() > CooldownGet){
			try{
				OS.Clipboard = (string)GetNode<Node2D>("/root/Main/Arena/Editor").Call("decodeArena");
			}catch{
				GD.Print("Problem in copy to clipboard");
				CooldownGet = (ulong)OS.GetSystemTimeMsecs() + 500;
				return;
			}
			Label Notification_instance = (Label)Notification_scene.Instance();
			Notification_instance.Text = "Código de arena copiado";
			Notification_instance.Set("custom_colors/font_color", new Color(0, 0.8f, 0));
			CallDeferred("add_child", Notification_instance);
			CooldownGet = (ulong)OS.GetSystemTimeMsecs() + 500;
		}
	}


	private void _on_ConfigArenaButton_pressed(){
	}


}
