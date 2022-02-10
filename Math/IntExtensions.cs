namespace PHATASS.Utils.Math
{
	//simple mathematics on int elements
	public static class IntExtensions
	{
		//steps an int towards another by given step
		public static int EStepTowards (this int value, int target, int step = 1)
		{
			//limit step to avoid overshooting
			if (value.EDifference(target) < step)
			{ step = value.EDifference(target); }

			return	(value > target)	
						? value - step	//if greater than target, decrement
				  :	(value < target)
						? value + step	//if smaller than target, increment
						: target;		//if on target return target
		}

		//returns the absolute difference between two ints
		public static int EDifference (this int a, int b)
		{
			return Math.Abs(a - b);
		}
	}
}