using UnityEngine;
using CubeGames.Data;
using CubeGames.Unit;
using CubeGames.Event;
using System.Collections.Generic;

namespace CubeGames.Inputs
{
    public class UnitRightClickController : MonoBehaviour
    {
        #region Variables

        private Vector3 _rectStartPosition;
        private Vector3 _rectEndPosition;
        private Vector3 _rectCurrentPosition;

        [SerializeField] private SelectedUnitSO _selectedUnitSO;
        [SerializeField] private RightClickGuideEventSO _rightClickGuideEventSO;
        [SerializeField] private CameraPositionConvertionEventSO _cameraPositionConvertionEventSO;

        #endregion Variables

        #region Properties

        private Vector3 RectStartPosition { get => _rectStartPosition; set => _rectStartPosition = value; }
        private Vector3 RectEndPosition { get => _rectEndPosition; set => _rectEndPosition = value; }
        private Vector3 RectCurrentPosition { get => _rectCurrentPosition; set => _rectCurrentPosition = value; }

        private SelectedUnitSO SelectedUnitSO { get => _selectedUnitSO; set => _selectedUnitSO = value; }
		private RightClickGuideEventSO RightClickGuideEventSO { get => _rightClickGuideEventSO; set => _rightClickGuideEventSO = value; }
		private CameraPositionConvertionEventSO CameraPositionConvertionEventSO { get => _cameraPositionConvertionEventSO; set => _cameraPositionConvertionEventSO = value; }

		#endregion Properties

		#region Update

		void Update()
        {
            ReadRightClickInput();
        }

        #endregion Update

        #region Functions

        public void Initialize()
        {
            enabled = false;
        }

        public void ActivateUnitRightClickController()
		{
            enabled = true;
            OnRightMouseDown();
        }

        public void DeactivateUnitLeftClickController()
		{
            enabled = false;
        }

        private void ReadRightClickInput()
        {
            if (Input.GetMouseButton(1))
            {
                OnRightMouse();
            }
            else if (Input.GetMouseButtonUp(1))
            {
                OnRightMouseUp();
            }
        }

        private void OnRightMouseDown()
        {
            RectStartPosition = Input.mousePosition;

            RightClickGuideEventSO.RaiseOnRightClickDown();
        }

        private void OnRightMouse()
        {
            RectEndPosition = Input.mousePosition;

            RightClickGuideEventSO.RaiseOnRightClickHold(RectStartPosition, RectEndPosition);
        }

        private void OnRightMouseUp()
        {
            RectEndPosition = Input.mousePosition;

            PositionData positionData = new PositionData();

            CameraPositionConvertionEventSO.RaiseOnScreenToViewportPointRequested(positionData, RectStartPosition);
            Vector3 start = positionData.Position;

            CameraPositionConvertionEventSO.RaiseOnScreenToViewportPointRequested(positionData, RectEndPosition);
            Vector3 end = positionData.Position;

            Rect rect = new Rect(start.x, start.y, end.x - start.x, end.y - start.y);

            List<UnitController> unitControllerList = SelectedUnitSO.RaiseOnAllUnitControllerRequested();

            AddSelectedGroupOfUnits(unitControllerList, rect);

            RightClickGuideEventSO.RaiseOnRightClickUp();
        }

        private void AddSelectedGroupOfUnits(List<UnitController> unitControllerList, Rect rect)
        {
            if (!GetAnyShiftButton())
                SelectedUnitSO.ResetList();

            PositionData positionData = new PositionData();
            foreach (UnitController item in unitControllerList)
            {
                CameraPositionConvertionEventSO.RaiseOnWorldToViewportPointRequested(positionData, item.transform.position);
                if (rect.Contains(positionData.Position, true))
                {
                    if (GetAnyShiftButton())
                    {
                        SelectedUnitSO.AddUnit(item, true);
                    }
                    else
                    {
                        SelectedUnitSO.AddUnit(item);
                    }
                }
            }
        }

        private bool GetAnyShiftButton()
        {
            return Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        }

        #endregion Functions
    }
}