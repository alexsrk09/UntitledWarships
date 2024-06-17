using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // public static keycode to change camera, default, f
    public static KeyCode changeCamera = KeyCode.F;
    // public static keycode to open the menu, default, escape
    public static KeyCode openMenu = KeyCode.Escape;
    // public static keycode to go up in the state, default, w
    public static KeyCode upState = KeyCode.W;
    // public static keycode to go down in the state, default, s
    public static KeyCode downState = KeyCode.S;
    // public static keycode to rotate left, default, a
    public static KeyCode rotateLeft = KeyCode.A;
    // public static keycode to rotate right, default, d
    public static KeyCode rotateRight = KeyCode.D;
    // public static keycode to aim, default, mouse1
    public static KeyCode aim = KeyCode.Mouse1;
}
