using Godot;
using System;

public partial class CharacterPhysics : RigidBody2D
{
	public bool jump;
	float move;
	Vector2 alignedMove;

	public override void _Input(InputEvent @event)
	{
		move = Input.GetAxis("MoveLeft", "MoveRight");

		jump = Input.IsActionPressed("Jump");
	}

    public override void _Process(double delta)
    {
        alignedMove = new Vector2(move, 0f);
    }

    public void movePlayer(float speed, float friction)
	{
		ApplyCentralForce(alignedMove * speed);
		ApplyCentralForce(-LinearVelocity * friction);
	}
}
