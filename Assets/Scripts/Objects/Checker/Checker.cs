using UnityEngine;

namespace SLGLib
{
    public class Checker : MonoBehaviour
    {
        [SerializeField] private int _Row;
        [SerializeField] private int _Col;

        public int Col => _Col;
        public int Row => _Row;

        public void Init(int row, int col)
        {
            _Row = row;
            _Col = col;
        }
        
        
    }
}