using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class SlotMachineController : MonoBehaviour
{
    public ReelController reel1;
    public ReelController reel2;
    public ReelController reel3;

    private PlayerControls controls;

    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Spin.performed += ctx => StartSpin();
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
        StopAllCoroutines();

        reel1.StartSpin();
        reel2.StartSpin();
        reel3.StartSpin();

        StartCoroutine(StopReelsRoutine());
    }

    IEnumerator StopReelsRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        reel1.StopSpin();

        yield return new WaitForSeconds(0.5f);
        reel2.StopSpin();

        yield return new WaitForSeconds(0.5f);
        reel3.StopSpin();
    }
}