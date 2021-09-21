using UnityEngine;
using Framework.Enum;
using CubeGames.Data;
using CubeGames.Event;
using System.Collections.Generic;

namespace CubeGames.Inputs
{
    public class InputManager : MonoBehaviour
    {
        #region Variables

        private RayData _rayData;

        private List<int> _layerList;

        [SerializeField] private CameraRayEventSO _cameraRayEventSO;

        [SerializeField] private UnitInputController _unitInputController;
        [SerializeField] private CameraInputController _cameraInputController;
        [SerializeField] private TargetInputController _targetInputController;

        #endregion Variables

        #region Properties

        
        private RayData RayData { get => _rayData; set => _rayData = value; }
		
        private List<int> LayerList { get => _layerList; set => _layerList = value; }
        
		private CameraRayEventSO CameraRayEventSO { get => _cameraRayEventSO; set => _cameraRayEventSO = value; }
        
        private UnitInputController UnitInputController { get => _unitInputController; set => _unitInputController = value; }
        private CameraInputController CameraInputController { get => _cameraInputController; set => _cameraInputController = value; }
		private TargetInputController TargetInputController { get => _targetInputController; set => _targetInputController = value; }

		#endregion Properties

		#region Awake - Update

		void Awake()
        {
            SubscribeEvents();
            
            Initialize();
        }

        void Update()
        {
            DetectInput();
        }

		#endregion Awake - Start - Update

		#region Functions

		private void Initialize()
        {
            RayData = new RayData();

            LayerList = new List<int> { LayerMask.NameToLayer("Target"), LayerMask.NameToLayer("Unit"), LayerMask.NameToLayer("Ground") };

            UnitInputController.Initialize();
            TargetInputController.Initialize();
        }

        private void SubscribeEvents()
        {
            UnitInputController.SubscribeEvents();
            TargetInputController.SubscribeEvents();
        }

        private void UnSubscribeEvents()
        {
            UnitInputController.UnSubscribeEvents();
            TargetInputController.UnSubscribeEvents();
        }

        private GameObject GetGameObject(RaycastHit[] raycastHitArray)
		{
            foreach (int layerInt in LayerList)
            {
                foreach (RaycastHit raycastHit in raycastHitArray)
                {
                    if (raycastHit.collider.gameObject.layer == layerInt)
                    {
                        return raycastHit.collider.gameObject;
                    }
                }
            }

            return null;
        }

        private void DetectInput()
		{
            if (Input.GetMouseButtonDown(0))
			{
                RayData.Reset();
                CameraRayEventSO.RaiseOnScreenToRayRequested(RayData, Input.mousePosition);

                RaycastHit[] raycastHitArray = Physics.RaycastAll(RayData.Ray, 1000f, LayerMask.GetMask("Ground", "Target", "Unit"));
                GameObject hitGameObject = GetGameObject(raycastHitArray);

                if (hitGameObject)
				{
                    if (hitGameObject.layer == LayerMask.NameToLayer("Target"))
                    {
                        TargetInputController.ActivateController();
                        return;
                    }
                    else if (hitGameObject.layer == LayerMask.NameToLayer("Unit"))
                    {
                        UnitInputController.ActivateControllerLeftClick();
                        return;
                    }
                    else if (hitGameObject.layer == LayerMask.NameToLayer("Ground"))
                    {
                        UnitInputController.ResetUnitGroupSelection();
                        return;
                    }
                }
            }
			else if (Input.GetMouseButtonDown(1))
			{
                UnitInputController.ActivateControllerRightClick();
            }
		}

        #endregion Functions
	}
}