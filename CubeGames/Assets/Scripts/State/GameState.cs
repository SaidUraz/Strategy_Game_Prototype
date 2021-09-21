using Framework.Enum;

namespace Framework.State
{
	public class GameState : BaseState
	{
		#region Events



		#endregion Events

		#region Variables



		#endregion Variables

		#region Properties



		#endregion Properties

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