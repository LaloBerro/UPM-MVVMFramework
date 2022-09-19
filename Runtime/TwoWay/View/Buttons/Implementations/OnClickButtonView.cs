namespace MVVM.TwoWay.View
{
    public class OnClickButtonView : ButtonView
    {
        public override void Subscribe()
        {
            _button.onClick.AddListener(() => { ExecuteCommand(); });
        }

        protected override void Dispose()
        {
            _button.onClick.RemoveAllListeners();
        }
    }
}