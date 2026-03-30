#region Namespaces

using UnityEngine;

#endregion

namespace Utilities.Core
{
	/// <summary>
	/// Base class for creating scriptable object singletons that can be loaded from Resources.
	/// This class provides a convenient way to access global settings and configurations.
	/// </summary>
	/// <typeparam name="T">The type of the scriptable object singleton, must inherit from ScriptableSingleton</typeparam>
	public abstract class ScriptableSingleton<T> : ScriptableObject where T : ScriptableSingleton<T>
	{
		/// <summary>
		/// Gets the singleton instance of the scriptable object.
		/// If the instance doesn't exist, it will be loaded from Resources/Settings/{TypeName}.
		/// </summary>
		public static T Default
		{
			get
			{
				if (!instance)
					instance = Resources.Load<T>($"Settings/{typeof(T).Name}");

				return instance;
			}
		}

		/// <summary>
		/// The cached instance of the scriptable object singleton.
		/// </summary>
		private static T instance;
	}
}
