using UnityEngine;

public class LineManager : MonoBehaviour
{
    [SerializeField]
    private LineData[] _linesData = new LineData[4];
    public LineData[] LinesData => _linesData;

    public LineData GetLineData(CardinalPoint point)
    {
        for (int i = 0; i < _linesData.Length; i++)
        {
            if (_linesData[i].cardinalPoint == point)
                return _linesData[i];
        }

        return default;
    }
}
