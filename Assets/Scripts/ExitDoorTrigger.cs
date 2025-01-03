using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class ExitDoorTrigger : MonoBehaviour
{
    public GameObject WinUI;
    public TextMeshProUGUI LevelText;
    public void OnTriggerEnter(Collider other)
    {
        this.GetComponent<BoxCollider>().enabled = false; // Biar player ga keluar > 1

        FindObjectOfType<FirstPersonController>().enabled = false; // Biar player ga bisa gerak

        Cursor.visible = true; // Biar cursor muncul
        Cursor.lockState = CursorLockMode.None; // Biar cursor bisa digerakin

        WinUI.SetActive(true); // Munculin UI Win
        StartCoroutine(DisableEscapeKey());
    }

    private void Update()
    {
        LevelText.text = SceneManager.GetActiveScene().name; // Update level text
    }

    IEnumerator DisableEscapeKey()
        {
            // Mencegah fungsi Escape selama Game Over
            while (WinUI.activeSelf)
            {
                GameObject pauseGameManagerCanvas = GameObject.Find("Pause Game Manager");
                if (pauseGameManagerCanvas != null)
                {
                    pauseGameManagerCanvas.SetActive(false);
                }

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    // Jangan lakukan apa-apa jika tombol 'Esc' ditekan
                    yield return null;
                }
                yield return null;
            }
        }
}
