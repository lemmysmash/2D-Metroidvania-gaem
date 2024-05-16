using Godot;
using System;

public partial class WalkState : Node
{
	[Export] CharacterPhysics playerPhysics;
	[Export] float speed = 800f;
	[Export] float friction = 3f;

	public void stateEnter()
	{

	}

	public void stateUpdate(float delta)
	{
		playerPhysics.movePlayer(delta, speed, friction);
	}

	public void statePhysicsUpdate()
	{

	}
}
