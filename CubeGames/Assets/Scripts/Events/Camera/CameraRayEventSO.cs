using UnityEngine;
using CubeGames.Data;

namespace CubeGames.Event
{
    [CreateAssetMenu]
    public class CameraRayEventSO : ScriptableObject
    {
        #region Events

        public delegate void ScreenToRayRequest(RayData rayData, Vector3 mousePosition);
        public event ScreenToRayRequest OnScreenToRayRequested;

        #endregion Events

        #region Variables



        #endregion Variables

        #region Properties



        #endregion Properties

        #region Functions

        public void RaiseOnScreenToRayRequested(RayData rayData, Vector3 mousePosition)
        {
            OnScreenToRayRequested?.Invoke(rayData, mousePosition);
        }

        #endregion Functions
    }
}