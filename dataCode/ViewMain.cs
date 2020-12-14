using Godot;
using System;

public class ViewMain : Node2D{
	[Export] public int speed;

	private Vector2 velocity = new Vector2();

	private void GetInput(){
		velocity = new Vector2();

		if (Input.IsActionPressed("ui_right") && ((Position.x + speed) < 1080+100))
			velocity.x += speed;

		if (Input.IsActionPressed("ui_left") && ((Position.x - speed) > 0))
			velocity.x -= speed;

		if (Input.IsActionPressed("ui_down") && ((Position.y + speed) < 0))
			velocity.y += speed;

		if (Input.IsActionPressed("ui_up") && ((Position.y - speed)> -1920))
			velocity.y -= speed;
	}
	public override void _PhysicsProcess(float delta){
		GetInput();
		Translate(velocity);
	}
}
