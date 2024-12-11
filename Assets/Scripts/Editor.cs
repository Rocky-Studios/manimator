using System.Linq;
using Godot;
using Manim;
using Manimator.MObject;
using System.Timers;
using Timer = System.Timers.Timer;
namespace Manimator;
public partial class Editor : Control
{
	public static Project CurrentProject;
	public static Scene CurrentScene;

	public static bool IsPlaying = false;
	public static int StartFrame = 0;
	public static int EndFrame = 1200;
	public static int CurrentFrame = 0;

	public static Node Scene3DRoot;
	public static Camera3D Camera => Scene3DRoot.GetNode<Camera3D>("Camera3D");

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
		timer.Elapsed += OnFrameTick;

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
			
			Camera.Position = new Vector3(0, 1f, 0);

			Scene Scene1 = new Scene("Scene 1", 0);

			#region Objects

			// Intro
			Scene1.MObjects.Add(new TextObject("Intro Text", "Proof of Pythagoras' Theorem", new Color(1, 1, 1), 72, Camera, position: new Vector3(-2.4f, 0.8f, 0)));
			Scene1.MObjects.Add(new TextObject("Intro Text Subtitle", "Presented by Manimator", new Color(1, 1, 1), 36, Camera, position: new Vector3(-2.4f, 0.4f, 0)));
			
			// Right angle triangle
			Point A = new("A", null, false, position: new Vector3(-1, 0, 0));
			Point B = new("B", null, false, position: new Vector3(1, 0, 0));
			Point C = new("C", null, false, position: new Vector3(-1, 1.5f, 0));
			
			Scene1.MObjects.Add(A);
			Scene1.MObjects.Add(B);
			Scene1.MObjects.Add(C);

			Polygon triangle = new("Triangle", Camera, points: [A, B, C], strokeColor: new Color(1, 1, 1),
				visible: false);
			
			// Side length text
			TextObject bottom = new("Side A", "4", new Color(1, 1, 1), 36, Camera,
				position: new Vector3(-0.2f, -0.3f, 0), visible: false);
			TextObject left = new("Side B", "3", new Color(1, 1, 1), 36, Camera,
				position: new Vector3(-1.5f, 0.75f, 0), visible: false);
			TextObject hypotenuse = new("Side C", "?", new Color(1, 1, 1), 36, Camera,
				position: new Vector3(0.5f, 0.75f, 0), visible: false);
			
			Scene1.MObjects.Add(bottom);
			Scene1.MObjects.Add(left);
			Scene1.MObjects.Add(hypotenuse);
			
			
			Scene1.MObjects.Add(triangle);
			

			#endregion
			
			#region Animations

			Scene1.Animations.Add(new FadeAnimation([ Scene1.MObjects[0], Scene1.MObjects[1] ], 1, 2, 1, 0));
			
			Scene1.Animations.Add(new FadeAnimation([ triangle ], 1, 3.5f, 0, 1));
			Scene1.Animations.Add(new FadeAnimation([ bottom, left, hypotenuse ], 0.5f, 4f, 0, 1));
			
			#endregion
			
			newProject.Scenes.Add(Scene1);
			CurrentProject = newProject;
		}

		CurrentScene = CurrentProject.Scenes[0];
		foreach (MObject.MObject obj in CurrentScene.MObjects)
		{
			if(obj is Point p)
			{
			}
			else if (obj is Segment s) {
			}
		}

		return;

		void OnFrameTick(object sender, ElapsedEventArgs e)
		{
			if (!IsPlaying) return;
			if(CurrentFrame < EndFrame)
			{
				CurrentFrame++;
			}
		}
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
		// If frame counter isn't being edited then set the frame to the current frame
		if(!GetNode<TextEdit>("Background/Screen/Row1/Preview/Frame").HasFocus()) GetNode<TextEdit>("Background/Screen/Row1/Preview/Frame").Text = CurrentFrame.ToString();

		foreach (MObject.MObject obj in CurrentScene.MObjects)
		{
			if(!obj.Visible.Value) continue;
			obj.OnUpdate(Camera);
			obj.Outline?.QueueRedraw();
			obj.QueueRedraw();
		}

		foreach (var anim in CurrentScene.Animations)
		{
			if(anim.IsPlaying()) anim.OnUpdate();
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
		if (CurrentFrame <= StartFrame) return;
		CurrentFrame--;
	}

	private void Forward1Frame()
	{
		if (CurrentFrame >= EndFrame) return;
		CurrentFrame++;
	}

	private void ToEnd()
	{
		CurrentFrame = EndFrame;
	}
}
