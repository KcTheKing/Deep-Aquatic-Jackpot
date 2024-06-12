using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour
{
    private async void Awake()
    {
        await Task.Delay(2000);
        SceneManager.LoadScene("apuatic");
    }
}
