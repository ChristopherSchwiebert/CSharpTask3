using System.Diagnostics;

namespace Csharp_Task_3.Services;

public sealed class PinService : IPinService
{
    private static readonly List<List<int>> _pinLock = new List<List<int>>
    {
        new() { 1, 2, 3 },
        new() { 4, 5, 6 },
        new() { 7, 8, 9 },
        new() { -1, 0, -1 }
    };

    private List<string> _combinations = new();

    private List<int> getPinVariations(int pinNumber)
    {
        var result = new List<int> {pinNumber};
        for (int i = 0; i < _pinLock.Count; i++)
        {
            for (int j = 0; j < _pinLock[i].Count; j++)
            {
                if (_pinLock[i][j] != pinNumber) continue;
                var down = i+1 < 0 || i+1 > _pinLock.Count -1 ? -1 : _pinLock[i+1][j];
                var up = i-1 < 0 || i-1 > _pinLock.Count -1 ? -1 : _pinLock[i-1][j];
                var right = j+1 < 0 || j+1 > _pinLock[i].Count -1 ? -1 : _pinLock[i][j+1];
                var left = j-1 < 0 || j-1 > _pinLock[i].Count -1 ? -1 : _pinLock[i][j-1];
                result.AddRange(new []
                {
                    down, up, left, right
                });
                result.RemoveAll(e => e == -1);
                return result;
            }
        }
        return result;
    }

    private void generateCombinations(List<List<int>> pinVariations, List<string> output, int depth = 0)
    {
        if (depth < pinVariations.Count)
        {
            foreach (var pin in pinVariations[depth])
            {
                var currentPin = new List<string>();
                currentPin.AddRange(output);
                currentPin.Add(pin.ToString());
                if (currentPin.Count == pinVariations.Count)
                {
                    _combinations.Add(string.Join("", currentPin));
                }
                generateCombinations(pinVariations, currentPin, depth + 1);
            }
        }
    }

    public List<string> GetPINs(List<int> guess)
    {
        _combinations = new();
        var results = guess.Select(pin => getPinVariations(pin)).ToList();
        generateCombinations(results, new List<string>());
        return _combinations;
    }
}