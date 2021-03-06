using System;
using System.Collections.Generic;

using Mathf = UnityEngine.Mathf;

namespace PHATASS.Utils.Extensions
{
	//simple mathematics on floats
	public static class FloatExtensions
	{
		//steps a float towards another by given step value
		public static float EStepTowards (this float value, float target, float step = 1)
		{
			//limit step to avoid overshooting
			if (value.EDifference(target) < step)
			{ step = value.EDifference(target); }

			return	(value > target)	
						? value - step	//if greater than target, decrement
				  :	(value < target)
						? value + step //if smaller than target, increment
						: target;	//if on target return target
		}

		//returns the absolute difference between two floats
		public static float EDifference (this float a, float b)
		{
			return System.Math.Abs(a - b);
		}

		//returns the sign of this number (1 for positive, -1 for negative, 0 for zero)
		public static int ESign (this float number)
		{
			return System.Math.Sign(number);
		}

		//clamps the number between minimum and maximum
		public static float EClamp (this float number, float minimum, float maximum)
		{
			return Mathf.Clamp(number, minimum, maximum);
		}

	//comparison methods
		//returns the SMALLEST from an enumerable of float values
		//implementation provided by PHATASS.Utils.Types.IComparableExtensions
		public static float EMinimum (this float[] floatArray)
		{
			IComparable<float>[] comparableArray = Array.ConvertAll<float, IComparable<float>>(
				array: floatArray,
				converter: item => (IComparable<float>)item
			);
			return (float) ((IEnumerable<IComparable<float>>) comparableArray).EMinimum();
		}

		//returns the LARGEST from an enumerable of float values
		//implementation provided by PHATASS.Utils.Types.IComparableExtensions
		public static float EMaximum (this float[] floatArray)
		{
			IComparable<float>[] comparableArray = Array.ConvertAll<float, IComparable<float>>(
				array: floatArray,
				converter: item => (IComparable<float>)item
			);
			return (float) ((IEnumerable<IComparable<float>>) comparableArray).EMaximum();
		}
	//ENDOF comparison methods
	}
}