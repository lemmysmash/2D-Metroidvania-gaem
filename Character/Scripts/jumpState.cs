using Godot;
using System;

public partial class jumpState : Node
{
	[Export] CharacterPhysics playerPhysics;
	[Export] StateMachine playerState;
	[Export] float initialJumpForce = 600f;
	[Export] float holdJumpForce = 200f;
	[Export] float maxJumpTime = 0.5f;
	[Export] float gravity = 90f;	
	[Export] float airMoveSpeed = 25f;
	[Export] float drag = 0.025f;
	float jumpTimeElapsed = 0f;

	public void stateEnter()
	{
		playerPhysics.addVelocity(Vector2.Up * initialJumpForce);
	}

	public void stateUpdate(float delta)
	{
		jumpTimeElapsed += delta;
	}

	public void statePhysicsUpdate()
	{
		if(playerPhysics.jump && jumpTimeElapsed < maxJumpTime)
		{
			playerPhysics.addVelocity(Vector2.Up * holdJumpForce);
		}

		playerPhysics.applyGravity(gravity);
		playerPhysics.playerMove(airMoveSpeed, drag);
		playerPhysics.MoveAndSlide();
	}
}
