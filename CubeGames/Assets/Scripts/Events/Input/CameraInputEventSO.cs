using UnityEngine;

namespace CubeGames.Event.SO
{
    [CreateAssetMenu]
    public class CameraInputEventSO : ScriptableObject
    {
        #region Events

        public delegate void CameraDirectionUpdated(Vector3 cameraDirection);
        public event CameraDirectionUpdated OnCameraDirectionUpdated;

        public delegate void CameraRotationUpdated(Vector3 cameraRotation);
        public event CameraRotationUpdated OnCameraRotationUpdated;

        #endregion Events

        #region Functions

        public void RaiseOnCameraDirectionUpdated(Vector3 cameraDirection)
        {
            OnCameraDirectionUpdated?.Invoke(cameraDirection);
        }

        public void RaiseOnCameraRotationUpdated(Vector3 cameraRotation)
        {
            OnCameraRotationUpdated?.Invoke(cameraRotation);
        }

        #endregion Functions
    }
}