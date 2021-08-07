using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    [SerializeField] private GameObject car1 = default;
    [SerializeField] private GameObject car2 = default;
    [SerializeField] private GameObject play = default;
    [SerializeField] private ChoisCar choisCar = default;
    public void ChoisPerson(GameObject car)
    {
        if (car == car1)
        {
           car1.transform.DOScale(1.3f, 0.5f); 
           car2.transform.DOScale(1.0f, 0.5f);
           choisCar.nuberCar = 0;
        }
        else
        {
           car2.transform.DOScale(1.3f, 0.5f); 
           car1.transform.DOScale(1.0f, 0.5f);
           choisCar.nuberCar = 1;
        }
        play.SetActive(true);
    }
    public void LoadSceneMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void MainGame()
    {
        SceneManager.LoadScene(2);
    }
}
