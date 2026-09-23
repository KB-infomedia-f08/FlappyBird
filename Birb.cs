using Godot;
using System;

public partial class Birb : CharacterBody2D
{
	[Signal]
	public delegate void DeathEventHandler();
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

	public void OnBodyEnterd(Node2D body)
	{
		if(body is Pipe)
		{
			EmitSignal(SignalName.Death);
		}
	}

	public void OnAreaEntered(Area2D area)
	{
		if(area.Name == "DeathArea")
		{
			EmitSignal(SignalName.Death);
		}
	}
}
