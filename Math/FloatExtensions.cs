namespace PHATASS.Utils.Math
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
			return Math.Abs(a - b);
		}
	}
}