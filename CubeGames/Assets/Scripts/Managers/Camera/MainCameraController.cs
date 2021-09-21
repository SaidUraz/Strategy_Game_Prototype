using UnityEngine;
using CubeGames.Data;
using CubeGames.Event;
using CubeGames.Event.SO;

namespace CubeGames.Cameras
{
    public class MainCameraController : MonoBehaviour
    {
        #region Variables

        [SerializeField] float _CameraSpeed;

        private Rigidbody _rigidbody;
        [SerializeField] private Camera _mainCamera;

        [SerializeField] private CameraRayEventSO _cameraRayEventSO;
        [SerializeField] private CameraInputEventSO _cameraInputEventSO;

        #endregion Variables

        #region Properties

        private float CameraSpeed { get => _CameraSpeed; set => _CameraSpeed = value; }

		private Rigidbody Rigidbody { get => _rigidbody; set => _rigidbody = value; }
		private Camera MainCamera { get => _mainCamera; set => _mainCamera = value; }

        private CameraRayEventSO CameraRayEventSO { get => _cameraRayEventSO; set => _cameraRayEventSO = value; }
        private CameraInputEventSO CameraInputEventSO { get => _cameraInputEventSO; set => _cameraInputEventSO = value; }

		#endregion Properties

        #region Functions

        public void Initialize()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }

        public void SubscribeEvents()
        {
            CameraRayEventSO.OnScreenToRayRequested += FillRayData;
            CameraInputEventSO.OnCameraDirectionUpdated += MoveCamera;
            CameraInputEventSO.OnCameraRotationUpdated += RotateCamera;
        }

        public void UnSubscribeEvents()
        {
            CameraRayEventSO.OnScreenToRayRequested -= FillRayData;
            CameraInputEventSO.OnCameraDirectionUpdated -= MoveCamera;
            CameraInputEventSO.OnCameraRotationUpdated -= RotateCamera;
        }

        private void RotateCamera(Vector3 cameraRotation)
		{
            transform.rotation *= Quaternion.Euler(cameraRotation.y, -cameraRotation.x, 0);
		}

        private void MoveCamera(Vector3 cameraDirection)
		{
            Rigidbody.velocity = cameraDirection * CameraSpeed;
		}

        private void FillRayData(RayData rayData, Vector3 position)
		{
            rayData.Ray = MainCamera.ScreenPointToRay(position);
		}

        public Vector3 GetScreenToWorldPoint(Vector3 position)
        {
            return MainCamera.ScreenToWorldPoint(position);
        }

        public Vector3 GetWorldToScreenPoint(Vector3 position)
        {
            return MainCamera.WorldToScreenPoint(position);
        }

        public Vector3 GetScreenToViewportPoint(Vector3 position)
        {
            return MainCamera.ScreenToViewportPoint(position);
        }

        public Vector3 GetWorldToViewportPoint(Vector3 position)
        {
            return MainCamera.WorldToViewportPoint(position);
        }

        #endregion Functions
    }
}