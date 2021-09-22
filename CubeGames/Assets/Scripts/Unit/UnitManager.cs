using UnityEngine;
using CubeGames.Data;
using CubeGames.Target;
using System.Collections.Generic;

namespace CubeGames.Unit
{
    public class UnitManager : MonoBehaviour
    {
        #region Variables

        [SerializeField] private List<UnitController> _unitControllerList;

        [SerializeField] private SelectedUnitSO _selectedUnitSO;
        [SerializeField] private UnitTargetEventSO _unitTargetEventSO;

        #endregion Variables

        #region Properties

        private List<UnitController> UnitControllerList { get => _unitControllerList; set => _unitControllerList = value; }
		
		private SelectedUnitSO SelectedUnitSO { get => _selectedUnitSO; set => _selectedUnitSO = value; }
        private UnitTargetEventSO UnitTargetEventSO { get => _unitTargetEventSO; set => _unitTargetEventSO = value; }

		#endregion Properties

		#region Awake

        void Awake()
        {
            SubscribeEvents();
            Initialize();
        }

        #endregion Awake

        #region Functions

        public void Initialize()
        {
            GetAllUnitControllers();
        }

        public void SubscribeEvents()
        {
            UnitTargetEventSO.OnUnitSentToTarget += SendSelectedUnitsToTarget;
            SelectedUnitSO.OnAllUnitControllerRequest += OnAllUnitControllerListRequested;
        }

        public void UnSubscribeEvents()
        {
            UnitTargetEventSO.OnUnitSentToTarget -= SendSelectedUnitsToTarget;
            SelectedUnitSO.OnAllUnitControllerRequest -= OnAllUnitControllerListRequested;
        }

        private void GetAllUnitControllers()
        {
            UnitController unitController;

            foreach (Transform unitTransform in transform)
            {
                unitController = null;
                unitController = unitTransform.GetComponent<UnitController>();

                if (unitController)
                {
                    UnitControllerList.Add(unitController);
                }
            }
        }

        private void SendSelectedUnitsToTarget(TargetController targetController)
		{
            SelectedUnitSO.SendSelectedUnitsToTarget(targetController);
        }

        private List<UnitController> OnAllUnitControllerListRequested()
		{
            return UnitControllerList;
		}

        #endregion Functions
    }
}