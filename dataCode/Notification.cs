using Godot;
using System;

public class Notification : Label{
	public override void _Ready(){
		GetNode<Tween>("Tween").InterpolateProperty(this, "rect_position", this.RectPosition, new Vector2(this.RectPosition.x, this.RectPosition.y - 40), 1.2f, 0, 0);
		GetNode<Tween>("Tween").InterpolateProperty(this, "modulate:a", 1, 0.2f, 1.2f, 0, 0);
		GetNode<Tween>("Tween").Start();
	}
	
	private void _on_Tween_tween_all_completed(){
		CallDeferred("free");
	}
}
