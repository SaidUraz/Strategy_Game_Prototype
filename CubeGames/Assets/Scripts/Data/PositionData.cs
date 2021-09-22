using UnityEngine;

namespace CubeGames.Data
{
    public class PositionData
    {
        #region Variables

        private Vector3 _position;

		#endregion Variables

		#region Properties

		public Vector3 Position { get => _position; set => _position = value; }

		#endregion Properties
	}
}