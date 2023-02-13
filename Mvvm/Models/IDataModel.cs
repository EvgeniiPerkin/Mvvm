namespace Mvvm.Models
{
    public interface IDataModel
    {
        string Data { get; set; }
        string? Reverse(); 
    }
}
