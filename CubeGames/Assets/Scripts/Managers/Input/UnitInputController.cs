using UnityEngine;
using CubeGames.Data;
using CubeGames.Event;
using CubeGames.Unit;
using Framework.Enum;
using CubeGames.Cameras;
using System.Collections.Generic;

namespace CubeGames.Inputs
{
    public class UnitInputController : MonoBehaviour
    {
        #region Variables

        private Vector3 _rectStartPosition;
        private Vector3 _rectEndPosition;
        private Vector3 _rectCurrentPosition;

        private RayData _rayData;

        [SerializeField] private MainCameraController _mainCameraController;

        [SerializeField] private SelectedUnitSO _selectedUnitSO;
        [SerializeField] private CameraRayEventSO _cameraRayEventSO;
        [SerializeField] private InputStateEventSO _inputStateEventSO;

        #endregion Variables

        #region Properties
		
        private Vector3 RectStartPosition { get => _rectStartPosition; set => _rectStartPosition = value; }
		private Vector3 RectEndPosition { get => _rectEndPosition; set => _rectEndPosition = value; }
		private Vector3 RectCurrentPosition { get => _rectCurrentPosition; set => _rectCurrentPosition = value; }

		private RayData RayData { get => _rayData; set => _rayData = value; }
        
		private MainCameraController MainCameraController { get => _mainCameraController; set => _mainCameraController = value; }
        
        private SelectedUnitSO SelectedUnitSO { get => _selectedUnitSO; set => _selectedUnitSO = value; }
        private CameraRayEventSO CameraRayEventSO { get => _cameraRayEventSO; set => _cameraRayEventSO = value; }
		private InputStateEventSO InputStateEventSO { get => _inputStateEventSO; set => _inputStateEventSO = value; }

		#endregion Properties

		#region Update

        void Update()
        {
            ReadLeftClickInput();
            ReadRightClickInput();
        }

		#endregion Update

		#region Functions

		public void Initialize()
        {
            RayData = new RayData();
		}

		public void SubscribeEvents()
        {
            
        }

        public void UnSubscribeEvents()
        {
        }

        public void ActivateControllerRightClick()
		{
            enabled = true;
            OnRightMouseDown(); 
        }

        public void ActivateControllerLeftClick()
        {
            enabled = true;
        }

        private void ReadLeftClickInput()
		{
			if (Input.GetMouseButtonUp(0))
			{
                UnitController unitController = DetectAndGetUnitController();

                if (unitController)
				{
					if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
					{
                        SelectedUnitSO.AddUnit(unitController, true);
                    }
					else
					{
                        SelectedUnitSO.AddUnit(unitController, false);
                    }
				}
            }
        }
        
        private void ReadRightClickInput()
		{
            if (Input.GetMouseButton(1))
            {
                OnRightMouse();
            }
            else if (Input.GetMouseButtonUp(1))
            {
                RectEndPosition = Input.mousePosition;

                OnRightMouseUp();
            }
        }
        
        private UnitController DetectAndGetUnitController()
		{
            RayData.Reset();
            CameraRayEventSO.RaiseOnScreenToRayRequested(RayData, Input.mousePosition);
            RaycastHit[] raycastHitArray = Physics.RaycastAll(RayData.Ray, 1000f);

			foreach (RaycastHit item in raycastHitArray)
			{
                if (item.collider.gameObject.layer == LayerMask.NameToLayer("Unit"))
				{
                    UnitController unitController = item.collider.GetComponent<UnitController>();

                    if (unitController)
                        return unitController;
                }
			}

            return null;
		}

        public void ResetUnitGroupSelection()
		{
            SelectedUnitSO.ResetList();
        }

        private void OnRightMouseDown()
		{
            RectStartPosition = Input.mousePosition;
        }

        private void OnRightMouse()
		{
            RectCurrentPosition = Input.mousePosition;
        }

        private void OnRightMouseUp()
		{
            Vector3 start = MainCameraController.GetScreenToViewportPoint(RectStartPosition);
            Vector3 end = MainCameraController.GetScreenToViewportPoint(RectEndPosition);

            Rect rect = new Rect(start.x, start.y, end.x - start.x, end.y - start.y);

            List<UnitController> unitControllerList = SelectedUnitSO.RaiseOnAllUnitControllerRequested();

            AddSelectedGroupOfUnits(unitControllerList, rect);
        }

        private void AddSelectedGroupOfUnits(List<UnitController> unitControllerList, Rect rect)
		{
            bool isAppend = false;
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                isAppend = true;

            if (!isAppend)
                SelectedUnitSO.ResetList();

            foreach (UnitController item in unitControllerList)
            {
                if (rect.Contains(MainCameraController.GetWorldToViewportPoint(item.transform.position), true))
                {
					if (isAppend)
					{
                        SelectedUnitSO.AddUnit(item, isAppend);
                    }
					else
					{
                        SelectedUnitSO.AddUnit(item);
                    }
                }
            }
        }

        #endregion Functions
    }
}