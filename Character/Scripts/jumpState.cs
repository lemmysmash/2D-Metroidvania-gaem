using Godot;
using System;

public partial class jumpState : Node
{
	[Export] CharacterPhysics playerPhysics;
	[Export] StateMachine playerState;
	[Export] float initialJumpForce;
	[Export] float holdJumpForce;
	[Export] float maxJumpTimer;
	[Export] float gravity;	

	public void stateEnter()
	{
		playerPhysics.addVelocity(Vector2.Up * initialJumpForce);
	}

	public void stateUpdate(float delta)
	{

	}

	public void statePhysicsUpdate()
	{
		//playerPhysics.addVelocity(Vector2.Up * holdJumpForce);
		playerPhysics.applyGravity(gravity);
		playerPhysics.MoveAndSlide();
	}
}
