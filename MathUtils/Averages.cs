using System.Collections.Generic;

using Vector2 = UnityEngine.Vector2;

namespace PHATASS.Utils.MathUtils
{
	public static class Averages
	{
	//Arithmetic averages
	//	Takes an enumeration of values and calculates their average
	//	if no entries returns 0
		public static float FloatArithmeticAverage (IEnumerable<float> valuesEnumerable)
		{
			float totalValue = 0f;
			int entries = 0;

			foreach (float value in valuesEnumerable)
			{
				totalValue += value;
				entries++;
			}

			if (entries <= 0) { return 0f; }
			else { return totalValue / entries; }
		}

		public static Vector2 Vector2ArithmeticAverage (IEnumerable<Vector2> valuesEnumerable)
		{
			Vector2 totalValue = Vector2.zero;
			int entries = 0;

			foreach (Vector2 value in valuesEnumerable)
			{
				totalValue += value;
				entries++;
			}

			if (entries <= 0) { return Vector2.zero; }
			else { return totalValue / entries; }
		}
	//ENDOF Arithmetic averages

	//Weighted Averages
	//	Takes an enumeration of pairs of value/weight values and calculates their weighted arithmetic average
	//	if no entries or total weight is 0 returns 0
		public static float FloatWeightedArithmeticAverage (IEnumerable<(float value,float weight)> weightedValuesEnumerable)
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

		public static Vector2 Vector2WeightedArithmeticAverage (IEnumerable<(Vector2 value,float weight)> weightedValuesEnumerable)
		{
			Vector2 totalValue = Vector2.zero;
			float totalWeight = 0f;

			foreach((Vector2 value, float weight) weightedValuePair in weightedValuesEnumerable)
			{
				totalValue += weightedValuePair.value * weightedValuePair.weight;
				totalWeight += weightedValuePair.weight;
			}

			if (totalWeight == 0) { return Vector2.zero; }
			else { return totalValue/totalWeight; }
		}
	//ENDOF Weighted Averages
	}
}