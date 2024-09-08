using Godot;
using Manim;
using ManimGUI.MObject;
using System.Timers;
using Timer = System.Timers.Timer;
namespace ManimGUI;
public partial class Editor : Control
{
	public static Project CurrentProject;
	public static Scene CurrentScene;

	public static bool IsPlaying = false;
	public static int StartFrame = 1;
	public static int EndFrame = 120;
	public static int CurrentFrame = 1;

	public static Node Scene3DRoot;

	Mesh PointMesh = ResourceLoader.Load<CylinderMesh>("res://Assets/MObjects/Point.res");
	Mesh CubeMesh = ResourceLoader.Load<BoxMesh>("res://Assets/MObjects/Cube.res");

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

		Scene3DRoot = GetNode<Node>("Scene/SubViewport");

		if(CurrentProject == null)
		{
			Project newProject = new("Test proj", "abcd", new Manim.ProjectSettings()
			{
				Width = 1920,
				Height = 1080,
				Framerate = 30
			});

			Scene Scene1 = new Scene("Scene 1", 0);
			Scene1.MObjects.Add(new Point("Middle point", System.Drawing.Color.Aqua));
			Scene1.Animations.Add(new FadeAnimation(Scene1.MObjects.ToArray()));
			newProject.Scenes.Add(Scene1);
			CurrentProject = newProject;
		}

		CurrentScene = CurrentProject.Scenes[0];
		foreach (MObject.MObject obj in CurrentScene.MObjects)
		{
			if(obj is Point)
			{
				MeshInstance3D p = new MeshInstance3D()
				{
					Mesh = PointMesh
				};
				p.RotateX(Mathf.Pi/2);

				p.Position = obj.Position;
				p.Scale    = obj.Scale;

				ShaderMaterial shaderMat = new()
				{
					Shader = ResourceLoader.Load<Shader>("res://Assets/MObject.gdshader")
				};

				p.MaterialOverride = shaderMat;

				Scene3DRoot.AddChild(p);
				p.Owner = GetTree().Root;
			}
		}

		void OnTimerTick(object sender, ElapsedEventArgs e)
		{
			if (!IsPlaying) return;
			if(CurrentFrame < EndFrame)
			{
				CurrentFrame++;
			}
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// If frame counter isn't being edited then set the frame to the current frame
		if(!GetNode<TextEdit>("Background/Screen/Row1/Preview/Frame").HasFocus()) GetNode<TextEdit>("Background/Screen/Row1/Preview/Frame").Text = CurrentFrame.ToString();

		foreach (MObject.MObject obj in CurrentScene.MObjects)
		{
			obj.OnUpdate();
			obj.Opacity = 0.5f;
		}
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

	private void OnFrameChanged()
	{
		IsPlaying = false;
		int newFrame = int.Parse(GetNode<TextEdit>("Background/Screen/Row1/Preview/Frame").Text);
		CurrentFrame = newFrame;
	}

	private void ToStart()
	{
		CurrentFrame = StartFrame;
	}

	private void Back1Frame()
	{
		CurrentFrame--;
	}

	private void Forward1Frame()
	{
		CurrentFrame++;
	}

	private void ToEnd()
	{
		CurrentFrame = EndFrame;
	}
}
