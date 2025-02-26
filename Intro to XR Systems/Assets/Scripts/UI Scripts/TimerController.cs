using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [SerializeField] Image timerGraphic;
    [SerializeField] float gameTime;
    float maxGameTime;
    bool isTimerRunning = false;

    private void Awake() => maxGameTime = gameTime;

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            gameTime -= Time.deltaTime;

            var updaterTimerGraphicValue = gameTime / maxGameTime;

            timerGraphic.fillAmount = updaterTimerGraphicValue;
            if (gameTime <= 0)
            {
                isTimerRunning = false;
                gameTime = 0;
            }
        }
    }
    public void StartTimer()
    {
        gameTime = maxGameTime;
        isTimerRunning = true;
    }
}
