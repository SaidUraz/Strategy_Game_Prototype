using TMPro;
using UnityEngine;
using CubeGames.Data;
using UnityEngine.UI;
using CubeGames.Event;

namespace Framework.UI
{
    public class UIHudController : MonoBehaviour
    {
		#region Variables

		[SerializeField] private UIUnitEventSO _uIUnitEventSO;
		[SerializeField] private SelectedUnitSO _selectedUnitSO;
		[SerializeField] private UnitTargetEventSO _unitTargetEventSO;

		[SerializeField] private TMP_InputField _unitSpeedInputField;
		[SerializeField] private TMP_InputField _unitStoppingDistanceInputField;

		[SerializeField] private TextMeshProUGUI _selectedUnitCountText;

		[SerializeField] private Button _selectAllUnitsButton;
		[SerializeField] private Button _removeAllTargetsButton;

		#region Properties

		#endregion Properties

		private UIUnitEventSO UIUnitEventSO { get => _uIUnitEventSO; set => _uIUnitEventSO = value; }
		private SelectedUnitSO SelectedUnitSO { get => _selectedUnitSO; set => _selectedUnitSO = value; }
		private UnitTargetEventSO UnitTargetEventSO { get => _unitTargetEventSO; set => _unitTargetEventSO = value; }
		
		private TMP_InputField UnitSpeedInputField { get => _unitSpeedInputField; set => _unitSpeedInputField = value; }
		private TMP_InputField UnitStoppingDistanceInputField { get => _unitStoppingDistanceInputField; set => _unitStoppingDistanceInputField = value; }
		
		private TextMeshProUGUI SelectedUnitCountText { get => _selectedUnitCountText; set => _selectedUnitCountText = value; }
		
		private Button SelectAllUnitsButton { get => _selectAllUnitsButton; set => _selectAllUnitsButton = value; }
		private Button RemoveAllTargetsButton { get => _removeAllTargetsButton; set => _removeAllTargetsButton = value; }

		#endregion Variables

		#region Functions

		public void Initialize()
        {
			UnitSpeedInputField.onValueChanged.AddListener(delegate { OnUnitSpeedInputFieldOnEndEdit(); });
			UnitStoppingDistanceInputField.onValueChanged.AddListener(delegate { OnUnitStoppingDistanceInputFieldOnEndEdit(); });

			SelectAllUnitsButton.onClick.AddListener(delegate { OnSelectAllUnitsButtonClick(); });
			RemoveAllTargetsButton.onClick.AddListener(delegate { OnRemoveAllTargetsButtonClick(); });
		}

		public void SubscribeEvents()
		{
			SelectedUnitSO.OnSelectedCountUpdated += UpdateSelectedUnitCount;
		}

		private void UnSubscribeEvents()
		{
			SelectedUnitSO.OnSelectedCountUpdated -= UpdateSelectedUnitCount;
		}

		private void OnUnitSpeedInputFieldOnEndEdit()
		{
			if (UnitSpeedInputField.text != "")
			{
				float unitSpeed = float.Parse(UnitSpeedInputField.text);
				UIUnitEventSO.RaiseOnUnitSpeedUpdated(unitSpeed);
			}
		}

		private void OnUnitStoppingDistanceInputFieldOnEndEdit()
		{
			if (UnitStoppingDistanceInputField.text != "")
			{
				float unitStoppingDistance = float.Parse(UnitStoppingDistanceInputField.text);
				UIUnitEventSO.RaiseOnUnitStoppingDistanceUpdated(unitStoppingDistance);
			}
		}

		private void UpdateSelectedUnitCount(int selectedUnitCount)
		{
			SelectedUnitCountText.text = selectedUnitCount.ToString();
		}

		private void OnSelectAllUnitsButtonClick()
		{
			SelectedUnitSO.AddAllUnitsToList();
		}

		private void OnRemoveAllTargetsButtonClick()
		{
			UnitTargetEventSO.RaiseOnRemoveUnitTarget();
		}

		#endregion Functions
	}
}