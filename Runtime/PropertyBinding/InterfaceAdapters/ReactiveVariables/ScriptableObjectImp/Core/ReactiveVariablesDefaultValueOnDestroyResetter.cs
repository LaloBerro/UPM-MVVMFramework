using UnityEngine;

namespace MVVM.PropertyBinding.InteraceAdapters
{
    public class ReactiveVariablesDefaultValueOnDestroyResetter : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] private ReactiveVariableSO[] _reactiveVariableSos;

        private void OnDestroy()
        {
            foreach (var reactiveVariableSO in _reactiveVariableSos)
            {
                reactiveVariableSO.ResetVariable();
            }
        }
    }
}