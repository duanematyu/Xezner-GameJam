using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject[] _tutorial;

    private int _tutorialIndex;

    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private GameObject previous;
    [SerializeField] private GameObject next;

    public bool IsTutorialClosed;

    private void Update()
    {
        if (_tutorialIndex == 0)
        {
            previous.SetActive(false);
            next.SetActive(true);
        }

        else if(_tutorialIndex == 5)
        {
            previous.SetActive(true);
            next.SetActive(false);
        }
    }

    public void NextPage()
    {
        previous.SetActive(true);

        _tutorial[_tutorialIndex].SetActive(false);
        _tutorialIndex += 1;
        _tutorial[_tutorialIndex].SetActive(true);
    }

    public void PreviousPage()
    {
        _tutorial[_tutorialIndex].SetActive(false);
        _tutorialIndex -= 1;
        _tutorial[_tutorialIndex].SetActive(true);
    }

    public void ExitTutorial()
    {
        IsTutorialClosed = true;
        _tutorial[_tutorialIndex].SetActive(false);
        _tutorialIndex = 0;
        _tutorial[_tutorialIndex].SetActive(true);
        tutorialPanel.SetActive(false);

        if (GameManager.Instance.TimesPlayed == 0)
        {
            GameManager.Instance.TimesPlayed++;
        }
    }
}
