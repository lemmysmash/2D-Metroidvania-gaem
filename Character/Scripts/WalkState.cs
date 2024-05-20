using Godot;
using System;

public partial class WalkState : Node
{
	[Export] CharacterPhysics playerPhysics;
	[Export] StateMachine playerState;
	[Export] float speed = 100f;
	[Export] float friction = 0.1f;

	public void stateEnter()
	{

	}

	public void stateUpdate(float delta)
	{
		if (playerPhysics.jump)
		{
			playerState.stateID = 1;
		}
	}

	public void statePhysicsUpdate()
	{
		playerPhysics.playerMove(speed, friction);
		//playerPhysics.alignWithGround();
		playerPhysics.MoveAndSlide();
	}
}
