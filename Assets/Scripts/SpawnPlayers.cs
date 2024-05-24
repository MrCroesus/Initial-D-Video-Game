using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Drift Track":
                PhotonNetwork.Instantiate(car.name, new Vector3(250, 2, 250), Quaternion.identity);
                break;
            case "Sprint Track":
                PhotonNetwork.Instantiate(car.name, new Vector3(960, 222, 920), Quaternion.identity);
                break;
            case "Custom Track":
                PhotonNetwork.Instantiate(car.name, new Vector3(960, 22, 920), Quaternion.identity);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
