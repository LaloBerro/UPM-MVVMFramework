using System;
using UnityEngine;

namespace MVVM.PropertyBinding.InteraceAdapters
{
    public abstract class ReactiveVariableSO : ScriptableObject
    {
        public abstract Type VariableType { get; }
        public abstract IReactiveVariable GetReactiveVariable();
    }
}