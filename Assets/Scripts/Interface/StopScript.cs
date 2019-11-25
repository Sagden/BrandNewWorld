using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StopScript : MonoBehaviour
{
    public bool _banOnStopClick = false;
    private Animation anim;
    public Button stopButton;

    void Start()
    {
        stopButton = transform.GetComponent<Button>();
        anim = GetComponent<Animation>();

        stopButton.onClick.AddListener(ClickOnButton);
        AllEventList.Instance.bluePlayerOnFinishFloor.AddListener(BanOnStopClick);
    }


    void ClickOnButton()
    {
        if (!_banOnStopClick)
        {
            Destroy(AllObjectList.Instance.bluePlayerObj);
            Destroy(AllObjectList.Instance.redPlayerObj);
            Destroy(GameObject.Find("PlayerParent(Clone)"));
            Destroy(GameObject.Find("PlayerParent(Clone)"));


            AllEventList.Instance.stopButtonClick.Invoke();

            

            try
            {
                AllObjectList.Instance.buttonPlayBlue.GetComponent<PlayPauseBlue>().WalkingPaused();
                AllObjectList.Instance.buttonPlayRed.GetComponent<PlayPauseRed>().WalkingPaused();
            }
            catch
            {
                Debug.Log("Error");
            }
        }
    }

    void BanOnStopClick()
    {
        _banOnStopClick = true;
    }

    public void Shake()
    {
        anim.Play();
    }
}
