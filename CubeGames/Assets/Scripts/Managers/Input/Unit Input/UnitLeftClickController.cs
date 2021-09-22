using UnityEngine;
using CubeGames.Unit;
using CubeGames.Data;
using CubeGames.Event;

namespace CubeGames.Inputs
{
    public class UnitLeftClickController : MonoBehaviour
    {
        #region Variables

        private RayData _rayData;

        [SerializeField] private SelectedUnitSO _selectedUnitSO;
        [SerializeField] private CameraRayEventSO _cameraRayEventSO;

        #endregion Variables

        #region Properties

        private RayData RayData { get => _rayData; set => _rayData = value; }

        private SelectedUnitSO SelectedUnitSO { get => _selectedUnitSO; set => _selectedUnitSO = value; }
        private CameraRayEventSO CameraRayEventSO { get => _cameraRayEventSO; set => _cameraRayEventSO = value; }


        #endregion Properties

        #region Update

        void Update()
        {
            ReadLeftClickInput();
        }

        #endregion Update

        #region Functions

        public void Initialize()
        {
            RayData = new RayData();
            enabled = false;
        }

        public void ActivateUnitLeftClickController()
        {
            enabled = true;
        }

        public void DeactivateUnitLeftClickController()
        {
            enabled = false;
        }

        public void ResetUnitGroupSelection()
        {
            SelectedUnitSO.ResetList();
        }

        private void ReadLeftClickInput()
        {
            if (Input.GetMouseButtonUp(0))
            {
                UnitController unitController = DetectAndGetUnitController();

                if (unitController)
                {
                    if (GetAnyShiftButton())
                    {
                        SelectedUnitSO.AddUnit(unitController, true);
                    }
                    else
                    {
                        SelectedUnitSO.AddUnit(unitController, false);
                    }
                }

                DeactivateUnitLeftClickController();
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

        private bool GetAnyShiftButton()
		{
            return Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        }

        #endregion Functions
    }
}