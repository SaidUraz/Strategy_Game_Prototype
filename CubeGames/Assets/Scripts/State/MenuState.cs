using Framework.Enum;

namespace Framework.State
{
	public class MenuState : BaseState
	{
		#region Functions

		public MenuState(StateType stateType)
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