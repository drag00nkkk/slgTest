using System;
using System.Collections;
using System.Collections.Generic;
using SLGLib;
using UnityEngine;

public class Selector : MonoBehaviour
{
    private Checker _selectedChecker = null;
    public Checker SelectedChecker => _selectedChecker;
    [SerializeField] private GameObject SelectorAsset = null;

    private static GameObject _selectorInstance;

    public void SpawnSelectorOnChecker(Checker checker)
    {
        ShowSelector(true);
        MoveToChecker(checker);
    }

    private void ShowSelector(bool bShow)
    {
        if (!_selectorInstance)
        {
            _selectorInstance = Instantiate(SelectorAsset, transform, false);
            _selectorInstance.name = "Selector";
            _selectorInstance.transform.localPosition = Vector3.zero;
        }
        _selectorInstance.SetActive(bShow);
    }

    private void SelectChecker(Checker checker)
    {
        _selectedChecker = checker;
    }

    public void MoveToChecker(Checker checker)
    {
        SelectChecker(checker);
        transform.position = checker.transform.position;
    }
}