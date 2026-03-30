#region Namespaces

using System;
using System.IO;
using Utilities;

#endregion

namespace Utilities.Core.Managed
{
	[Serializable]
    public struct SceneAssetReference
    {
		#region Fields

		public string path;
		public string guid;

		#endregion

		#region Properties

		public readonly string Name => Path.GetFileNameWithoutExtension(path);
		public readonly bool IsEmpty => guid.IsNullOrEmpty();

		#endregion

		#region Utilities

		public readonly override bool Equals(object obj)
		{
			return obj is SceneAssetReference other && Equals(other);
		}
		public readonly bool Equals(SceneAssetReference other)
		{
			return path == other.path;
		}
		public readonly override int GetHashCode()
		{
			return path.GetHashCode();
		}

		#endregion

		#region Operators

		public static bool operator ==(SceneAssetReference left, SceneAssetReference right) => left.Equals(right);
		public static bool operator !=(SceneAssetReference left, SceneAssetReference right) => !left.Equals(right);
		
		#endregion
    }
}
