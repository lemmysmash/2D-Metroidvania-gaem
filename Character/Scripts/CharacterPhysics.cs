using Godot;
using System;

public partial class CharacterPhysics : CharacterBody2D
{
	public bool jump;
	float move;
	Vector2 alignedMove;
	bool helperBool;
	Vector2 deafultScale;
	[Export] Node2D playerBody;
	[Export] public RayCast2D groundDetection;
	[Export] public float goundedness;
	public float timeSinceLeftGround;
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

    public override void _Ready()
    {
        deafultScale = playerBody.Scale;
    }

    public override void _Process(double delta)
    {
        alignedMove = new Vector2(move, 0f);

		if(groundDetection.GetCollisionPoint().DistanceTo(Position + (Rotation * Vector2.Up)) > goundedness)
		{
			timeSinceLeftGround += (float)delta;
		}

		//testObject.Position = Position + (Rotation * Vector2.Up);
    }

	public void addVelocity(Vector2 direction)
	{
		Velocity = Velocity + direction;
	}

    public void playerMove(float speed, float friction)
	{
		addVelocity(alignedMove * speed);
		addVelocity(-Velocity * friction);

		if(Velocity.X > 0.05f)
		{
			playerBody.Scale = deafultScale;
		}
		if(Velocity.X < -0.05f)
		{
			playerBody.Scale = new Vector2(-deafultScale.X, deafultScale.Y);
		}
	}

	public void applyGravity(float gravity)
	{
		addVelocity(-Vector2.Up * gravity);
	}
}
