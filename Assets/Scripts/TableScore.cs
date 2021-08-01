using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableScore : MonoBehaviour
{
    [SerializeField] private GameObject[] _fieldText = default;
    private Text[] _name;
    private Text[] _score;
    private string[] _firstName = new string[] { "Luis", "Marc", "Julian", "Lina", "Sofi", "Clat", "Samanta", "Kate", "Roma" };
    private string[] _secondName = new string[] { "Poston", "Tic", "Pont", "Clus", "Sabj", "Onigo", "Rrown", "Igonch", "Spots" };
    private int[] _scoreplayer;

    private void Awake()
    {
        if (_fieldText.Length > 0)
        {
            _name = new Text[_fieldText.Length];
            _score = new Text[_fieldText.Length];
            _scoreplayer = new int[_fieldText.Length];
            for (int i = 0; i < _fieldText.Length; i++)
            {
                _name[i] = _fieldText[i].transform.GetChild(0)?.GetComponent<Text>();
                _name[i].text =
                    $"{_firstName[Random.Range(0, _firstName.Length)]} {_secondName[Random.Range(0, _secondName.Length)]}";
                _score[i] = _fieldText[i].transform.GetChild(1)?.GetComponent<Text>();
                _scoreplayer[i] = Random.Range(10000, 15000) - i * 1000;
                _score[i].text = _scoreplayer[i].ToString();
            }
        }
        else
        {
            Destroy(this);
        }
    }

    public void ShowCsore(int score)
    {
        int pos = 6;
        for(int i =5; i>-1; i--)
        {       
            if (score > _scoreplayer[i])
            {
                pos--;
                Debug.Log(i);
            }
        }
        _name[pos].text = "Player";
        _name[pos].color = Color.white;
        _score[pos].text = score.ToString();
    }
}
