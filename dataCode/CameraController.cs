using Godot;
using System;

public class CameraController : Tween{
	public void MoveTo(Vector2 GoToPosition){
		InterpolateProperty(GetParent(), "Position", GetParent<Node2D>().Position, GoToPosition, 1, 0, 0);
		Start();
	}
}
