using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class SlotMachineController : MonoBehaviour
{
    public ReelController reel1;
    public ReelController reel2;
    public ReelController reel3;

    [Header("UI")]
    public Button spinButton;
    public TextMeshProUGUI betText;
    public TextMeshProUGUI winText;

    private int betAmount = 100;

    void Start()
    {
        spinButton.onClick.AddListener(StartSpin);
        UpdateUI();
    }

    void StartSpin()
    {
        spinButton.interactable = false;

        int[] result = GenerateResult();

        reel1.StartSpin();
        reel2.StartSpin();
        reel3.StartSpin();

        StartCoroutine(StopRoutine(result));
    }

    int[] GenerateResult()
    {
        int[] result = new int[3];

        float chance = Random.value;

        if (chance < 0.1f)
        {
            int symbol = Random.Range(0, 4);
            result[0] = result[1] = result[2] = symbol;
        }
        else if (chance < 0.2f)
        {
            int symbol = Random.Range(0, 4);

            result[0] = symbol;
            result[1] = symbol;
            result[2] = RandomDifferent(symbol);
        }
        else
        {
            result[0] = Random.Range(0, 4);
            result[1] = RandomDifferent(result[0]);
            result[2] = RandomDifferent(result[1]);
        }

        return result;
    }

    int RandomDifferent(int exclude)
    {
        int value;
        do
        {
            value = Random.Range(0, 4);
        } while (value == exclude);

        return value;
    }

    IEnumerator StopRoutine(int[] result)
    {
        yield return new WaitForSeconds(1.5f);
        reel1.StopSpinOnSymbol(result[0]);

        yield return new WaitForSeconds(0.5f);
        reel2.StopSpinOnSymbol(result[1]);

        yield return new WaitForSeconds(0.5f);
        reel3.StopSpinOnSymbol(result[2]);

        CalculateWin(result);

        spinButton.interactable = true;
    }

    void CalculateWin(int[] result)
    {
        int winAmount = 0;

        if (result[0] == result[1] && result[1] == result[2])
        {
            winAmount = betAmount * 5; // jackpot
        }
        else if (result[0] == result[1] || result[1] == result[2])
        {
            winAmount = betAmount * 2; // small win
        }
        else
        {
            winAmount = 0;
        }

        winText.text = "Win: " + winAmount;
    }

    void UpdateUI()
    {
        betText.text = "Bet: " + betAmount;
        winText.text = "Win: 0";
    }
}