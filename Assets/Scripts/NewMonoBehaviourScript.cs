using UnityEngine;
using UnityEngine.InputSystem;

public class TestSpin : MonoBehaviour
{
    public ReelController reel;

    private PlayerControls controls;

    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Spin.performed += ctx => StartSpin();
        controls.Gameplay.Stop.performed += ctx => StopSpin();
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    void StartSpin()
    {
        reel.StartSpin();
    }

    void StopSpin()
    {
        reel.StopSpin();
    }
}