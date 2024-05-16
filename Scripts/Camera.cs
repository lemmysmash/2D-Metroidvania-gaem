using Godot;
using System;

public partial class Camera : Camera2D
{
	[Export] Node2D player;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position = Position.Lerp(player.Position, 10f * (float)delta);
	}
}
