using Godot;
using Manim;
using ManimGUI.MObject;
using System.IO;

namespace ManimGUI;
public partial class NewProject : Panel
{
	public string ProjectName;
	public string ProjectLocation;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnBackButtonClicked()
	{
		Visible = false;
		GetNode<Panel>("../Startup").Visible = true;
	}

	public void OnProjectNameChanged()
	{
		ProjectName = GetNode<TextEdit>("FieldsContainer/Name/TextEdit").Text;
	}

	private void OnChooseProjectLocationPressed()
	{
		GetNode<FileDialog>("FieldsContainer/Location/ChooseLocationDialog").PopupCentered();
	}

	private void OnLocationSelected(string dir)
	{
		string[] dirComponents = dir.Split('/');
		ProjectLocation = Path.Combine(dir, ProjectName);
		GetNode<Button>("FieldsContainer/Location/Button").Text = "Choose (" + dirComponents[dirComponents.Length-1] + "/" + ProjectName + ")";
	}

	private void CreateNewProject()
	{
		Project newProject = new(ProjectName, ProjectLocation, new Manim.ProjectSettings()
		{
			Width = 1920,
			Height = 1080,
			Framerate = 30
		});
		ManimGUI.Init(newProject);

		Scene Scene1 = new Scene("Scene 1", 0);
		Scene1.MObjects.Add(new Point("Middle point", System.Drawing.Color.Aqua));
		Scene1.Animations.Add(new FadeAnimation(Scene1.MObjects.ToArray()));
		newProject.Scenes.Add(Scene1);

		ManimGUI.OpenProject(newProject);
	}
}
