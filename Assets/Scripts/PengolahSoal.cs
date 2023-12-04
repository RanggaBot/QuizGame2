using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PengolahSoal : MonoBehaviour
{
     public TextAsset assetSoal;
     private string[] soal;

     private string [,] soalBag;

     int indexSoal;
     int maxSoal;
     bool ambilsoal;
     char kuncij;

     bool[] soalSelesai;

     //komponen UI
     public Text txtSoal, txtOpsiA,txtOpsiB,txtOpsiC,txtOpsiD;

      bool isHasil;
      private float durasi;
      public float durasiPenilaian;

      int jwbBenar, jwbSalah;
      float nilai;

      public GameObject panel;
      public GameObject imgPenilaian, imgHasil;
      public Text txtHasil;

    //Start is called before the first frame update 
     void Start()
     {
        durasi = durasiPenilaian;

        soal = assetSoal.ToString().Split('#');

        soalSelesai = new bool[soal.Length];

        soalBag = new string[soal.Length, 6];
        maxSoal = soal.Length;
        OlahSoal();

        ambilsoal = true;
        TampilkanSoal();

        print(soalBag[1,2]);
     }

      private void OlahSoal()
      {
       for(int i=0; i < soal.Length; i++) 
       {
         string[] tempSoal = soal[i].Split('+');
         for(int j = 0; j < tempSoal.Length; j++)
         {
            soalBag[i,j] = tempSoal[j];
            continue;
         }
         continue;
       }

     }
     private void TampilkanSoal()
     {
      if (indexSoal < maxSoal)
      {
         if (ambilsoal)
         {
            for(int i=0; i < soal.Length; i++)
            {
               int randomIndexSoal = Random.Range(0, soal.Length);
               if(!soalSelesai[randomIndexSoal])
               {
            txtSoal.text = soalBag[randomIndexSoal, 0];
            txtOpsiA.text = soalBag[randomIndexSoal, 1];
            txtOpsiB.text = soalBag[randomIndexSoal, 2];
            txtOpsiC.text = soalBag[randomIndexSoal, 3];
            txtOpsiD.text = soalBag[randomIndexSoal, 4];
            kuncij = soalBag[indexSoal, 5][0];

            soalSelesai[randomIndexSoal] = true;

            ambilsoal = false;
            break;
               }
               else
               {
                  continue;
               }
            }
         }
      }
     }

     public void Opsi(string opsiHuruf)
     {
      CheckJawaban(opsiHuruf[0]);

      if (indexSoal == maxSoal -1)
      {
         isHasil = true;
      }
      else
      {
         panel.SetActive(true);
      }

            indexSoal++;
            ambilsoal = true;
     }
     
     private float HitungNilai()
     {
         return nilai = (float)jwbBenar / maxSoal * 100;
     }

     public Text txtPenilaian;
     private void CheckJawaban(char huruf)
     {
      string penilaian;

      if (huruf.Equals(kuncij))
      {
         penilaian = "Benar!";
         jwbBenar++;
      }
      else
      {
        penilaian = "Salah!";
        jwbSalah++;
      }
      txtPenilaian.text = penilaian;

     }

     //Update is called once per frame
     void Update()
     {
         if(panel.activeSelf)
         {
            durasiPenilaian -=Time.deltaTime;


               if (isHasil)
               {
                  imgPenilaian.SetActive(true);
                  imgHasil.SetActive(false);

                  if (durasiPenilaian <= 0)
                  {
                     txtHasil.text = "Jumlah benar: "+jwbBenar+"\nJumlah Salah: "+ jwbSalah+"\n\nNilai: "+HitungNilai();

                     imgPenilaian.SetActive(false);
                     imgHasil.SetActive(true);

                     durasiPenilaian = 0;
                  }
               }
               else
               {
                  imgPenilaian.SetActive(true);
                  imgHasil.SetActive(false);

                  if(durasiPenilaian <= 0) 
               {
               panel.SetActive(false);
               durasiPenilaian = durasi;

               TampilkanSoal();
               }
             }
          }
     }
}