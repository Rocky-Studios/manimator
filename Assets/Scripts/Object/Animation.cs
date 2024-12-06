using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace Manimator.MObject
{
	/// <summary>
	/// The base interface for every visual animation
	/// </summary>
	public interface IAnimation
	{
		/// <summary>
		/// The length of the animation in seconds
		/// </summary>
		public float Length { get; set; }
		/// <summary>
		/// The time in seconds when the animation starts
		/// </summary>
		public float StartTime { get; set; }

		/// <summary>
		/// The animation timing function
		/// </summary>
		public AnimationCurve Curve { get; set; }
		/// <summary>
		/// The objects affected by this animation
		/// </summary>
		public MObject[] Objects { get; set; }

		public bool IsPlaying()
		{
			int startFrame = (int)StartTime * Editor.CurrentProject.Settings.Framerate;
			int endFrame = (int)(StartTime + Length) * Editor.CurrentProject.Settings.Framerate;

			if (Editor.CurrentFrame < startFrame || Editor.CurrentFrame > endFrame) return false;
			else return true;
		}
		public float GetPlayProgress() 
		{
			int startFrame = (int)StartTime * Editor.CurrentProject.Settings.Framerate;
			int endFrame = (int)(StartTime + Length) * Editor.CurrentProject.Settings.Framerate;
			return (Editor.CurrentFrame - (float)startFrame) / (endFrame - startFrame);
		}

		public abstract void OnUpdate();
	}

	/// <summary>
	/// An animation to fade in or out an object
	/// </summary>
	public class FadeAnimation : IAnimation
	{
		/// <summary>
		/// The length of the animation in seconds
		/// </summary>
		public float Length { get; set; }
		/// <summary>
		/// The time in seconds when the animation starts
		/// </summary>
		public float StartTime { get; set; }

		/// <summary>
		/// The animation timing function
		/// </summary>
		public AnimationCurve Curve { get; set; }
		/// <summary>
		/// The objects affected by this animation
		/// </summary>
		public MObject[] Objects { get; set; }

		public float StartOpacity;
		public float EndOpacity;

		public FadeAnimation(MObject[] objects, float length = 1, float startTime = 0, float startOpacity = 0f, float endOpacity = 1f, AnimationCurve? curve = null)
		{
			Length = length;
			if (Length < 0) throw new ArgumentException("Animation end must be after its start");
			StartTime = startTime;
			Curve = curve ?? new AnimationCurve();
			Objects = objects;
			if (Objects.Length == 0) throw new ArgumentException("Animation must affect at least one object");
			StartOpacity = startOpacity;
			EndOpacity = endOpacity;
		}
		
		public void OnUpdate()
		{
			float percentage = (this as IAnimation).GetPlayProgress();
			foreach (MObject obj in Objects)
			{
				float opacity = StartOpacity + (EndOpacity - StartOpacity) * percentage;
				obj.Opacity.Value = opacity;
				obj.StrokeColor.Value.A = opacity;
				obj.FillColor.Value.A = opacity;
				obj.Outline?.QueueRedraw();
				obj.QueueRedraw();
			}
		}
	}
	
	/// <summary>
	/// An animation to translate objects
	/// </summary>
	public class TranslateAnimation : IAnimation
	{
		/// <summary>
		/// The length of the animation in seconds
		/// </summary>
		public float Length { get; set; }
		/// <summary>
		/// The time in seconds when the animation starts
		/// </summary>
		public float StartTime { get; set; }

		/// <summary>
		/// The animation timing function
		/// </summary>
		public AnimationCurve Curve { get; set; }
		/// <summary>
		/// The objects affected by this animation
		/// </summary>
		public MObject[] Objects { get; set; }

		public Vector3[] ObjectsOriginalPos;
		public Vector3 StartPos;
		public Vector3 EndPos;

		public TranslateAnimation(MObject[] objects, Vector3[] objectsOriginalPos = null, float length = 1, float startTime = 0, Vector3? startPos = null, Vector3? endPos = null, AnimationCurve? curve = null)
		{
			Length = length;
			if (Length < 0) throw new ArgumentException("Animation end must be after its start");
			StartTime = startTime;
			Curve = curve ?? new AnimationCurve();
			Objects = objects;
			if (Objects.Length == 0) throw new ArgumentException("Animation must affect at least one object");
			StartPos = startPos ?? Vector3.Zero;
			EndPos = endPos ?? new Vector3(0,1,0);
			ObjectsOriginalPos = objectsOriginalPos ?? new Vector3[Objects.Length];
			
			// Resize the original positions array if it's too small
			if (ObjectsOriginalPos.Length >= Objects.Length) return;
			Array.Resize(ref ObjectsOriginalPos, Objects.Length);
			if (objectsOriginalPos == null) return;
			for (int i = objectsOriginalPos.Length; i < Objects.Length; i++) {
				ObjectsOriginalPos[i] = Objects[i].Position.Value;
			}
		}
		
		public void OnUpdate()
		{
			float percentage = (this as IAnimation).GetPlayProgress();
			foreach (MObject obj in Objects)
			{
				float translateX = StartPos.X + (EndPos.X - StartPos.X) * percentage;
				float translateY = StartPos.Y + (EndPos.Y - StartPos.Y) * percentage;
				float translateZ = StartPos.Z + (EndPos.Z - StartPos.Z) * percentage;
				obj.Position.Value = ObjectsOriginalPos[Objects.ToList().IndexOf(obj)] + new Vector3(translateX, translateY, translateZ);
				obj.Outline?.QueueRedraw();
				if(obj is TextObject t) t.QueueRedraw();
			}
		}
	}
}
