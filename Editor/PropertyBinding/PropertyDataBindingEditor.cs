using System.Collections.Generic;
using System.Reflection;
using MVVM.PropertyBinding.InteraceAdapters;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MVVM.PropertyBinding.View
{
    [CustomEditor(typeof(PropertyDataBinding))]
    public class PropertyDataBindingEditor : Editor
    {
        private int _selectedTargetProperyIndex = 0;
        private int _selectedReactiveFieldIndex = 0;
        private string _selectedReactiveGenericTypeName;

        private PropertyDataBinding _dataBinding;
        private Dictionary<string, int> _options = new Dictionary<string, int>();

        public override void OnInspectorGUI()
        {
            _dataBinding = (PropertyDataBinding)target;

            base.OnInspectorGUI();

            DrawReactivePropertyDropdown(_dataBinding.ViewModel);

            if (_dataBinding.HaveError)
            {
                _dataBinding.HaveError = false;
                return;
            }

            DrawTargetPropertyList(_dataBinding._target);
        }

        private void DrawReactivePropertyDropdown(PropertyBindingViewModelSO viewModel)
        {
            _selectedReactiveFieldIndex = _dataBinding.ReactiveVariableIndex;

            var reactives = viewModel.ReactiveVariableSOs;

            if (reactives.Length <= 0)
            {
                DrawErrorBox("The ViewModel don't have any ReactiveVariable");
                _dataBinding.HaveError = true;
                return;
            }

            string[] options = new string[reactives.Length];

            for (int i = 0; i < options.Length; i++)
            {
                if (reactives[i] == null)
                {
                    DrawErrorBox("The ViewModel has a null ReactiveVariable, review the scriptable plis!");
                    _dataBinding.HaveError = true;

                    return;
                }

                options[i] = reactives[i].VariableType.Name;
            }

            int selectedReactiveFieldIndex = EditorGUILayout.Popup("Reactive to", _selectedReactiveFieldIndex, options);
            _selectedReactiveFieldIndex = selectedReactiveFieldIndex;

            _dataBinding.ReactiveVariableIndex = _selectedReactiveFieldIndex;
            _selectedReactiveGenericTypeName = reactives[_selectedReactiveFieldIndex].VariableType.Name;
            _selectedReactiveGenericTypeName = reactives[_selectedReactiveFieldIndex].VariableType.Name;
        }


        private void DrawTargetPropertyList(Object _target)
        {
            var bindingFlags = BindingFlags.Instance | BindingFlags.Public;
            var propertiesInfo = _target.GetType().GetProperties(bindingFlags);

            List<string> options = new List<string>();
            _options.Clear();

            int correctIndex = 0;

            for (int i = 0; i < propertiesInfo.Length; i++)
            {
                if (propertiesInfo[i].PropertyType.Name != _selectedReactiveGenericTypeName)
                    continue;

                if (propertiesInfo[i].Name == _dataBinding.TargetPropertyName)
                    _selectedTargetProperyIndex = correctIndex;

                options.Add(propertiesInfo[i].Name);
                _options.Add(propertiesInfo[i].Name, i);

                correctIndex++;
            }

            if (options.Count <= 0)
            {
                _dataBinding.HaveError = true;
                Debug.LogError("There aren't any target property for the selected reactive");
                return;
            }

            int selectedTargetProperyIndex = EditorGUILayout.Popup("Property to Set", _selectedTargetProperyIndex, options.ToArray());

            string optionSelected = options[selectedTargetProperyIndex];
            int keySelected = _options[optionSelected];

            _dataBinding.TargetPropertyName = propertiesInfo[keySelected].Name;
            if (selectedTargetProperyIndex != _selectedTargetProperyIndex)
                _selectedTargetProperyIndex = selectedTargetProperyIndex;
        }

        private void DrawErrorBox(string message)
        {
            EditorGUILayout.HelpBox(message, MessageType.Error);
        }
    }
}