using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SLGLib
{
    public class SpawnCheckerHelper : MonoBehaviour
    {
        [SerializeField] private GameObject _CheckerStand;
        [SerializeField] private int _BoardBoardSize;
        [SerializeField] private float _CheckerCoordSpace;
        [SerializeField] private Transform _Root;

        private const string CheckerNameFormat = "Checker_{0}_{1}";

        public GameObject CheckerStand
        {
            get => _CheckerStand;
            set => _CheckerStand = value;
        }

        public int BoardSize
        {
            get => _BoardBoardSize;
            set => _BoardBoardSize = value;
        }

        public float CheckerCoordSpace
        {
            get => _CheckerCoordSpace;
            set => _CheckerCoordSpace = value;
        }

        public Transform Root
        {
            get => _Root;
            set => _Root = value;
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void SpawnCheckers()
        {
            if (_CheckerStand == null)
            {
                Debug.LogWarning("CheckerStand is invalid !");
                return;
            }

            if (_BoardBoardSize <= 0)
            {
                Debug.LogWarning("Size is invalid !");
                return;
            }

            if (_Root == null)
            {
                Debug.LogWarning("Root is invalid !");
                return;
            }

            if (_CheckerStand.GetComponent<Checker>() == null)
            {
                _CheckerStand.AddComponent<Checker>();
            }

            Checker[] checkers = new Checker[_BoardBoardSize * _BoardBoardSize];
            for (int row = 0; row < _BoardBoardSize; row++)
            {
                for (int col = 0; col < _BoardBoardSize; col++)
                {
                    var newChecker = Instantiate(_CheckerStand, _Root, false);
                    newChecker.name = string.Format(CheckerNameFormat, row, col);

                    var rowCoord = row * _CheckerCoordSpace;
                    var colCoord = col * _CheckerCoordSpace;

                    var coord = new Vector3(rowCoord, 0, colCoord);
                    newChecker.transform.localPosition = coord;
                    
                    newChecker.GetComponent<Checker>().Init(row, col);

                    checkers[row * _BoardBoardSize + col] = newChecker.GetComponent<Checker>();
                }
            }

            var checkerManager = FindObjectOfType<CheckerManager>();
            var _checkers = checkerManager.GetType().GetField("_checkers", BindingFlags.Instance | BindingFlags.NonPublic);
            _checkers.SetValue(checkerManager, checkers);
            var _boardSize = checkerManager.GetType().GetField("_boardSize", BindingFlags.Instance | BindingFlags.NonPublic);
            _boardSize.SetValue(checkerManager, _BoardBoardSize);
        }

        public void ClearCheckers()
        {
            if (_Root == null)
            {
                Debug.LogWarning("Root is invalid !");
                return;
            }

            var children = _Root.GetComponentsInChildren<Checker>();
            var len =children.Length;
            for (int i = len - 1; i >= 0; i--)
            {
                DestroyImmediate(children[i].gameObject);
            }
        }
    }
}