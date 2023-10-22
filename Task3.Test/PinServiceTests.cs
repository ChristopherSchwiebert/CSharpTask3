using Csharp_Task_3.Services;

namespace Task3.Test;

[TestClass]
public class PinServiceTests
{
    private readonly IPinService _pinService;

    public PinServiceTests()
    {
        _pinService = new PinService();
    }
    
    [TestMethod]
    public void PinTestOneDigit()
    {
        var result = _pinService.GetPINs(new List<int> {8});
        CollectionAssert.AreEquivalent( new List<string>{ "5", "7", "8", "9", "0" }, result);
    }
    
    [TestMethod]
    public void PinTestTwoDigits()
    {
        var result = _pinService.GetPINs(new List<int> {1,1});
        CollectionAssert.AreEquivalent( new List<string>{ "11", "22", "44", "12", "21", "14", "41", "24", "42" }, result);
    }
    
    [TestMethod]
    public void PinTestThreeDigits()
    {
        var result = _pinService.GetPINs(new List<int> {3,6,9});
        CollectionAssert.AreEquivalent( new List<string>{ "339","366","399","658","636","258","268","669",
            "668","266","369","398","256","296","259","368","638","396","238",
            "356","659","639","666","359","336","299","338","696","269","358",
            "656","698","699","298","236","239" }, result);
    }
}