using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RunController : MonoBehaviour {

    public GameObject PingoutText;
    public GameObject OverlayCanvas;
    public GameObject CompletePanel;
    public GameObject TimerText;

    public enum RunStatus
    {
        Countdown,
        Running,
        Paused,
        Finished
    }

    public double RunTime { get; private set; }
    public RunStatus Status { get; private set; }
    public List<GameObject> Objectives { get; private set; }

    public bool EnableControls
    {
        get
        {
            switch (Status)
            {
                case RunStatus.Running:
                    return true;

                default:
                    return false;
            }
        }
    }

    void Start() {
        OverlayCanvas.GetComponentInChildren<UnityEngine.UI.Image>().enabled = true;
        StartCoroutine(Countdown());
        Objectives = new List<GameObject>(GameObject.FindGameObjectsWithTag("Pickup"));
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Prototype");
    }
    public void BackToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    private void PingText(string txt)
    {
        var newText = Instantiate(PingoutText);
        newText.GetComponent<UnityEngine.UI.Text>().text = txt;
        newText.transform.SetParent(OverlayCanvas.transform, false);
    }

    private IEnumerator Countdown()
    {
        Status = RunStatus.Countdown;
        PingText("3");
        OverlayCanvas.GetComponentInChildren<UnityEngine.UI.Image>().CrossFadeColor(new Color(0, 0, 0, 0), 3f, false, true);
        yield return new WaitForSeconds(1f);
        PingText("2");
        yield return new WaitForSeconds(1f);
        PingText("1");
        yield return new WaitForSeconds(1f);
        PingText("Go!");
        Status = RunStatus.Running;
        RunTime = 0.0;
        while (Objectives.Count > 0)
        {
            foreach (var obj in Objectives.ToArray())
            {
                if (!obj) Objectives.Remove(obj);
            }
            RunTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Status = RunStatus.Finished;

        CompletePanel.SetActive(true);
        CompletePanel.GetComponentInChildren<UnityEngine.UI.Text>().text = "COMPLETE!\n" + GetRunTimeString();
    }

    private void Update()
    {
        TimerText.GetComponent<UnityEngine.UI.Text>().text = GetRunTimeString();
    }

	private string GetRunTimeString() {
        System.TimeSpan ts = System.TimeSpan.FromSeconds(RunTime);
        return string.Format("{0:00}:{1:00.000}",
            ts.Minutes, ts.Seconds + (ts.Milliseconds / 1000.0));
	}
}
