using Godot;
using System;

public partial class Birb : CharacterBody2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _PhysicsProcess(double delta)
	{
		var mVelocity = Velocity;
		if (!IsOnFloor())
		{
			mVelocity += GetGravity() * (float)delta;
		}

		if (Input.IsActionJustPressed("Flap"))
		{
			mVelocity.Y = -300;
		}

		Velocity = mVelocity;
		MoveAndSlide();
	}
}
