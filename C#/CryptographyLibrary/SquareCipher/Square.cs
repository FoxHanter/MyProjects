using CryptographyLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace SquareCipher
{
    public class Square : ICipher
    {
        public byte[] Key { get; private set; }
        private List<byte[,]> _key;
        

        public Square(byte[] key)
        {
            _key = new List<byte[,]>();
            SetKey(key);
        }

        public void SetKey(byte[] key)
        {
            if (key.Length == 16)
            {
                _key.Add(ConvertToMatrix(key));
                for (int i = 0; i < 8; i++)
                {
                    _key.Add(roundKey(_key[0], (byte)i));
                }
            }
            else
                throw new ArgumentException();
        }

        private byte[,] ConvertToMatrix(byte[] key)
        {
            byte[,] w = new byte[4, 4];

            for (int i = 0; i < 4; i++)
            {
                w[i, 0] = key[4 * i];
                w[i, 1] = key[4 * i + 1];
                w[i, 2] = key[4 * i + 2];
                w[i, 3] = key[4 * i + 3];
            }

            return w;
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
            int countBlock = (int)Math.Ceiling((double)(cipherMessage.Length) / SquareData.blockSize);
            byte[] rezult = new byte[countBlock * 16];
            int index = 0;
            for (int i = 0; i < countBlock; i++)
            {
                byte[] block = new byte[16];
                for (int j = 0; j < 16; j++)
                {
                    block[j] = j + i * 16 < cipherMessage.Length ? cipherMessage[j + i * 16] : (byte)0;
                }

                var state = ConvertToMatrix(block);

                state = teta1(state);
                state = sigma(state,0);

                for (int j = 0; j < 8; j++)
                {
                    state = teta(state);
                    state = gamma(state);
                    state = pi(state);                    
                    state = sigma(state,j+1);
                }

                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        rezult[index] = state[j, k];
                        index++;
                    }
                }
            }
            return rezult;
        }

        public byte[] Decrypt(byte[] cipherMessage)
        {
            int countBlock = (int)Math.Ceiling((double)(cipherMessage.Length) / SquareData.blockSize);
            byte[] rezult = new byte[countBlock * 16];
            int index = 0;
            for (int i = 0; i < countBlock; i++)
            {
                byte[] block = new byte[16];
                for (int j = 0; j < 16; j++)
                {
                    block[j] = j + i * 16 < cipherMessage.Length ? cipherMessage[j + i * 16] : (byte)0;
                }

                var state = ConvertToMatrix(block);
               
                
                for (int j = 0; j < 8; j++)
                {
                    state = sigma(state, 8 - j);
                    state = pi(state);
                    state = gamma1(state);
                    state = teta1(state);                   
                }

                state = sigma(state, 0);
                state = teta(state);
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        rezult[index] = state[j, k];
                        index++;
                    }
                }
            }

            return rezult;
        }

        private byte GMul(byte a, byte b)
        { // Galois Field (256) Multiplication of two Bytes

            byte p = 0;

            for (int counter = 0; counter < 8; counter++)
            {

                if ((b & 1) != 0)
                {
                    p ^= a;
                }

                bool hi_bit_set = (a & 0x80) != 0;
                a <<= 1;

                if (hi_bit_set)
                {
                    a ^= 0x1B; /* x^8 + x^4 + x^3 + x + 1 */
                }

                b >>= 1;
            }

            return p;
        }

        private byte[] RotWord(byte[] word)
        {
            byte tmp = word[0];

            for (int i = 0; i < 3; i++)
                word[i] = word[i + 1];

            word[3] = tmp;

            return word;
        }

        private byte[,] teta(byte[,] state)
        {
            byte[,] current = new byte[4, 4];

            for (int c = 0; c < 4; c++)
            {

                current[0, c] = (byte)(GMul(0x02, state[0, c]) ^ GMul(0x03, state[1, c]) ^ state[2, c] ^ state[3, c]);

                current[1, c] = (byte)(state[0, c] ^ GMul(0x02, state[1, c]) ^ GMul(0x03, state[2, c]) ^ state[3, c]);

                current[2, c] = (byte)(state[0, c] ^ state[1, c] ^ GMul(0x02, state[2, c]) ^ GMul(0x03, state[3, c]));

                current[3, c] = (byte)(GMul(0x03, state[0, c]) ^ state[1, c] ^ state[2, c] ^ GMul(0x02, state[3, c]));

            }
            return current;
        }

        private byte[,] teta1(byte[,] state)
        {
            byte[,] current = new byte[4, 4];

            for (int c = 0; c < 4; c++)
            {

                current[0, c] = (byte)(GMul(0x0E, state[0, c]) ^ GMul(0x0B, state[1, c]) ^ GMul(0x0D, state[2, c]) ^ GMul(0x09, state[3, c]));

                current[1, c] = (byte)(GMul(0x09, state[0, c]) ^ GMul(0x0E, state[1, c]) ^ GMul(0x0B, state[2, c]) ^ GMul(0x0D, state[3, c]));

                current[2, c] = (byte)(GMul(0x0D, state[0, c]) ^ GMul(0x09, state[1, c]) ^ GMul(0x0E, state[2, c]) ^ GMul(0x0B, state[3, c]));

                current[3, c] = (byte)(GMul(0x0B, state[0, c]) ^ GMul(0x0D, state[1, c]) ^ GMul(0x09, state[2, c]) ^ GMul(0x0E, state[3, c]));

            }
            return current;
        }

        private byte[,] gamma(byte[,] state)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    state[i, j] = SquareData.sBox[state[i, j]];            
                }
            }
            
            return state;
        }

        private byte[,] gamma1(byte[,] state)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    state[i, j] = SquareData.bBox[state[i, j]];
                }
            }

            return state;
        }

        private byte[,] pi(byte[,] state)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    byte tmp = state[i, j];
                    state[i, j] = state[j, i];
                    state[j, i] = tmp;
                }
            }

            return state;
        }

        private byte[,] sigma(byte[,] state,int number)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    state[i, j] ^= _key[number][i, j];
                }
            }

            return state;
        }

        private byte[,] roundKey(byte[,] key,byte round)
        {
            byte c = (byte)Math.Pow(2, round);
            byte[,] current = new byte[4, 4];

            for (int i = 0; i < 4; i++)
            {
                byte[] w = { key[3, 0], key[3, 1], key[3, 2], key[3, 3] };
                w = RotWord(w);
                for (int j = 0; j < 4; j++)
                {
                    if (i==0)
                        current[i, j] =(byte)(key[i, j] | w[j] | c);                   
                    else
                        current[i, j] = (byte)(key[i,j] | current[i-1,j]);
                }
            }
            return current;
        }
    }
}
