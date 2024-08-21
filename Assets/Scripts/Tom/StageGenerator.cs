using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StageGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadStage("1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadStage(string name)
    {
        TextAsset csvFile = (TextAsset)Resources.Load("Stage/" + name);
        string[][] csvData = ParseCSV(csvFile.text);

        // csvData���g�p���ă^�C���}�b�v���\�z���鏈���������ɒǉ�
        for (int i = 0; i < csvData.Length; i++)
        {
            for (int j = 0; j < csvData[i].Length; j++)
            {
                Debug.Log(csvData[i][j]);
                if (!csvData[i][j].Trim().Equals("0"))
                {
                    GameObject prefab = (GameObject)Resources.Load("Prefabs/" + csvData[i][j]);
                    if (prefab != null)
                    {
                        GameObject obj = Instantiate(prefab, new Vector3(j, 0 - i, 0), Quaternion.identity);
                        //obj.transform.SetParent(tilemap.transform, false);
                    }

                }
            }
        }
    }

    private string[][] ParseCSV(string csvText)
    {
        var lines = csvText.Split('\n'); // ���s�ōs�𕪊�
        var csvData = new string[lines.Length][]; // �s���ɉ�����2�����z����쐬

        for (int i = 0; i < lines.Length; i++)
        {
            csvData[i] = lines[i].Split(','); // �e�s���J���}�ŕ������Ĕz��Ɋi�[
        }

        return csvData; // 2�����z���Ԃ�
    }
}
