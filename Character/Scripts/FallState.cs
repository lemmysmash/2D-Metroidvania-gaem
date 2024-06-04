using Godot;
using System;

public partial class FallState : Node
{
	[Export] CharacterPhysics playerPhysics;
	[Export] StateMachine playerState;
	[Export] float gravity = 90f;	
	[Export] float airMoveSpeed = 25f;
	[Export] float drag = 0.025f;

	public void stateEnter()
	{

	}

	public void stateUpdate(float delta)
	{
		playerPhysics.timeSinceLeftGround += delta;
	}

	public void statePhysicsUpdate()
	{
		if(playerPhysics.groundDetection.IsColliding() && playerPhysics.groundDetection.GetCollisionPoint().DistanceTo(playerPhysics.Position + (playerPhysics.Rotation * Vector2.Up)) < playerPhysics.goundedness)
		{
			playerPhysics.timeSinceLeftGround = 0f;
			playerState.stateID = 0;
		}


		playerPhysics.applyGravity(gravity);
		playerPhysics.playerMove(airMoveSpeed, drag);
		playerPhysics.MoveAndSlide();
	}
}
