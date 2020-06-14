using System;
using System.Text;
using CryptographyLibrary;

namespace RijndaelCipher
{
    public class Rijndael : ICipher
    {
        public int BlockSize = RijndaelData.blockSize;
        public byte[] Key { get; private set; }
        private byte[,] _key;

        public Rijndael(byte[] key)
        {
            SetKey(key);
        }

        public void SetKey(byte[] key)
        {
            if (key.Length == 16 || key.Length == 24 || key.Length == 32)
                _key = KeyExpansion(key);
            else
                throw new ArgumentException();
        }

        public byte[] Encrypt(byte[] message)
        {
            var counterBlock = RijndaelData.counterBlockDefault;
            int blockCount = (int)Math.Ceiling((double)(message.Length) / RijndaelData.blockSize);
            byte[][] cipherData = new byte[blockCount][];

            for (int b = 0; b < blockCount; b++)
            {
                for (int c = 0; c < 8; c++)
                    counterBlock[15 - c] = (byte)((unchecked((uint)b >> c * 8) & 0xff));

                byte[] cipherCntr = Cipher(counterBlock, _key);

                int blockLength = b < blockCount - 1 ? RijndaelData.blockSize : (message.Length - 1) % RijndaelData.blockSize + 1;
                byte[] cipherChar = new byte[blockLength];

                cipherData[b] = new byte[blockLength];
                for (int i = 0; i < blockLength; i++)
                {
                    cipherData[b][i] = (byte)(cipherCntr[i] ^ message[b * RijndaelData.blockSize + i]);
                }
            }

            byte[] result = new byte[(blockCount - 1) * RijndaelData.blockSize + ((message.Length - 1) % RijndaelData.blockSize + 1)];
            int idx = 0;

            for (int b = 0; b < blockCount; b++)
            {
                for (int i = 0; i < cipherData[b].Length; i++)
                {
                    result[idx] = cipherData[b][i];
                    idx++;
                }
            }
            return result;
        }

        public byte[] Decrypt(byte[] cipherMessage)
        {
            var counterBlock = RijndaelData.counterBlockDefault;
            int blockCount = (int)Math.Ceiling((double)(cipherMessage.Length) / RijndaelData.blockSize);
            byte[][] cipherData = new byte[blockCount][];

            for (int b = 0; b < blockCount; b++)
            {
                for (int c = 0; c < 8; c++)
                    counterBlock[15 - c] = (byte)((unchecked((uint)b >> c * 8) & 0xff));

                byte[] cipherCntr = Cipher(counterBlock, _key);

                int blockLength = b < blockCount - 1 ? RijndaelData.blockSize : (cipherMessage.Length - 1) % RijndaelData.blockSize + 1;
                byte[] cipherChar = new byte[blockLength];

                cipherData[b] = new byte[blockLength];

                for (int i = 0; i < blockLength; i++)
                {
                    cipherData[b][i] = (byte)(cipherCntr[i] ^ cipherMessage[b * RijndaelData.blockSize + i]);
                }
            }

            byte[] result = new byte[(blockCount - 1) * RijndaelData.blockSize + ((cipherMessage.Length - 1) % RijndaelData.blockSize + 1)];
            int idx = 0;

            for (int b = 0; b < blockCount; b++)
            {
                for (int i = 0; i < cipherData[b].Length; i++)
                {
                    result[idx] = cipherData[b][i];
                    idx++;
                }
            }

            return result;
        }

        public byte[] Encrypt(string message)
        {
            return Encrypt(Encoding.Unicode.GetBytes(message));
        }

        public byte[] Decrypt(string message)
        {
            return Decrypt(Encoding.Unicode.GetBytes(message)); ;
        }

