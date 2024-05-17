using Godot;
using System;

public partial class jumpState : Node
{
	public void stateEnter()
	{
		GD.Print("hello");
	}

	public void stateUpdate(float delta)
	{

	}

	public void statePhysicsUpdate()
	{
		GD.Print("csá");
	}
	
}
