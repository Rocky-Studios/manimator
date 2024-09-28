using Godot;
using Manim;
using Manimator.MObject;
using System.IO;

namespace Manimator;

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

	private void OpenProject()
	{
		Project newProject = new(ProjectName, ProjectLocation, new()
		{
			Width = 1920,
			Height = 1080,
			Framerate = 60
		});
		Manimator.Init(newProject);
		Manimator.OpenProject(newProject);
	}
}
