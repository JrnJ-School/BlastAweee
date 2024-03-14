using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    private View _currentView;

    public View CurrentView
    {
        get { return _currentView; }
        set
        {
            ViewHistory.Add(value);
            _currentView = value;
        }
    }

    private List<View> ViewHistory { get; set; } = new();

    public void SwitchView(View view)
    {
        LoadView(view);
    }

    public void LoadPreviousView()
    {
        if (ViewHistory.Count < 2) return;

        LoadView(ViewHistory[^2]);
        ViewHistory.RemoveRange(ViewHistory.Count - 3, 2);
    }

    private void LoadView(View view)
    {
        // Nullcheck
        if (view == null) return;

        // Hide Current
        if (CurrentView != null)
        {
            CurrentView.OnExit();
            CurrentView.Hide();
        }

        // Show new
        CurrentView = view;
        CurrentView.Show();
        CurrentView.OnEnter();
    }
}
