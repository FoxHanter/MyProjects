using System;
using System.Collections.Generic;
using System.IO;

namespace CryptographyLibrary
{
    public class Tester
    {
        public string TestClass;
        public string FileName;
        private List<int[]> _data;
        private string _first;
        public int index;
        private int n;
        public Tester(string testClass, string fileName,int length)
        {
            TestClass = testClass;
            FileName = fileName;
            _data = new List<int[]>();
            index = -1;
            n = length;
        }

        public void AddRound()
        {
            _data.Add(new int[256]);
            index++;
        }

        public void AddData(int round,byte[,] state)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    _data[round][state[i, j]]++;
                }
            }
        }

        public void AddData(int round, byte[] state)
        {
            for (int i = 0; i < state.Length; i++)
            {
                    _data[round][state[i]]++;
            }
        }

        public void PrintAllData()
        {
            using (StreamWriter f = new StreamWriter(FileName,true))
            {

                for (int i = 0; i < _data.Count; i++)
                {
                    double entrop = Math.Log(n, 2);
                    double rew = 0;
                    for (int we = 0; we < 256; we++)
                    {
                        double coun = _data[i][we];
                        double p = coun / n;
                        if (coun != 0)
                            rew += (p * Math.Log(coun, 2));
                    }
                    f.WriteLine(entrop - rew);
                }

                f.WriteLine();
            }
        }

    }
}
