using Godot;
using System;

public partial class CharacterPhysics : CharacterBody2D
{
	bool hit;
	public bool jump;
	float move;
	Vector2 alignedMove;
	bool[] helperBool;
	Vector2 deafultScale;
	[Export] Node2D playerBody;
	[Export] public RayCast2D groundDetection;
	[Export] public float goundedness;
	public float timeSinceLeftGround;
	[Export] Node2D testObject;
	[Export] Area2D hitDetection;
	

    public override void _Ready()
    {
        deafultScale = playerBody.Scale;
    }

	public bool down(bool subject, int index = 0)
	{
		//if we use this function more, than we have before we make the available amount longer
		if(helperBool == null)
		{
			helperBool = new bool[index + 1];
		}


		if(subject && helperBool[index])
		{
			helperBool[index] = false;
			return true;
		}
		else if(subject && !helperBool[index])
		{
			helperBool[index] = false;
			return false;
		}
		else if(!subject && !helperBool[index])
		{
			helperBool[index] = true;
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

		hit = Input.IsActionPressed("Hit");
	}

    public override void _Process(double delta)
    {
		if(groundDetection.IsColliding())
		{
			alignedMove = new Vector2(move, 0f).Rotated(-groundDetection.GetCollisionNormal().AngleTo(Vector2.Up));
		}
		else
		{
			alignedMove = new Vector2(move, 0f);
		}

		//GD.Print(helperBool);
    }

	public override void _PhysicsProcess(double delta)
	{
		if(down(hit, 1))
		{
			detectHit();
		}
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

	public void alignWithGround()
	{
		if(groundDetection.IsColliding() && groundDetection.GetCollisionPoint().DistanceTo(Position + (Vector2.Up * 80f).Rotated(Rotation)) > 85f)
		{
			Velocity = Velocity.Project(Vector2.Right.Rotated(-groundDetection.GetCollisionNormal().AngleTo(Vector2.Up)));
		}
	}

	public void applyGravity(float gravity)
	{
		addVelocity(-Vector2.Up * gravity);
	}

	public void detectHit()
	{
		if(hitDetection.HasOverlappingBodies())
		{	
			GD.Print("we hit something");
		}
	}
}