        private byte[,] KeyExpansion(byte[] key)
        {
            int Nb = RijndaelData.blockSize;
            int Nk = key.Length / 4;
            int Nr = Nk + 6;
            int Nw = Nb * (Nr + 1);
            byte[,] w = new byte[Nw, 4];
            byte[] temp = new byte[4];

            for (int i = 0; i < Nk; i++)
            {
                w[i, 0] = key[4 * i];
                w[i, 1] = key[4 * i + 1];
                w[i, 2] = key[4 * i + 2];
                w[i, 3] = key[4 * i + 3];
            }

            for (int i = Nk; i < Nw; i++)
            {
                for (int t = 0; t < 4; t++)
                    temp[t] = w[i - 1, t];

                if (i % Nk == 0)
                {
                    temp = SubWord(RotWord(temp));
                    for (int t = 0; t < 4; t++)
                        temp[t] ^= RijndaelData.rCon[i / Nk, t];
                }
                else if (Nk > 6 && i % Nk == 4)
                {
                    temp = SubWord(temp);
                }

                for (int t = 0; t < 4; t++)
                    w[i, t] = (byte)(w[i - Nk, t] ^ temp[t]);
            }

            return w;
        }

        private byte[] Cipher(byte[] block, byte[,] key)
        {
            int Nb = RijndaelData.blockSize;
            int Nr = _key.GetLength(0) / Nb - 1;
            byte[,] state = new byte[4, Nb];

            for (int i = 0; i < 4 * Nb; i++)
            {
                double d = i / 4;
                state[i % 4, (int)Math.Floor(d)] = block[i];
            }

            state = AddRoundKey(state, key, 0, Nb);

            for (int round = 1; round < Nr; round++)
            {
                state = SubBytes(state, Nb);
                state = ShiftRows(state, Nb);
                state = MixColumns(state);
                state = AddRoundKey(state, key, round, Nb);
            }
            
            state = SubBytes(state, Nb);
            state = ShiftRows(state, Nb);
            state = AddRoundKey(state, key, Nr, Nb);

            var output = new byte[4 * Nb];

            for (int i = 0; i < 4 * Nb; i++)
            {
                double d = i / 4;
                output[i] = state[i % 4, (int)Math.Floor(d)];
            }

            return output;
        }

        private byte[,] SubBytes(byte[,] state, int Nb)
        {
            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < Nb; c++)
                    state[r, c] = RijndaelData.sBox[state[r, c]];
            }

            return state;
        }

        private byte[,] ShiftRows(byte[,] state, int Nb)
        {
            byte[] t = new byte[4];

            for (int r = 1; r < 4; r++)
            {
                for (int c = 0; c < 4; c++)
                    t[c] = state[r, (c + r) % Nb];

                for (int c = 0; c < 4; c++)
                    state[r, c] = t[c];
            }

            return state;
        }

        private byte[,] MixColumns(byte[,] state)
        {
            for (int c = 0; c < 4; c++)
            {
                byte[] a = new byte[4];
                byte[] b = new byte[4];

                for (int i = 0; i < 4; i++)
                {
                    a[i] = state[i, c];
                    b[i] = (byte)((state[i, c] & 0x80) > 0 ? state[i, c] << 1 ^ 0x011b : state[i, c] << 1);
                }

                state[0, c] = (byte)(b[0] ^ a[1] ^ b[1] ^ a[2] ^ a[3]); // 2*a0 + 3*a1 + a2 + a3
                state[1, c] = (byte)(a[0] ^ b[1] ^ a[2] ^ b[2] ^ a[3]); // a0 + 2*a1 + 3*a2 + a3
                state[2, c] = (byte)(a[0] ^ a[1] ^ b[2] ^ a[3] ^ b[3]); // a0 + a1 + 2*a2 + 3*a3
                state[3, c] = (byte)(a[0] ^ b[0] ^ a[1] ^ a[2] ^ b[3]); // 3*a0 + a1 + a2 + 2*a3
            }

            return state;
        }

        private byte[,] AddRoundKey(byte[,] state, byte[,] key, int rnd, int Nb)
        {
            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < Nb; c++)
                    state[r, c] ^= key[rnd * 4 + c, r];
            }

            return state;
        }

        private byte[] SubWord(byte[] word)
        {
            for (int i = 0; i < 4; i++)
                word[i] = RijndaelData.sBox[word[i]];

            return word;
        }

        private byte[] RotWord(byte[] word)
        {
            byte tmp = word[0];

            for (int i = 0; i < 3; i++)
                word[i] = word[i + 1];

            word[3] = tmp;

            return word;
        }
    }
}
