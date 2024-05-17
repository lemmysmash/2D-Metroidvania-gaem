using Godot;
using System;

public partial class CharacterPhysics : CharacterBody2D
{
	float move;
	public bool jump;
	bool helperBool;
	Vector2 previousVelocity;
	Vector2 velocity;
	Vector2 alignedMove;
	[Export] Node2D testObject;

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

	public void movePlayer(float speed, float friction)
	{
		addVelocity(alignedMove * speed + -Velocity * friction);
		//addVelocity(-Velocity * friction * delta);

		MoveAndSlide();
		previousVelocity = Velocity;
	}

	public void alignWithGround()
	{
		
	}
}
