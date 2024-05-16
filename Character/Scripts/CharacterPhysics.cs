using Godot;
using System;

public partial class CharacterPhysics : CharacterBody2D
{
	float move;
	bool jump;
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
		//first we assign inputs to values
		move = Input.GetAxis("MoveLeft", "MoveRight");

		jump = Input.IsActionPressed("Jump");
	}

    public override void _Process(double delta)
    {
		alignedMove = new Vector2(move, 0f);
        //keepSpeed();
    }

    public override void _PhysicsProcess(double delta)
    {
    }

    public void keepSpeed()
	{
		//we make the previous velocity the current velocity (minus a small amount, so that it is more accurate)
		previousVelocity = velocity - (Velocity - velocity);
	}

	public void addVelocity(Vector2 direction)
	{
		//a basic function, that simulates the adding of force
		Velocity = Velocity + direction;
	}

	public void movePlayer(float delta, float speed, float friction)
	{
		addVelocity(alignedMove * speed * delta);
		addVelocity(-Velocity * friction * delta);

		//Velocity = velocity;
		MoveAndSlide();
		previousVelocity = Velocity;

		testObject.Position = Position + Velocity;

		GD.Print("ballz");
	}
}
