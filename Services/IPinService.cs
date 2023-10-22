namespace Csharp_Task_3.Services;

public interface IPinService
{
    public List<string> GetPINs(List<int> guess);
}