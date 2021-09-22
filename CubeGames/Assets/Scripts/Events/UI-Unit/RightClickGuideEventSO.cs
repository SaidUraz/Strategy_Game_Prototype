using UnityEngine;

namespace CubeGames.Event
{
    [CreateAssetMenu]
    public class RightClickGuideEventSO : ScriptableObject
    {
        #region Events

        public delegate void RightClick();
        public event RightClick OnRightClickUp;
        public event RightClick OnRightClickDown;

        public delegate void RightClickHold(Vector3 startPosition, Vector3 endPosition);
        public event RightClickHold OnRightClickHold;

        #endregion Events

        #region Functions

        public void RaiseOnRightClickUp()
        {
            OnRightClickUp?.Invoke();
        }

        public void RaiseOnRightClickDown()
        {
            OnRightClickDown?.Invoke();
        }

        public void RaiseOnRightClickHold(Vector3 startPosition, Vector3 endPosition)
        {
            OnRightClickHold?.Invoke(startPosition, endPosition);
        }

        #endregion Functions
    }
}