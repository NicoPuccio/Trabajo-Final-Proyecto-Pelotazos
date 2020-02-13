using System;

public class PlayerInput
{
    public string horizontalInput { get; private set; }
    public string verticalInput { get; private set; }
    public string jumpInput { get; private set; }
    public string rollInput { get; private set; }

    //public static PlayerInput GetControllerForPlayer(PlayerNumber number)
    //{
    //    PlayerInput input = new PlayerInput();
    //    int unityInputNumber = (int)number;
    //
    //    input.horizontalInput = String.Format("P{0}Horizontal", unityInputNumber);
    //    input.verticalInput = String.Format("P{0}Vertical", unityInputNumber);
    //    input.jumpInput = String.Format("P{0}Jump", unityInputNumber);
    //    input.rollInput = String.Format("P{0}Roll", unityInputNumber);
    //
    //    return input;
    //}
}
