using UnityEngine;
using CubeGames.Data;

namespace CubeGames.Event
{
    [CreateAssetMenu]
    public class CameraPositionConvertionEventSO : ScriptableObject
    {
        #region Events

        public delegate void PositionConvertion(PositionData positionData, Vector3 position);
        public event PositionConvertion OnScreenToViewportPointRequested;
        public event PositionConvertion OnWorldToViewportPointRequested;

        #endregion Events

        #region Functions

        public void RaiseOnScreenToViewportPointRequested(PositionData positionData, Vector3 position)
        {
            OnScreenToViewportPointRequested?.Invoke(positionData, position);
        }

        public void RaiseOnWorldToViewportPointRequested(PositionData positionData, Vector3 position)
        {
            OnWorldToViewportPointRequested?.Invoke(positionData, position);
        }

        #endregion Functions
    }
}