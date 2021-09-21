using UnityEngine;
using CubeGames.Unit;
using CubeGames.Target;
using System.Collections.Generic;

namespace CubeGames.Data
{
    [CreateAssetMenu]
    public class SelectedUnitSO : ScriptableObject
    {
        #region Events

        public delegate void SelectedCountUpdated(int selectedUnitCount);
        public event SelectedCountUpdated OnSelectedCountUpdated;

        public delegate List<UnitController> AllUnitControllerRequest();
        public event AllUnitControllerRequest OnAllUnitControllerRequest;

        #endregion Events

        #region Variables

        [SerializeField] private Material _defaultUnitBlue;
        [SerializeField] private Material _selectedUnitGreen;

        private HashSet<UnitController> _unitControllerList = new HashSet<UnitController>();

		#endregion Variables

		#region Properties

		private Material DefaultUnitBlue { get => _defaultUnitBlue; set => _defaultUnitBlue = value; }
        private Material SelectedUnitGreen { get => _selectedUnitGreen; set => _selectedUnitGreen = value; }
		
        public HashSet<UnitController> UnitControllerList { get => _unitControllerList; set => _unitControllerList = value; }

		#endregion Properties

		#region Functions

        private void RaiseOnSelectedCountUpdated(int selectedUnitCount)
		{
            OnSelectedCountUpdated?.Invoke(selectedUnitCount);
        }

        public void AddUnit(UnitController unitController)
        {
            UnitControllerList.Add(unitController);
            ChangeUnitColor(unitController, SelectedUnitGreen);

            RaiseOnSelectedCountUpdated(UnitControllerList.Count);
        }

        /// <summary>
        /// If true: adds unitController without resetting the list.
        /// </summary>
        /// <param name="isAppend"></param>
        public void AddUnit(UnitController unitController, bool isAppend)
		{
            if (!isAppend)
			{
                ResetList();
            }

            UnitControllerList.Add(unitController);
            ChangeUnitColor(unitController, SelectedUnitGreen);

            RaiseOnSelectedCountUpdated(UnitControllerList.Count);
        }

        public List<UnitController> RaiseOnAllUnitControllerRequested()
		{
            List<UnitController> unitControllerList = OnAllUnitControllerRequest?.Invoke();
            return unitControllerList;
        }

        public void AddAllUnitsToList()
		{
            List<UnitController> unitControllerList = RaiseOnAllUnitControllerRequested();

            foreach (UnitController unitController in unitControllerList)
			{
                AddUnit(unitController, true);
			}
        }

        public void ResetList()
		{
			foreach (UnitController item in UnitControllerList)
			{
                ChangeUnitColor(item, DefaultUnitBlue);
            }

            UnitControllerList.Clear();
            RaiseOnSelectedCountUpdated(UnitControllerList.Count);
        }

        private void ChangeUnitColor(UnitController unitController, Material material)
		{
            if (unitController)
                unitController.SetColorOfMeshRenderer(material);
        }

        public void SendSelectedUnitsToTarget(TargetController targetController)
		{
			foreach (UnitController unitController in UnitControllerList)
			{
                unitController.SetTarget(targetController);
            }
		}

        #endregion Functions
    }
}