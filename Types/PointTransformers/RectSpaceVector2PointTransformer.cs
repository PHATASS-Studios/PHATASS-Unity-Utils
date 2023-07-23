using UnityEngine;

#if UNITY_EDITOR
	using static PHATASS.Utils.Extensions.RectEditorExtensions;
#endif 
	
namespace PHATASS.Utils.Types.PointTransformers
{
//PointTransformer that transforms between one rect's space and another
	[System.Serializable]
	public class RectSpaceVector2PointTransformer :
		IVector2PointTransformer
	{
	//serialized fields
		[Tooltip("Rect representing primary (\"world\") space. Calling TransformPoint takes a point in primary space and returns a corresponding point in the secondary space.")]
		[SerializeField]
		protected Rect primarySpaceRect;

		[Tooltip("Rect representing secondary (\"reference\") space. Calling TransformPoint takes a point in primary space and returns a corresponding point in the secondary space.")]
		[SerializeField]
		protected Rect secondarySpaceRect;
		
		/*
		[Tooltip("If true space transformations will clamp to space limits.")]
		[SerializeField]
		private bool clampToSpaceOnTransform = true;
		*/
	//ENDOF serialized fields

	//IVector2PointTransformer
		// Transforms a point from primary space ("world") into secondary ("reference") space
		Vector2 PHATASS.Utils.Types.PointTransformers.IPointTransformer<Vector2>.TransformPoint (Vector2 point)
		{ return this.TransformPoint(point); }

		// Transforms a point from secondary space into primary space ("world")
		Vector2 PHATASS.Utils.Types.PointTransformers.IPointTransformer<Vector2>.InverseTransformPoint (Vector2 point)
		{ return this.InverseTransformPoint(point); }
	//ENDOF IVector2PointTransformer

	//Constructor
		public RectSpaceVector2PointTransformer (Rect primaryRect, Rect secondaryRect)
		{
			primarySpaceRect = primaryRect;
			secondarySpaceRect = secondaryRect;
		}

		//construct from copy overload.
		//takes a sample object and creates a shallow copy. Optionally takes any of the base parameters, which will override the sample's values when given.
		public RectSpaceVector2PointTransformer (
			RectSpaceVector2PointTransformer sample,
			Rect? primaryRect,
			Rect? secondaryRect
		) {

			if (primaryRect == null)
			{ primarySpaceRect = sample.primarySpaceRect; }
			else
			{ primarySpaceRect = (Rect) primaryRect; }

			if (secondaryRect == null)
			{ secondarySpaceRect = sample.secondarySpaceRect; }
			else
			{ secondarySpaceRect = (Rect) secondaryRect; }
		}
	//ENDOF Constructor

	//private methods
		// Transforms a point from primary space ("world") into secondary ("reference") space
		protected Vector2 TransformPoint (Vector2 point)
		{
			Vector2 normalizedPoint = Rect.PointToNormalized(rectangle: this.primarySpaceRect, point: point);
			return Rect.NormalizedToPoint(rectangle: this.secondarySpaceRect, normalizedRectCoordinates: normalizedPoint);
		}

		// Transforms a point from secondary space into primary space ("world")
		protected Vector2 InverseTransformPoint (Vector2 point)
		{
			Vector2 normalizedPoint = Rect.PointToNormalized(rectangle: this.secondarySpaceRect, point: point);
			return Rect.NormalizedToPoint(rectangle: this.primarySpaceRect, normalizedRectCoordinates: normalizedPoint);
		}
	//ENDOF private methods

	//Editor gizmos
	#if UNITY_EDITOR
		public void DrawPrimarySpaceRectGizmo (Color? color = null)
		{
			this.primarySpaceRect.EDrawGizmo(color);
		}

		public void DrawSecondarySpaceRectGizmo (Color? color = null)
		{
			this.primarySpaceRect.EDrawGizmo(color);
		}
	#endif
	//ENDOF Editor gizmos
	}
}