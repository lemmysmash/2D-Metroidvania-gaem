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
		if (playerPhysics.down(playerPhysics.jump))
		{
			playerState.stateID = 1;
		}

		playerPhysics.alignWithGround();
	}

	public void statePhysicsUpdate()
	{
		if((playerPhysics.Position + playerPhysics.groundDetection.Position).DistanceTo(playerPhysics.groundDetection.GetCollisionPoint()) > playerPhysics.goundedness)
		{
			//GD.Print((playerPhysics.Position + playerPhysics.groundDetection.Position).DistanceTo(playerPhysics.groundDetection.GetCollisionPoint()));
			playerState.stateID = 2;
		}

		playerPhysics.playerMove(speed, friction);
		playerPhysics.MoveAndSlide();
	}
}
