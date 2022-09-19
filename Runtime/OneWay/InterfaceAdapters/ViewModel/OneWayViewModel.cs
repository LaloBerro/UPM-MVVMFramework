using System;
using System.Linq;
using UniRx;
using UnityEngine;

namespace MVVM.OneWay.InteraceAdapters
{
    public class OneWayViewModel
    {
        private readonly IReactiveVariable[] _reactiveVariables;

        public OneWayViewModel(IReactiveVariable[] reactiveVariables)
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