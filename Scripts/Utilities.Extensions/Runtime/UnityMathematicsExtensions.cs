#region Namespaces

using Unity.Mathematics;

#endregion

namespace Utilities
{
	public static class UnityMathematicsExtensions
	{
		public static void Encapsulate(this ref AABB aabb, AABB other)
		{
			aabb.Encapsulate(other.Center - other.Extents);
			aabb.Encapsulate(other.Center + other.Extents);
		}
		public static void Encapsulate(this ref AABB aabb, float3 point)
		{
			aabb.SetMinMax(math.min(aabb.Min, point), math.max(aabb.Max, point));
		}
		public static void SetMinMax(this ref AABB aabb, float3 min, float3 max)
		{
			aabb.Extents = (max - min) * 0.5f;
			aabb.Center = min + aabb.Extents;
		}
	}
}
