using UnityEngine;
using CubeGames.Event.SO;

namespace CubeGames.Inputs
{
    public class CameraInputController : MonoBehaviour
    {
        #region Variables

        private float _zoomInOut;
        
        private float _horizontalDirection;
        private float _verticalDirection;
        
        private float _horizontalRotation;
        private float _verticalRotation;

        private Vector3 _cameraDirection;
        private Vector3 _cameraRotation;

        [SerializeField] private CameraInputEventSO _cameraInputEventSO;

        #endregion Variables

        #region Properties

		private float ZoomInOut { get => _zoomInOut; set => _zoomInOut = value; }
        
        private float HorizontalDirection { get => _horizontalDirection; set => _horizontalDirection = value; }
        private float VerticalDirection { get => _verticalDirection; set => _verticalDirection = value; }
		
        private float HorizontalRotation { get => _horizontalRotation; set => _horizontalRotation = value; }
		private float VerticalRotation { get => _verticalRotation; set => _verticalRotation = value; }

        private Vector3 CameraDirection { get => _cameraDirection; set => _cameraDirection = value; }
		private Vector3 CameraRotation { get => _cameraRotation; set => _cameraRotation = value; }
		
        private CameraInputEventSO CameraInputEventSO { get => _cameraInputEventSO; set => _cameraInputEventSO = value; }

		#endregion Properties

		#region Update

        void Update()
        {
            UpdateRotationVectors();
            UpdateDirectionVectors();
        }

		#endregion Update

		#region Functions

        private void UpdateRotationVectors()
		{
            if (Input.GetKey(KeyCode.Mouse2))
			{
                HorizontalRotation = Input.GetAxis("Mouse X");
                VerticalRotation = Input.GetAxis("Mouse Y");

                CameraRotation = new Vector3(HorizontalRotation, VerticalRotation, 0);
				CameraInputEventSO.RaiseOnCameraRotationUpdated(CameraRotation);
			}
		}

        private void UpdateDirectionVectors()
        {
            HorizontalDirection = Input.GetAxis("Horizontal");
            VerticalDirection = Input.GetAxis("Vertical");

			if (HorizontalDirection != 0 || VerticalDirection != 0)
			{
                CameraDirection = new Vector3(HorizontalDirection, 0, VerticalDirection);
                CameraInputEventSO.RaiseOnCameraDirectionUpdated(CameraDirection);
            }
        }

        #endregion Functions
    }
}