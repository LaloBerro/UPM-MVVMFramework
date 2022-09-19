using UnityEngine;

namespace MVVM.TwoWay.InteraceAdapters
{
    [CreateAssetMenu(fileName = "TwoWayViewModel", menuName = "ScriptableObjects/MVVM/ViewModel/TwoWayViewModel", order = 0)]
    public class TwoWayViewModelSO : ScriptableObject
    {
        private TwoWayViewModel _twoWayViewModel = null;

        public TwoWayViewModel GetViewModel()
        {
            if (null == _twoWayViewModel)
                _twoWayViewModel = new TwoWayViewModel();

            return _twoWayViewModel;
        }
    }
}