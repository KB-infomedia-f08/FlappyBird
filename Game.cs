using Godot;
using System;

public partial class Game : Node2D
{
	Label scoreLabel;
	int score;
	Marker2D spawnPoint;
	[Export]
	PackedScene pipePackedScene {get; set;}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		score = 0;
		scoreLabel = GetNode<Label>("CanvasLayer/Score");
		spawnPoint = GetNode<Marker2D>("PipeSpawnPoint");

	}

	public void UpdateScore()
	{
		score++;
		scoreLabel.Text = score.ToString();
	}

	public void OnBirbDeath()
	{
		GD.Print("Birb died!");
		GetTree().CallDeferred("reload_current_scene");
	}

	public void OnSpawnTimerTimeout()
	{
		GD.Print("Spawn pipe");
		var pipe = pipePackedScene.Instantiate<Pipe>();
		//Set position
		Vector2 mPosition = spawnPoint.Position;
		Random rand = new Random();
		int offset = (rand.Next(20) - 10) * 20;
		mPosition.Y += offset;
		pipe.Position = mPosition;
		//bind score signal to method UpdateScore
		pipe.Score += UpdateScore;

		AddChild(pipe);
	}
}
