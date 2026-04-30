using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using System.Collections.Generic;

public class SlotMachineController : MonoBehaviour
{
    public ReelController reel1;
    public ReelController reel2;
    public ReelController reel3;

    [Header("UI")]
    public Button spinButton;
    public List<UILight> lights;
    public Image handalicon;
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
        spinButton.gameObject.SetActive(false);
        handalicon.gameObject.SetActive(true);

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

        if (chance < 0.2f)
        {
            int symbol = Random.Range(0, 4);
            result[0] = result[1] = result[2] = symbol;
        }
        else if (chance < 0.5f)
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
        yield return StartCoroutine(WaitWithLight(1.5f));
        reel1.StopSpinOnSymbol(result[0]);

        yield return StartCoroutine(WaitWithLight(0.5f));
        reel2.StopSpinOnSymbol(result[1]);

        yield return StartCoroutine(WaitWithLight(0.5f));
        reel3.StopSpinOnSymbol(result[2]);

        CalculateWin(result);

        handalicon.gameObject.SetActive(false);
        spinButton.gameObject.SetActive(true);
    }

    IEnumerator WaitWithLight(float duration)
    {
        float elapsed = 0f;
        float toggleInterval = 0.2f; // how often to switch between on/off
        float nextToggle = 0f;
        bool isOn = false;

        while (elapsed < duration)
        {
            if (elapsed >= nextToggle)
            {
                isOn = !isOn;
                if (isOn)
                {
                    for(int i = 0; i < lights.Count; i++)
                    {
                        lights[i].SetOn();
                    }
                }
                else
                {
                    for (int i = 0; i < lights.Count; i++)
                    {
                        lights[i].SetBlink();
                    }
                }
                nextToggle += toggleInterval;
            }

            elapsed += Time.deltaTime;
            yield return null;
        }
    }

    int winAmount = 0;

    void CalculateWin(int[] result)
    {

        if (result[0] == result[1] && result[1] == result[2])
        {
            winAmount = winAmount + (betAmount * 5); // jackpot
            for (int i = 0; i < lights.Count; i++)
            {
                lights[i].SetWin();
            }
        }
        else if (result[0] == result[1] || result[1] == result[2])
        {
            winAmount = winAmount + (betAmount * 2); // small win
            for (int i = 0; i < lights.Count; i++)
            {
                lights[i].SetWin();
            }
        }
        else
        {
            for (int i = 0; i < lights.Count; i++)
            {
                lights[i].SetLose();
            }
        }

        winText.text = "Win: " + winAmount;
    }

    void UpdateUI()
    {
        betText.text = "Bet: " + betAmount;
        winText.text = "Win: 0";
    }

    public void Bet(int amount)
    {
        betAmount = amount;
        betText.text = "Bet: " + betAmount;
    }
}