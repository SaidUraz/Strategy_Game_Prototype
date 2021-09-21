using Framework.Enum;

namespace Framework.State
{
	public class GameState : BaseState
	{
		#region Functions

		public GameState(StateType stateType)
		{
			StateType = stateType;
		}

		public override void Initialize()
		{
			base.Initialize();
		}

		public override void Terminate()
		{
			base.Terminate();
		}

		#endregion Functions
	}
}