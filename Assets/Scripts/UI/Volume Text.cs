
//using UnityEngine;
//using UnityEngine.UI;

//public class VolumeText : MonoBehaviour
//{
//    [SerializeField] private string volumeName;
//    [SerializeField] private string textIntro; //Sound:  or Music:
//    private Text txt;

//    private void Awake()
//    {
//        txt = GetComponent<Text>();
//    }
//    private void Update()
//    {
//        UpdateVolume();
//    }
//    private void UpdateVolume()
//    {
//        float volumeValue = PlayerPrefs.GetFloat(volumeName) * 100;
//        string v = textIntro + volumeValue.ToString();
//        txt.text = v;
//    }
//}

using UnityEngine;
using UnityEngine.UI;

public class VolumeText : MonoBehaviour
{
    [SerializeField] private string volumeName;
    [SerializeField] private string textIntro; //Sound:  or Music:
    private Text txt;

    private void Awake()
    {
        txt = GetComponent<Text>();

        if (txt == null)
        {
            Debug.LogError("Text component not found! Make sure the GameObject has a Text component attached.");
        }
    }

    private void Update()
    {
        if (txt != null)
        {
            UpdateVolume();
        }
    }

    private void UpdateVolume()
    {
        float volumeValue = PlayerPrefs.GetFloat(volumeName) * 100;
        string v = textIntro + volumeValue.ToString();
        txt.text = v;
    }
}
