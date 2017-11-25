using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class DataCollector : MonoBehaviour {

    public bool Debugging = true;
    public ScoreKeeper scoreKeeper;
    public string FileName = "DataCollected.csv";
    public string Directory = "Assets/Resources";
    public string Delimiter = ";";

    private string fullPath; 

    private DateTime timeStampStart;
    private DateTime timeStampEnd;
    private int score;
    private double duration;

	public void Begin()
    {
        fullPath = Directory + "/" + FileName;
        timeStampStart = DateTime.Now;
    }

    public void End()
    {
        timeStampEnd = DateTime.Now;
        score = scoreKeeper.Score;
        duration = Mathf.RoundToInt((float)(timeStampEnd - timeStampStart).TotalSeconds);
        if (Debugging)
        {
            Debug.Log("DataCollector: "+FormatData());
        }
        else
        {
            AppendToFile();
        }
    }

    private void AppendToFile()
    {
        StreamWriter writer = new StreamWriter(fullPath, true);
        writer.WriteLine(FormatData());
        writer.Close();
    }

    private string FormatData()
    {
        return timeStampStart.ToLocalTime() + Delimiter + timeStampEnd.ToLocalTime() + Delimiter + score + Delimiter + duration;
    }
}
