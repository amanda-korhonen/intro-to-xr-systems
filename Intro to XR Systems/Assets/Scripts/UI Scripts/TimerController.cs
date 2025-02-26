using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [SerializeField] Image timerGraphic;
    [SerializeField] float gameTime;
    public GameObject timerUI;
    float maxGameTime;
    bool isTimerRunning = true;

    private void Awake() => maxGameTime = gameTime;

    // Update is called once per frame
    void Update()
    {
        if (!isTimerRunning)
        {
            return;
        }
        UpdateTimer();
        CheckTimer();
    }

    private void UpdateTimer()
    {
        gameTime -= Time.deltaTime;

        var updaterTimerGraphicValue = gameTime / maxGameTime;

        timerGraphic.fillAmount = updaterTimerGraphicValue;

    }
    private void CheckTimer()
    {
        if (timerGraphic.fillAmount <= 0)
        {
            //GameOver.GameOverAction();
            isTimerRunning = false;
            gameTime = maxGameTime;
        }
    }

    public void StartTimer()
    {
        timerUI.SetActive(!timerUI.activeSelf);

        if (timerUI.activeSelf)
        {
            gameTime = maxGameTime;
            isTimerRunning = true;
        }
    }

}
