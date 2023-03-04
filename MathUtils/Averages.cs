using System.Collections.Generic;

namespace PHATASS.Utils.MathUtils
{
	public static class Averages
	{
		//Takes an enumeration of pairs of value/weight values and calculates their weighted arithmetic average
		//if no entries or total weight is 0 returns 0
		public static float WeightedArithmeticAverage(IEnumerable<(float value,float weight)> weightedValuesEnumerable)
		{
			float totalValue = 0f;
			float totalWeight = 0f;

			foreach ((float value,float weight) weightedValuePair in weightedValuesEnumerable)
			{
				totalValue += weightedValuePair.value * weightedValuePair.weight;
				totalWeight += weightedValuePair.weight;
			}

			if (totalWeight == 0) { return 0; }
			else { return totalValue/totalWeight; }
		}
	}
}