#region Namespaces

using System;
using UnityEngine;
using Utilities;

#endregion

namespace Utilities.Core.Managed
{
	[Serializable]
    public struct ResourcesReference<T> where T : UnityEngine.Object
    {
		#region Properties

		public readonly bool IsEmpty => path.IsNullOrEmpty();

		#endregion

		#region Fields

		/// <summary>
		/// Path to the prefab relative to the Resources folder.
		/// </summary>
		public string path;

		#endregion

		#region Utilities

		/// <summary>
		/// Load the prefab from the Resources folder.
		/// </summary>
		public readonly T Load() => Resources.Load<T>(path);

		#endregion
    }
}
