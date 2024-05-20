using Godot;
using System;

public partial class CharacterPhysics : CharacterBody2D
{
	public bool jump;
	float move;
	Vector2 alignedMove;
	bool helperBool;

	public bool down(bool subject)
	{
		if(subject && helperBool)
		{
			helperBool = false;
			return true;
		}
		else if(subject && !helperBool)
		{
			helperBool = false;
			return false;
		}
		else if(!subject && !helperBool)
		{
			helperBool = true;
			return false;
		}
		else
		{
			return false;
		}
	}

	public override void _Input(InputEvent @event)
	{
		move = Input.GetAxis("MoveLeft", "MoveRight");

		jump = Input.IsActionPressed("Jump");
	}

    public override void _Process(double delta)
    {
        alignedMove = new Vector2(move, 0f);
    }

	public void addVelocity(Vector2 direction)
	{
		Velocity = Velocity + direction;
	}

    public void playerMove(float speed, float friction)
	{
		addVelocity(alignedMove * speed);
		addVelocity(-Velocity * friction);
	}

	public void applyGravity(float gravity)
	{
		addVelocity(-Vector2.Up * gravity);
	}
}
