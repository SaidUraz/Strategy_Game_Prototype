using UnityEngine;
using Framework.Enum;

namespace Framework.Manager
{
    public class GameManager : MonoBehaviour
    {
        #region Variables

        private StateManager _stateManager;

		#endregion Variables

		#region Properties

		private StateManager StateManager { get => _stateManager; }

		#endregion Properties

		#region Awake - Start - Update - FixedUpdate

		void Awake()
        {
            Initialize();
        }

        #endregion Awake - Start - Update - FixedUpdate

        #region Functions

        public void Initialize()
        {
            _stateManager = new StateManager();
            _stateManager.ChangeState(StateType.Menu);
        }

        #endregion Functions
    }
}