using System;
using UnityEngine;

namespace MVVM.OneWay.InteraceAdapters
{
    public abstract class ReactiveVariableSO : ScriptableObject
    {
        public abstract Type VariableType { get; }
        public abstract IReactiveVariable GetReactiveVariable();
    }
}