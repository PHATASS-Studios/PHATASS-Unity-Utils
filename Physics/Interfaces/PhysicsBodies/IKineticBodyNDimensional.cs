namespace PHATASS.Utils.Physics
{
// Interface representing a generic dimensional kinetic body
//	This is prepared to be specialized as an N-th dimensional object
//	TDimensionalVector is meant to be a type capable of storing and representing an N-dimensional vector
	public interface IKineticBodyNDimensional <TDimensionalVector>:
		IKineticBody
	{
		// Value representing n-dimensional momentum present in the body (mass * velocity)
		TDimensionalVector momentum { get; set; }

		// Inertial mass of this body. Velocity = momentum / mass
		double mass { get; set; }
	}
}
