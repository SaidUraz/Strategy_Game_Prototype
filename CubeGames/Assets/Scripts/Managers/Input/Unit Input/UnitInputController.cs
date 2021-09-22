using UnityEngine;

namespace CubeGames.Inputs
{
    public class UnitInputController : MonoBehaviour
    {
        #region Variables

        [SerializeField] private UnitLeftClickController _unitLeftClickController;
        [SerializeField] private UnitRightClickController _unitRightClickController;

		#endregion Variables

		#region Properties

		private UnitLeftClickController UnitLeftClickController { get => _unitLeftClickController; set => _unitLeftClickController = value; }
		private UnitRightClickController UnitRightClickController { get => _unitRightClickController; set => _unitRightClickController = value; }

		#endregion Properties

		#region Functions

        public void Initialize()
		{
            UnitLeftClickController.Initialize();
            UnitRightClickController.Initialize();
        }

		public void ActivateControllerLeftClick()
        {
            UnitLeftClickController.ActivateUnitLeftClickController();
        }

        public void ActivateControllerRightClick()
        {
            UnitRightClickController.ActivateUnitRightClickController();
        }

        #endregion Functions
    }
}