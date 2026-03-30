#region Namespaces

using Unity.Burst;
using UnityEngine;

#endregion

namespace Utilities
{
	[BurstCompile]
	public static class LayerMaskExtensions
	{
		[BurstCompile]
		public static bool HasLayer(this LayerMask layerMask, int layer)
		{
			return (layerMask & (1 << layer)) != 0;
		}
	}
}
