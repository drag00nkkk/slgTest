using System.Collections;
using System.Collections.Generic;
using SLGLib;
using UnityEngine;

namespace SLGLib
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private Selector _selector = null;
        private Vector2 controlDirection;

        // Start is called before the first frame update
        void Start()
        {
            InputManager.Instance.OnKeyUp += OnKeyUp;
        }

        public void OnGameStart()
        {
            _selector.SpawnSelectorOnChecker(CheckerManager.Instance.GetChecker(0, 0));
        }

        private void OnKeyUp(KeyCode inKey)
        {
            switch (inKey)
            {
                case KeyCode.A:
                    MoveSelector(-1, 0);
                    break;
                case KeyCode.D:
                    MoveSelector(1, 0);
                    break;
                case KeyCode.W:
                    MoveSelector(0, -1);
                    break;
                case KeyCode.S:
                    MoveSelector(0, 1);
                    break;
                default:
                    break;
            }
        }

        private void CastInputXY2CoordDelta(int xDelta, int yDelta, out int rowDelta, out int colDelta)
        {
            rowDelta = yDelta;
            colDelta = xDelta;
        }

        private void MoveSelector(int xDelta, int yDelta)
        {
            if (!_selector)
            {
                return;
            }

            CastInputXY2CoordDelta(xDelta, yDelta, out int rowDelta, out int colDelta);
            var newChecker =
                CheckerManager.Instance.GetCheckerBaseOnChecker(_selector.SelectedChecker, rowDelta, colDelta);
            _selector.MoveToChecker(newChecker);
        }
    }
}