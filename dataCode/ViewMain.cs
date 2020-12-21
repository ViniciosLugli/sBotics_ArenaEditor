using Godot;
using System;

public class ViewMain : Node2D{
	public Vector2 CurrentPosition = new Vector2(0, 0);

	public Vector2 getTilePos(Vector2 CTilePos){
		CTilePos.x = ((CTilePos.x > 9) ? 9 : CTilePos.x);
		CTilePos.y = ((CTilePos.y > 9) ? 9 : CTilePos.y);
		CTilePos.x = ((CTilePos.x < 0) ? 0 : CTilePos.x);
		CTilePos.y = ((CTilePos.y < 0) ? 0 : CTilePos.y);
		return new Vector2( (short)(448 + (CTilePos.x * 256)), (short)(632 - (CTilePos.y * 256)));
	}

	public override void _Ready(){
		GetNode<Sprite>("CurrestTileMark").Visible = true;
		Position = getTilePos(CurrentPosition);
	}

	public void GoToPos(Vector2 FinalPos){
		if(this.Position==FinalPos){return;}
		GetNode<Tween>("Tween").InterpolateProperty(this, "position", this.Position, FinalPos, 0.15f, 0, 0);
		GetNode<Tween>("Tween").InterpolateProperty(GetNode<Sprite>("CurrestTileMark"), "modulate:a", 0, 1, 0.4f, 0, 0);
		GetNode<Tween>("Tween").Start();
	}

	public override void _UnhandledInput(InputEvent @event){
		if (@event is InputEventKey eventKey){
			if(!eventKey.IsPressed()){return;}
			if (eventKey.IsActionPressed("ui_right") && (CurrentPosition.x < 9)){
				CurrentPosition.x += 1;
			}
			if (eventKey.IsActionPressed("ui_left") && (CurrentPosition.x > 0)){
				CurrentPosition.x -= 1;
			}
			if (eventKey.IsActionPressed("ui_down") && (CurrentPosition.y > 0)){
				CurrentPosition.y -= 1;
			}
			if (eventKey.IsActionPressed("ui_up") && (CurrentPosition.y < 9)){
				CurrentPosition.y += 1;
			}
			GoToPos(getTilePos(CurrentPosition));
		}
	}
}
