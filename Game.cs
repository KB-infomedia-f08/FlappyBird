using Godot;
using System;

public partial class Game : Node2D
{
	Label scoreLabel;
	int score;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		score = 0;
		scoreLabel = GetNode<Label>("CanvasLayer/Score");
	}

	public void UpdateScore()
	{
		score++;
		scoreLabel.Text = score.ToString();
	}
}
