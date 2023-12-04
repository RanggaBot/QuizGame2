using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Diperlukan untuk mengelola transisi ke layar game over

public class PengolahWaktu : MonoBehaviour
{
    public float waktuAwal = 60.0f; // Waktu awal dalam detik
    public Text textWaktu; // Teks untuk menampilkan waktu

    private float waktuSisa; // Menyimpan waktu yang tersisa
    private bool isGameOver = false; // Flag untuk menunjukkan apakah game over

    void Start()
    {
        waktuSisa = waktuAwal;
    }

    void Update()
    {
        if (!isGameOver)
        {
            waktuSisa -= Time.deltaTime; // Mengurangkan waktu dengan waktu delta

            // Memastikan waktu tidak kurang dari 0
            if (waktuSisa <= 0)
            {
                waktuSisa = 0;
                GameOver(); // Panggil fungsi game over saat waktu habis
            }

            UpdateUI(); // Fungsi untuk memperbarui tampilan waktu
        }
    }

    void UpdateUI()
    {
        textWaktu.text = "" + Mathf.Ceil(waktuSisa).ToString(); // Menampilkan waktu ke teks
    }

    void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over"); // Tulis pesan game over ke konsol (bisa diganti dengan logika game over yang sesungguhnya)

        // Di sini, Anda dapat menambahkan logika lain untuk menampilkan layar game over, seperti mengaktifkan panel game over atau menu game over.
        
        // Contoh: Transisi ke layar game over dengan mengganti "NamaSceneGameOver" dengan nama scene yang sesuai
       // SceneManager.LoadScene("GAME OVER BOY");
    }
}
