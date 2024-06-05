using Godot;
using System;

public partial class jumpState : Node
{
	[Export] CharacterPhysics playerPhysics;
	[Export] StateMachine playerState;
	[Export] float initialJumpForce = 700f;
	[Export] float holdJumpForce = 280f;
	[Export] float maxJumpTime = 0.8f;
	[Export] float gravity = 90f;	
	[Export] float airMoveSpeed = 25f;
	[Export] float drag = 0.025f;

	public void stateEnter()
	{
		playerPhysics.addVelocity(Vector2.Up * initialJumpForce);
	}

	public void stateUpdate(float delta)
	{
		
	}

	public void statePhysicsUpdate()
	{
		playerPhysics.timeSinceLeftGround += 0.1f;

		if(playerPhysics.jump && playerPhysics.timeSinceLeftGround < maxJumpTime)
		{
			playerPhysics.addVelocity(Vector2.Up * holdJumpForce);
		}

		if(playerPhysics.groundDetection.IsColliding() && playerPhysics.groundDetection.GetCollisionPoint().DistanceTo(playerPhysics.Position + (playerPhysics.Rotation * Vector2.Up)) < playerPhysics.goundedness && playerPhysics.timeSinceLeftGround > 0.5f)
		{
			playerPhysics.timeSinceLeftGround = 0f;
			playerState.stateID = 0;
		}

		if(!playerPhysics.jump || playerPhysics.Velocity.Y > 0.5f)
		{
			playerState.stateID = 2;
		}


		playerPhysics.applyGravity(gravity);
		playerPhysics.playerMove(airMoveSpeed, drag);
		playerPhysics.MoveAndSlide();
	}
}
