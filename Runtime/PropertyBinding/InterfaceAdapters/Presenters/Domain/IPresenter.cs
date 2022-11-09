namespace MVVM.Presenters
{
    public interface IPresenter<DataToFormatType>
    {
        void SetValue(DataToFormatType dataToFormatType);
    }
}