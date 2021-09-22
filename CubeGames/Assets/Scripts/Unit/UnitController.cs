using UnityEngine;
using UnityEngine.AI;
using CubeGames.Data;
using CubeGames.Event;
using CubeGames.Target;

namespace CubeGames.Unit
{
    public class UnitController : MonoBehaviour
    {
        #region Variables

        private float _unitSpeed;
        private float _unitStoppingDistance;

        private MeshRenderer _meshRenderer;
        private NavMeshAgent _navMeshAgent;

        private TargetController _targetController;

        [SerializeField] private UIUnitEventSO _uIUnitEventSO;
        [SerializeField] private UnitTargetEventSO _unitTargetEventSO;
        [SerializeField] private UnitTargetPositionChangeEventSO _unitTargetPositionChangeEventSO;

        #endregion Variables

        #region Properties
		
        // Used these properties as a function to set NavMesh variables in case of these variables set manually inside the script.
        private float UnitSpeed 
        { 
            get => _unitSpeed;
            set
            {
                _unitSpeed = value;
                
                if (_navMeshAgent)
                    _navMeshAgent.speed = _unitSpeed;
            }
        }
 
		private float UnitStoppingDistance 
        { 
            get => _unitStoppingDistance; 
            set
			{
                _unitStoppingDistance = value;

				if (_navMeshAgent)
					_navMeshAgent.stoppingDistance = _unitStoppingDistance;
			}
        }

        private MeshRenderer MeshRenderer { get => _meshRenderer; set => _meshRenderer = value; }
        private NavMeshAgent NavMeshAgent { get => _navMeshAgent; set => _navMeshAgent = value; }
		
		private TargetController TargetController { get => _targetController; set => _targetController = value; }
        
		private UIUnitEventSO UIUnitEventSO { get => _uIUnitEventSO; set => _uIUnitEventSO = value; }
		private UnitTargetEventSO UnitTargetEventSO { get => _unitTargetEventSO; set => _unitTargetEventSO = value; }
        private UnitTargetPositionChangeEventSO UnitTargetPositionChangeEventSO { get => _unitTargetPositionChangeEventSO; set => _unitTargetPositionChangeEventSO = value; }

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
            MeshRenderer = GetComponentInChildren<MeshRenderer>();
            NavMeshAgent = GetComponent<NavMeshAgent>();

            enabled = false;
        }

        public void SubscribeEvents()
        {
            UIUnitEventSO.OnUnitSpeedUpdated += UpdateUnitSpeed;
            UnitTargetEventSO.OnRemoveAllUnitTarget += RemoveUnitTarget;
            UIUnitEventSO.OnUnitStoppingDistanceUpdated += UpdateUnitStoppingDistance;
            UnitTargetPositionChangeEventSO.OnTargetPositionUpdated += UpdateTargetPosition;
        }

        public void UnSubscribeEvents()
        {
            UIUnitEventSO.OnUnitSpeedUpdated -= UpdateUnitSpeed;
            UnitTargetEventSO.OnRemoveAllUnitTarget -= RemoveUnitTarget;
            UIUnitEventSO.OnUnitStoppingDistanceUpdated -= UpdateUnitStoppingDistance;
            UnitTargetPositionChangeEventSO.OnTargetPositionUpdated -= UpdateTargetPosition;
        }

        private void UpdateTargetPosition(TargetController targetController)
		{
            if (TargetController && TargetController == targetController)
			{
                NavMeshAgent.destination = TargetController.gameObject.transform.position;
                enabled = true;
            }
        }

        public void SetColorOfMeshRenderer(Material material)
		{
            MeshRenderer.material = material;
		}

        public void SetTarget(TargetController targetController)
		{
            TargetController = targetController;
            UpdateTargetPosition(targetController);
        }

        private void UpdateUnitSpeed(float unitSpeed)
		{
            UnitSpeed = unitSpeed;
		}

        private void UpdateUnitStoppingDistance(float unitStoppingDistance)
        {
            UnitStoppingDistance = unitStoppingDistance;
        }

        private void RemoveUnitTarget()
		{
            TargetController = null;
            NavMeshAgent.ResetPath();
		}

        #endregion Functions
    }
}