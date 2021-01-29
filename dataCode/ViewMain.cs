using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class ViewMain : Node2D{
	public Vector2 CurrentPosition = new Vector2(0, 0);

	public override void _Ready(){
		GetNode<Sprite>("CurrestTileMark").Visible = true;
		this.Position = (Vector2)GetNode<Node2D>("/root/Main/Arena/Editor").Call("getTilePos", (Vector2)CurrentPosition);
		updateTileInfo();
	}

	public void updateTileInfo(){
		Sprite child = (Sprite)GetNode<Node2D>("/root/Main/Arena/Editor").GetNodeOrNull<Sprite>($"{CurrentPosition.x}0{CurrentPosition.y}0");
		if(child != null){
			GetNode<Control>("Menu").GetNode<Label>("TileInfoLabel").Set("custom_colors/font_color", (Color)child.Get("Color"));
			GetNode<Control>("Menu").GetNode<Label>("TileInfoLabel").Text = (string)child.Get("Name");
		}else{
			GetNode<Control>("Menu").GetNode<Label>("TileInfoLabel").Set("custom_colors/font_color", new Color(1f, 1f, 1f));
			GetNode<Control>("Menu").GetNode<Label>("TileInfoLabel").Text = "-";
		}
		
	}

	public void GoToPos(Vector2 FinalPos){
		if(this.Position==FinalPos){return;}
		GetNode<Tween>("Tween").InterpolateProperty(this, "position", this.Position, FinalPos, 0.15f, 0, 0);
		GetNode<Tween>("Tween").InterpolateProperty(GetNode<Sprite>("CurrestTileMark"), "modulate:a", 0, 1, 0.4f, 0, 0);
		GetNode<Tween>("Tween").Start();
		updateTileInfo();
	}

	public override void _PhysicsProcess(float delta){
		bool mod = false;
		if (Input.IsActionJustPressed("ui_right") && (CurrentPosition.x < 9)){
			CurrentPosition.x += 1;
			mod = true;
		}
		if (Input.IsActionJustPressed("ui_left") && (CurrentPosition.x > 0)){
			CurrentPosition.x -= 1;
			mod = true;
		}
		if (Input.IsActionJustPressed("ui_down") && (CurrentPosition.y > 0)){
			CurrentPosition.y -= 1;
			mod = true;
		}
		if (Input.IsActionJustPressed("ui_up") && (CurrentPosition.y < 9)){
			CurrentPosition.y += 1;
			mod = true;
		}

		if (Input.IsActionJustPressed("tile_left")){
			GetNode<Node2D>("/root/Main/Arena/Editor").Call("tileEvent", CurrentPosition, 0);
		}

		if (Input.IsActionJustPressed("tile_right")){
			GetNode<Node2D>("/root/Main/Arena/Editor").Call("tileEvent", CurrentPosition, 1);
		}

		if (Input.IsActionJustPressed("tile_type_change")){
			GetNode<Node2D>("/root/Main/Arena/Editor").Call("tileEvent", CurrentPosition, 2);
		}

		if (Input.IsActionJustPressed("tile_delete")){
			GetNode<Node2D>("/root/Main/Arena/Editor").Call("tileEvent", CurrentPosition, 3);
		}

		if (Input.IsActionJustPressed("tile_copy")){
			GetNode<Node2D>("/root/Main/Arena/Editor").Call("tileEvent", CurrentPosition, 4);
		}

		if (Input.IsActionJustPressed("tile_paste")){
			GetNode<Node2D>("/root/Main/Arena/Editor").Call("tileEvent", CurrentPosition, 5);
		}

		if (Input.IsActionJustPressed("tile_rotate")){
			GetNode<Node2D>("/root/Main/Arena/Editor").Call("tileEvent", CurrentPosition, 6);
		}

		if(mod){
			GoToPos((Vector2)GetNode<Node2D>("/root/Main/Arena/Editor").Call("getTilePos", (Vector2)CurrentPosition));
		}
	}
}
