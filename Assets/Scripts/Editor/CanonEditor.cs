using UnityEditor;

namespace UniversWar
{
    [CustomEditor(typeof(Canon))]
    public class CanonEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var canon = target as Canon;
        }
    }
}