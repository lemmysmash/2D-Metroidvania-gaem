using Godot;
using System;

public partial class Cam3DTest : Camera3D
{
	float yrot;

    public override void _PhysicsProcess(double delta)
    {
		yrot += 0.01f;

        Rotation = new Vector3(0f, yrot, 0f);
    }
    //test
}
