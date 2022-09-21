using System;
using System.Linq;
using UniRx;
using UnityEngine;

namespace MVVM.PropertyBinding.InteraceAdapters
{
    public class PropertyBindingViewModel
    {
        private readonly IReactiveVariable[] _reactiveVariables;

        public PropertyBindingViewModel(IReactiveVariable[] reactiveVariables)
        {
            _reactiveVariables = reactiveVariables;
        }

        public IReactiveVariable GetReactiveVariableByType(Type type)
        {
            IReactiveVariable reactiveVariable = _reactiveVariables.Select((reactiveVariable, index) => new { Index = index, ReactiveVariable = reactiveVariable })
                                                            .Where(element => element.ReactiveVariable.VariableType == type)
                                                            .FirstOrDefault().ReactiveVariable;

            return reactiveVariable;
        }
    }
}