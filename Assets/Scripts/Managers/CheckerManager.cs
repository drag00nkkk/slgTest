using System.Collections;
using System.Collections.Generic;
using SLGLib;
using UnityEngine;

public class CheckerManager : MonoSingleton<CheckerManager>
{
    [SerializeField] private Checker[] _checkers;
    [SerializeField] private int _boardSize;

    public void Init(Checker[] inCheckers, int boardSize)
    {
        _checkers = inCheckers;
        _boardSize = boardSize;
    }

    public Checker GetCheckerBaseOnChecker(Checker baseChecker, int rowDelta, int colDelta)
    {
        if (!baseChecker)
        {
            Debug.LogWarning("baseChecker is invalid ");
            return null;
        }

        var newRow = GetRoundCoord(baseChecker.Row, rowDelta);
        var newCol = GetRoundCoord(baseChecker.Col, colDelta);
        return GetChecker(newRow, newCol);
    }

    private int GetRoundCoord(int ori, int delta)
    {
        return (ori + _boardSize + delta) % _boardSize;
    }

    public Checker GetChecker(int row, int col)
    {
        return _checkers[row * _boardSize + col];
    }
}