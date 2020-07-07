using UnityEngine;

public class ApplicationUI : MonoBehaviour
{
    public void GoBack()
    {
        Debug.Log("it will send you back");
    }

    public void CloseMe()
    {
        Application.Quit();
    }
}
