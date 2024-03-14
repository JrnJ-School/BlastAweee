using UnityEngine;

public class View : MonoBehaviour
{
    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public virtual void OnEnter()
    {

    }

    public virtual void OnExit()
    {

    }
}
