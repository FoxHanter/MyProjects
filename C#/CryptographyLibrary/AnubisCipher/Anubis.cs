using CryptographyLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnubisCipher
{
    public class Anubis : ICipher
    {
        public byte[] Key { get; private set; }
        private List<byte[,]> _key;
        private List<byte[,]> _c;
       

        public Anubis(byte[] key)
        {
            _key = new List<byte[,]>();
            _c = new List<byte[,]>();
            SetKey(key);
        }

        public void SetKey(byte[] key)
        {
            if (key.Length == 16)
            {
                _key.Add(ConvertToMatrix(key));
                byte[,] c = new byte[4, 4];
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        c[i, j] = 0;

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 4; j++)
                        c[0, j] = AnubisData.sBox[4 * i + j];

                    _c.Add(c);
                    _key.Add(roundKeyF(_key[0], (byte)i));
                }
            }
            else
                throw new ArgumentException();
        }

        private byte[,] roundKeyF(byte[,] key, byte round)
        {
            byte[,] current = new byte[4, 4];
            key = gamma(key);
            key = pi(key);
            key = teta(key);
            key = sigmaKey(key, round);

            return roundKeyG(current);
        }

        private byte[,] roundKeyG(byte[,] key)
        {
            key = gamma(key);
            key = omega(key);
            key = tay(key);

            return key;
        }

        private byte[,] pi(byte[,] word)
        {
            for (int j = 1; j < 4; j++)
            {
                for (int k = 0; k < j; k++)
                {
                    byte tmp = word[0, j];

                    for (int i = 0; i < 3; i++)
                        word[i, j] = word[i + 1, j];

                    word[3, j] = tmp;
                }
            }

            return word;
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
            int countBlock = (int)Math.Ceiling((double)(cipherMessage.Length) / AnubisData.blockSize);
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

                state = sigma(state, 0);

                for (int j = 0; j < 7; j++)
                {
                    state = gamma(state);
                    state = tay(state);
                    state = teta(state);
                    state = sigma(state, j + 1);
                }

                state = gamma(state);
                state = tay(state);
                state = sigma(state, 8);

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
            int countBlock = (int)Math.Ceiling((double)(cipherMessage.Length) / AnubisData.blockSize);
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
                state = sigma(state, 8);
                state = tay(state);
                state = gamma(state);

                for (int j = 0; j < 7; j++)
                {
                    state = sigma(state, 8 - j);
                    state = teta(state);
                    state = tay(state);
                    state = gamma(state);
                }

                state = sigma(state, 0);

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
        {
            byte p = 0;

            for (int counter = 0; counter < 8; counter++)
            {

                if ((b & 1) != 0)
                    p ^= a;

                bool hi_bit_set = (a & 0x80) != 0;
                a <<= 1;

                if (hi_bit_set)
                    a ^= 0x1B; /* x^8 + x^4 + x^3 + x + 1 */

                b >>= 1;
            }

            return p;
        }

        private byte[,] gamma(byte[,] state)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    state[i, j] = AnubisData.sBox[state[i, j]];
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
                    int ind = 0;

                    for (int k = 0; k < AnubisData.sBox.Length; k++)
                    {
                        if (AnubisData.sBox[k] == state[i, j])
                        {
                            ind = k;
                            break;
                        }
                    }

                    state[i, j] = (byte)ind;
                }
            }

            return state;
        }

        private byte[,] tay(byte[,] state)
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

        private byte[,] teta(byte[,] state)
        {
            byte[,] current = new byte[4, 4];

            for (int c = 0; c < 4; c++)
            {
                current[0, c] = (byte)(state[0, c] ^ GMul(0x02, state[1, c]) ^ GMul(0x04, state[2, c]) ^ GMul(0x06, state[3, c]));
                current[1, c] = (byte)(GMul(0x02, state[0, c]) ^ state[1, c] ^ GMul(0x06, state[2, c]) ^ GMul(0x04, state[3, c]));
                current[2, c] = (byte)(GMul(0x04, state[0, c]) ^ GMul(0x06, state[1, c]) ^ state[2, c] ^ GMul(0x02, state[3, c]));
                current[3, c] = (byte)(GMul(0x06, state[0, c]) ^ GMul(0x04, state[1, c]) ^ GMul(0x02, state[2, c]) ^ state[3, c]);
            }

            return current;
        }

        private byte[,] omega(byte[,] state)
        {
            byte[,] current = new byte[4, 4];

            for (int c = 0; c < 4; c++)
            {
                current[0, c] = (byte)(state[0, c] ^ state[1, c] ^ state[2, c] ^ state[3, c]);
                current[1, c] = (byte)(state[0, c] ^ GMul(0x02, state[1, c]) ^ GMul(0x04, state[2, c]) ^ GMul(0x08, state[3, c]));
                current[2, c] = (byte)(state[0, c] ^ GMul(0x06, state[1, c]) ^ GMul(0x24, state[2, c]) ^ GMul(0xD8, state[3, c]));
                current[3, c] = (byte)(state[0, c] ^ GMul(0x08, state[1, c]) ^ GMul(0x40, state[2, c]) ^ GMul(0x00, state[3, c]));
            }

            return current;
        }

        private byte[,] sigma(byte[,] state, int number)
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

        private byte[,] sigmaKey(byte[,] state, int number)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    state[i, j] ^= _c[number][i, j];
                }
            }

            return state;
        }
    }
}
