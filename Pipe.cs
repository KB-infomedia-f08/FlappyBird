using Godot;
using System;

public partial class Pipe : StaticBody2D
{
	[Signal]
	public delegate void ScoreEventHandler();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}
    public override void _PhysicsProcess(double delta)
    {
		var mPosition = Position;
		mPosition.X += -200 * (float)delta;
		Position = mPosition;
    }

	public void OnScoreAreaBodyEntered(Node2D body)
	{
		if(body is Birb)
		{
			EmitSignal(SignalName.Score);
		}
	}
}
