using CryptographyLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentCipher
{
    public class Present: ICipher
    {
        public byte[] Key { get; private set; }
        public List<byte[]> _roundKeys;
       
        public Present(byte[] key)
        {
            SetKey(key);
        }

        public void SetKey(byte[] key)
        {
            if (key.Length == 16)
            {
                Key = key;
                _roundKeys = new List<byte[]>();
                GenerateRoundKeys();
            }
            else
                throw new ArgumentException();
        }

        private void GenerateRoundKeys()
        {
            for (int i = 0; i < 32; i++)
            {
                byte[] currentKey = new byte[8];

                for (int j = 0; j < 8; j++)
                {
                    currentKey[j] = Key[j];
                }

                _roundKeys.Add(currentKey);

                byte[] r = new byte[32];
                for (int j = 0; j < 16; j++)
                {
                    r[PresentData.kk[j*2]]= Converter.GetFirstByte(Key[j]);
                    r[PresentData.kk[j * 2]] = Converter.GetSecondByte(Key[j]);
                }
                r[0] = PresentData.sBox[r[0]];
                r[1] = PresentData.sBox[r[1]];

                for (int j = 0; j < 16; j++)
                {
                    Key[j] = Converter.UnionByte(r[j * 2], r[j * 2 + 1]);
                }
            }
        }

        public byte[] Encrypt(string message)
        {
            return Encrypt(Encoding.Unicode.GetBytes(message));
        }

        public byte[] Decrypt(string message)
        {
            return Decrypt(Encoding.Unicode.GetBytes(message)); ;
        }

        public byte[] Encrypt(byte[] cipherMessage)
        {
            int countBlock = (int)Math.Ceiling((double)(cipherMessage.Length) / PresentData.blockSize);
            byte[] rezult = new byte[countBlock * 8];
            int index = 0;
            for (int i = 0; i < countBlock; i++)
            {
                byte[] block = new byte[8];

                for (int j = 0; j < 8; j++)
                {
                    block[j] = j + i * 8 < cipherMessage.Length ? cipherMessage[j + i * 8] : (byte)0;
                }

                for (int j = 0; j < 31; j++)
                {
                    block = keysss(block, j);
                    block = first(block);
                    block = second(block);
                }

                block = keysss(block, 31);

                for (int k = 0; k < 8; k++)
                {
                    rezult[index] = block[k];
                    index++;
                }
            }
            return rezult;
        }
        

        public byte[] Decrypt(byte[] cipherMessage)
        {
            int countBlock = (int)Math.Ceiling((double)(cipherMessage.Length) / PresentData.blockSize);
            byte[] rezult = new byte[countBlock * 8];
            int index = 0;
            for (int i = 0; i < countBlock; i++)
            {
                byte[] block = new byte[8];
                for (int j = 0; j < 8; j++)
                {
                    block[j] = j + i * 8 < cipherMessage.Length ? cipherMessage[j + i * 8] : (byte)0;
                }

                block = keysss(block, 31);
                for (int j = 0; j <31; j++)
                {
                    block = second1(block);
                    block = first1(block);
                    block = keysss(block, 30-j);
                }

                for (int k = 0; k < 8; k++)
                {
                    rezult[index] = block[k];
                    index++;
                }

            }
            
            return rezult;
        }

        private byte[] first(byte[] state)
        {
            for (int j = 0; j < 8; j++)
            {
                byte a = Converter.GetFirstByte(state[j]);
                byte b = Converter.GetSecondByte(state[j]);
                a = PresentData.sBox[a];
                b = PresentData.sBox[b];
                state[j] = Converter.UnionByte(a, b);
            }

            return state;
        }

        private byte[] second(byte[] state)
        {
            byte[] answer = new byte[8];
    
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int index = PresentData.a[i * 8 + j];
                    int i1 = index / 8;
                    int j1 = index % 8;
                    if(((state[i1] >> j1) & 1)==1)
                        answer[i] |= (byte)(1 << j);
                    else
                        answer[i] &= (byte)~(1 << j);
                }
                
            }

            return answer;
        }

        private byte[] first1(byte[] state)
        {
            for (int j = 0; j < 8; j++)
            {
                byte a = Converter.GetFirstByte(state[j]);
                byte b = Converter.GetSecondByte(state[j]);
                a = PresentData.bBox[a];
                b = PresentData.bBox[b];
                state[j] = Converter.UnionByte(a, b);
            }

            return state;
        }

        private byte[] second1(byte[] state)
        {
            byte[] answer = new byte[8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int index = PresentData.b[i * 8 + j];
                    int i1 = index / 8;
                    int j1 = index % 8;
                    if (((state[i1] >> j1) & 1) == 1)
                        answer[i] |= (byte)(1 << j);
                    else
                        answer[i] &= (byte)~(1 << j);
                }

            }

            return answer;
        }

        private byte[] keysss(byte[] state, int round)
        {
            for (int i = 0; i < 8; i++)
            {
                state[i]^= _roundKeys[round][i];
            }
            return state;
        }

        private void Print(byte[] block)
        {
            for (int q = 0; q < 8; q++)
            {
                Console.Write($"{block[q]} ");               
            }
            Console.WriteLine();
        }
    }
}
