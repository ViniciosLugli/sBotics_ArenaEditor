using Godot;
using System;

public class ViewMain : Node2D{
	[Export] public int speed;

	public Vector2 velocity = new Vector2();

	public void GetInput(){
		velocity = new Vector2();

		if (Input.IsActionPressed("ui_right") && (Position.x < 1920))
			velocity.x += 1;
		
		if (Input.IsActionPressed("ui_left") && (Position.x > 0))
			velocity.x -= 1;

		if (Input.IsActionPressed("ui_down") && (Position.y < 0))
			velocity.y += 1;

		if (Input.IsActionPressed("ui_up") && (Position.y > -1080))
			velocity.y -= 1;

		velocity = velocity.Normalized() * speed;
	}
	public override void _PhysicsProcess(float delta){
		GetInput();
		Translate(velocity);
	}
}
