using UnityEngine;
using CubeGames.Data;
using CubeGames.Event;
using CubeGames.Target;

namespace CubeGames.Inputs
{
    public class TargetInputController : MonoBehaviour
    {
        #region Variables;

        private bool _isClickActive;
        
        private float _holdtimer;

        private RaycastHit _raycastHit;

        private RayData _rayData;

        private GameObject _targetControllerToMove;

        [SerializeField] private CameraRayEventSO _cameraRayEventSO;
        [SerializeField] private UnitTargetEventSO _unitTargetEventSO;
        [SerializeField] private UnitTargetPositionChangeEventSO _unitTargetPositionChangeEventSO;

        #endregion Variables

        #region Properties

		private bool IsClickActive { get => _isClickActive; set => _isClickActive = value; }
		
        private float Holdtimer { get => _holdtimer; set => _holdtimer = value; }
		
        private RayData RayData { get => _rayData; set => _rayData = value; }
        
        private GameObject TargetControllerGameObject { get => _targetControllerToMove; set => _targetControllerToMove = value; }
		
		private CameraRayEventSO CameraRayEventSO { get => _cameraRayEventSO; set => _cameraRayEventSO = value; }
		private UnitTargetEventSO UnitTargetEventSO { get => _unitTargetEventSO; set => _unitTargetEventSO = value; }
		private UnitTargetPositionChangeEventSO UnitTargetPositionChangeEventSO { get => _unitTargetPositionChangeEventSO; set => _unitTargetPositionChangeEventSO = value; }

		#endregion Properties

		#region Awake - Update

		void Awake()
        {
            Initialize();
        }

        void Update()
        {
            DetectLongClick();
            MoveTargetGameObject();
        }

		#endregion Awake - Update

		#region Functions

		public void Initialize()
        {
            RayData = new RayData();

            enabled = false;
        }

        private void DetectLongClick()
		{
			if (IsClickActive)
			{
                if (Input.GetMouseButton(0))
                {
                    Holdtimer += Time.deltaTime;

                    if (Holdtimer >= 0.08f)
                    {
                        OnHoldInput();

                        Holdtimer = 0;
                        IsClickActive = false;
                    }
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    OnClickInput();

                    DeactivateController();
                }
            }
		}

        public void ActivateController()
        {
            IsClickActive = true;

            enabled = true;
        }

        public void DeactivateController()
        {
            Holdtimer = 0;
            IsClickActive = false;
            TargetControllerGameObject = null;

            enabled = false;
        }

        private void OnClickInput()
		{
            RayData.Reset();
            CameraRayEventSO.RaiseOnScreenToRayRequested(RayData, Input.mousePosition);

            bool isHit = Physics.Raycast(RayData.Ray, out _raycastHit, 1000f, LayerMask.GetMask("Target"));
            if (isHit)
            {
                IsClickActive = true;
                TargetControllerGameObject = _raycastHit.collider.gameObject;
            }

            if (TargetControllerGameObject)
                UnitTargetEventSO.RaiseOnUnitSentToTarget(TargetControllerGameObject.GetComponent<TargetController>());
        }

        private void OnHoldInput()
		{
            RayData.Reset();
            CameraRayEventSO.RaiseOnScreenToRayRequested(RayData, Input.mousePosition);
            
            bool isHit = Physics.Raycast(RayData.Ray, out _raycastHit, 1000f, LayerMask.GetMask("Target"));
            if (isHit)
            {
                IsClickActive = true;
                TargetControllerGameObject = _raycastHit.collider.gameObject;
            }
        }

        private void MoveTargetGameObject()
		{
            if (TargetControllerGameObject)
			{
                CameraRayEventSO.RaiseOnScreenToRayRequested(RayData, Input.mousePosition);

                bool isHit = Physics.Raycast(RayData.Ray, out _raycastHit, 1000f, LayerMask.GetMask("Ground"));
				if (isHit)
				{
                    TargetController targetController = TargetControllerGameObject.GetComponent<TargetController>();

                    if (targetController)
					{
                        targetController.MoveTargetGameObject(_raycastHit.point);
                        UnitTargetPositionChangeEventSO.RaiseOnTargetPositionUpdated(targetController);
                    }
                }
            }

			if (Input.GetMouseButtonUp(0))
			{
                DeactivateController();
            }
        }

        #endregion Functions
    }
}