using Framework.Enum;

namespace Framework.State
{
	public class BaseState
	{
		#region Delegates - Events

		public delegate void DelegateInitialize();
		public event DelegateInitialize OnInitialize;

		public delegate void DelegateTerminate();
		public event DelegateTerminate OnTerminate;

		#endregion Delegates - Events

		#region Variables

		private StateType _stateType;

		#endregion Variables

		#region Properties

		public StateType StateType { get => _stateType; set => _stateType = value; }

		#endregion Properties

		#region Functions

		public virtual void Initialize() 
		{
			OnInitialize?.Invoke();
		}
		public virtual void Terminate() 
		{
			OnTerminate?.Invoke();
		}

		#endregion Functions
	}
}