using Godot;
using System;

public partial class StateMachine : Node
{
	[Export] Node[] states;
	public int stateID = 0;
	int currentStateID = 0;
	

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//make the current state get called (to switch states make the stateID a different number)
		var currentState = states[stateID];
		if(stateID != currentStateID)
		{
			currentStateID = stateID;
			currentState.Call("stateEnter");
		}
		currentState.Call("stateUpdate",(float)delta);
	}

    public override void _PhysicsProcess(double delta)
    {
		var currentState = states[stateID];
        currentState.Call("statePhysicsUpdate");
    }
}
