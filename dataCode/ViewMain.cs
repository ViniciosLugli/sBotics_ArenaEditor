using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class ViewMain : Node2D{
	public Vector2 CurrentPosition = new Vector2(0, 0);

	string[] TopTiles = new string[]{"r8", "r9", "r10", "r11", "r12", "r13", "r14", "r15", "r16", "r17", "r39", "r41", "r43", "r45", "r49", "r52", "r55", "r58", "r61", "r64", "r67", "r69", "c12", "c13", "16", "c18", "c20", "r26", "r27", "r28", "r29", "r30", "r31", "r38", "r40", "r42", "r44", "r46", "r48", "r53", "r59", "r62", "r65", "r70"};
	string[] ConjTiles = new string[]{"r54", "r55", "r66", "r67", "r19", "r20", "r21", "c19", "c20", "c21"};

	public override void _Ready(){
		GetNode<Sprite>("CurrestTileMark").Visible = true;
		this.Position = (Vector2)GetNode<Node2D>("/root/Main/Arena/Editor").Call("getTilePos", (Vector2)CurrentPosition);
		updateTileInfo();
	}

	public void updateTileInfo(){
		Vector2 ToGetTileInfo = CurrentPosition;
		Sprite child = (Sprite)GetNode<Node2D>("/root/Main/Arena/Editor").GetNodeOrNull<Sprite>($"{ToGetTileInfo.x}0{ToGetTileInfo.y}0");
		if(child != null){
			string TileType = ((string)child.Get("Info")).Substring(4, 1).ToLower();
			int TileId = (int)GetNode<Node2D>("/root/Main/Arena/Editor").Call("getIndex", (string)(((string)child.Get("Info")).Substring(5, 1)));
			string TileBaseComparer = $"{TileType}{TileId}";
			//Set name
			if(TileType == "c"){
				GetNode<Control>("Menu").GetNode<Label>("TileInfoLabel").Text =
					(string)GetNode<Node2D>("/root/Main/Arena/Editor").Call("getCurvedName", (int)TileId);
			}else if(TileType == "r"){
				GetNode<Control>("Menu").GetNode<Label>("TileInfoLabel").Text =
					(string)GetNode<Node2D>("/root/Main/Arena/Editor").Call("getStraightName", (int)TileId);
			}else{
				GetNode<Control>("Menu").GetNode<Label>("TileInfoLabel").Text = "-";
			}

			//Set color
			if((TopTiles.Contains(TileBaseComparer)) && (ConjTiles.Contains(TileBaseComparer))){//METADINHA
				GetNode<Control>("Menu").GetNode<Label>("TileInfoLabel").Set("custom_colors/font_color", new Color((0.450980f + 1f) / 2f, (0.388235f + 0.247059f) / 2f, (1f + 0.286275f) / 2f));
			
			}else if(TopTiles.Contains(TileBaseComparer)){//ELEVADO
				GetNode<Control>("Menu").GetNode<Label>("TileInfoLabel").Set("custom_colors/font_color", new Color(0.450980f, 0.388235f, 1f));
			
			}else if(ConjTiles.Contains(TileBaseComparer)){//CONJUNTO
				GetNode<Control>("Menu").GetNode<Label>("TileInfoLabel").Set("custom_colors/font_color", new Color(1f, 0.247059f, 0.286275f));
			
			}else if(TileBaseComparer == "r74"){//GANGORRA
				GetNode<Control>("Menu").GetNode<Label>("TileInfoLabel").Set("custom_colors/font_color", new Color(0.490196f, 1f, 0.509804f));
			
			}else{//NENHUM
				GetNode<Control>("Menu").GetNode<Label>("TileInfoLabel").Set("custom_colors/font_color", new Color(1f, 1f, 1f));
			}
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

	public override void _UnhandledInput(InputEvent @event){
		//try{
			if (@event is InputEventKey eventKey){
				if(!eventKey.IsPressed()){return;}
				bool mod = false;
				if (eventKey.IsActionPressed("ui_right") && (CurrentPosition.x < 9)){
					CurrentPosition.x += 1;
					mod = true;
				}
				if (eventKey.IsActionPressed("ui_left") && (CurrentPosition.x > 0)){
					CurrentPosition.x -= 1;
					mod = true;
				}
				if (eventKey.IsActionPressed("ui_down") && (CurrentPosition.y > 0)){
					CurrentPosition.y -= 1;
					mod = true;
				}
				if (eventKey.IsActionPressed("ui_up") && (CurrentPosition.y < 9)){
					CurrentPosition.y += 1;
					mod = true;
				}
				if(mod){
					GoToPos((Vector2)GetNode<Node2D>("/root/Main/Arena/Editor").Call("getTilePos", (Vector2)CurrentPosition));
				}
			}
		// }catch{
		// 	GD.Print("Exept in keyboard input... ignoring");
		// }
	}
}
