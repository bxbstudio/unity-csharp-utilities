#region Namespaces

using UnityEditor;
using UnityEngine;
using Utilities;

#endregion

namespace Utilities.Core.Managed.Editor
{
	[CustomPropertyDrawer(typeof(SceneAssetReference))]
	internal class SceneAssetReferenceDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property);

			var pathRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
			var pathProperty = property.FindPropertyRelative(nameof(SceneAssetReference.path));
			var guidProperty = property.FindPropertyRelative(nameof(SceneAssetReference.guid));
			SceneAsset sceneAsset = !guidProperty.stringValue.IsNullOrEmpty() && GUID.TryParse(guidProperty.stringValue, out var guid) ? AssetDatabase.LoadAssetByGUID<SceneAsset>(guid) : null;
			SceneAsset newSceneAsset = (SceneAsset)EditorGUI.ObjectField(pathRect, label, sceneAsset, typeof(SceneAsset), false);

			if (sceneAsset != newSceneAsset)
			{
				pathProperty.stringValue = newSceneAsset ? AssetDatabase.GetAssetPath(newSceneAsset) : string.Empty;
				guidProperty.stringValue = newSceneAsset ? AssetDatabase.GUIDFromAssetPath(pathProperty.stringValue).ToString() : string.Empty;
			}

			EditorGUI.EndProperty();
		}
	}
}
