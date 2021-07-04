using UnityEngine;

namespace KartGame.KartSystems {

    /// <summary>
    /// Provides to the user the default inputs assigned to the actions.
    /// </summary>
    public class KeyboardInput : BaseInput
    {
        public string Horizontal = "Horizontal";
        public string Vertical = "Vertical";
        public string Respawn = "Respawn";

        protected override Vector2 GenerateRawInput() {
            return new Vector2 {
                x = Input.GetAxis(Horizontal),
                y = Input.GetAxis(Vertical)
            };
        }

        protected override bool RequestRespawnRaw()
        {
            return Input.GetButton(Respawn);
        }
    }
}
