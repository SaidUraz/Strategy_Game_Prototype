using UnityEngine;
using Framework.Enum;
using Framework.State;

namespace Framework.Manager
{
    public class StateManager
    {
        #region Events


        #endregion Events

        #region Variables

        private BaseState _currentState;
        private MenuState _menuState;
        private GameState _gameState;

		#endregion Variables

		#region Properties

		public BaseState CurrentState { get => _currentState; }
		public MenuState MenuState { get => _menuState; }
		public GameState GameState { get => _gameState; }

		#endregion Properties

		#region Functions

		public void Initialize()
        {

        }

        public void SubscribeEvents()
        {

        }

        public void UnSubscribeEvents()
        {

        }

        public void ChangeState(StateType stateType)
		{
            if (_currentState?.StateType == stateType)
			{
                Debug.Log("Already in " + CurrentState);
                return;
            }

            _currentState?.Terminate();

			switch (stateType)
			{
				case StateType.Menu:
                    _currentState = MenuState;
					break;
				case StateType.Game:
                    _currentState = GameState;
					break;
				default:
                    _currentState = null;
                    break;
			}

            _currentState?.Initialize();
		}

        #endregion Functions
    }
}