using Godot;
using Manim;
using System.Timers;
using Timer = System.Timers.Timer;
namespace ManimGUI;
public partial class Editor : Control
{
	public static Project CurrentProject;

	public static bool IsPlaying = false;
	public static int StartFrame = 1;
	public static int EndFrame = 120;
	public static int CurrentFrame = 1;

	Timer timer;

    private static CompressedTexture2D PauseTexture;
    private static CompressedTexture2D PlayTexture;
	private static Button PausePlayButton;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		timer = new Timer();
		//                       Frame rate
		timer.Interval = 1000 / (30);
        timer.Elapsed += OnTimerTick;

		CurrentFrame = StartFrame;

		timer.Start();

		PauseTexture = ResourceLoader.Load<CompressedTexture2D>("res://Assets/Images/Icons/Pause.svg");
		PlayTexture = ResourceLoader.Load<CompressedTexture2D>("res://Assets/Images/Icons/Play.svg");
		PausePlayButton = GetNode<Button>("Background/Screen/Row1/Preview/Buttons/Pause_play");
	}

    private void OnTimerTick(object sender, ElapsedEventArgs e)
    {
        if (!IsPlaying) return;
        if(CurrentFrame < EndFrame)
		{
			CurrentFrame++;
		}
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
		GD.Print(CurrentFrame);
	}

	private void PausePlayPressed()
	{
		IsPlaying = !IsPlaying;

		if (IsPlaying)
		{
			PausePlayButton.Icon = PauseTexture;
		} 
		else
        {
            PausePlayButton.Icon = PlayTexture;
        }
    }
}
