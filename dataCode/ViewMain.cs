using Godot;
using System;

public class ViewMain : Node2D{
	public bool FreeCamera = false;
	public Vector2 CurrentPosition = new Vector2(0, 0);

	[Export] public int speed;
	private Vector2 velocity = new Vector2();

	public Vector2 getTilePos(Vector2 CTilePos){
		CTilePos.x = ((CTilePos.x > 9) ? 9 : CTilePos.x);
		CTilePos.y = ((CTilePos.y > 9) ? 9 : CTilePos.y);
		CTilePos.x = ((CTilePos.x < 0) ? 0 : CTilePos.x);
		CTilePos.y = ((CTilePos.y < 0) ? 0 : CTilePos.y);
		return new Vector2( (short)(448 + (CTilePos.x * 256)), (short)(632 - (CTilePos.y * 256)));
	}

	public override void _PhysicsProcess(float delta){
		if(FreeCamera){
			GetNode<Sprite>("CurrestTileMark").Visible = false;
			Translate(velocity);
		}else{
			GetNode<Sprite>("CurrestTileMark").Visible = true;
			this.Position = getTilePos(CurrentPosition);
		}
	}

	public override void _UnhandledInput(InputEvent @event){
		if (@event is InputEventKey eventKey){
			if(!eventKey.IsPressed()){return;}
			if(FreeCamera){
				velocity = new Vector2();

				if (eventKey.IsActionPressed("ui_right") && ((Position.x + speed) < 1080+100)){
					velocity.x += speed;
				}
				if (eventKey.IsActionPressed("ui_left") && ((Position.x - speed) > 0)){
					velocity.x -= speed;
				}
				if (eventKey.IsActionPressed("ui_down") && ((Position.y + speed) < 0)){
					velocity.y += speed;
				}
				if (eventKey.IsActionPressed("ui_up") && ((Position.y - speed)> -1920)){
					velocity.y -= speed;
				}
			}else{
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
			}
		}
	}
}
