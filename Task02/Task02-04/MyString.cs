namespace Task02_04
{
    internal class MyString
    {
        private readonly char[] content;
        private int length;

        public MyString()
        {
        }

        public MyString(char[] content)
        {
            this.content = new char[content.Length];
            content.CopyTo(this.content, 0);
            this.length = this.content.Length;
        }

        public MyString(char content)
        {
            this.content = new char[] { content };
            this.length = 1;
        }

        public MyString(string content)
        {
            this.content = content.ToCharArray();
            this.length = content.Length;
        }

        public char[] Content => this.content;

        public int Length => this.length;

        public char this[int i]
        {
            get
            {
                return this.content[i];
            }
        }

        public static MyString operator +(MyString string1, MyString string2)
        {
            return Concat(string1, string2);
        }

        public static bool operator !=(MyString string1, MyString string2)
        {
            return string1.Content != string2.Content;
        }

        public static bool operator ==(MyString string1, MyString string2)
        {
            return string1.Content == string2.Content;
        }

        public static MyString Concat(MyString string1, MyString string2)
        {
            int newLength = string1.Length + string2.Length;
            char[] content = new char[newLength];

            string1.Content.CopyTo(content, 0);
            string2.Content.CopyTo(content, string1.Length);

            return new MyString(content);
        }

        public MyString Concat(MyString string1)
        {
            int newLength = this.Length + string1.Length;
            char[] content = new char[newLength];

            this.content.CopyTo(content, 0);
            string1.Content.CopyTo(content, this.Length);

            return new MyString(content);
        }

        public int IndexOf(char symbol)
        {
            for (int i = 0; i < this.content.Length; i++)
            {
                if (this.content[i] == symbol)
                {
                    return i;
                }
            }

            return -1;
        }

        public int IndexOf(char[] array)
        {
            bool flag = true;
            for (int i = 0; i < this.content.Length - array.Length + 1; i++)
            {
                flag = true;
                if (this.content[i] == array[0])
                {
                    for (int j = 1; j < array.Length; j++)
                    {
                        if (this.content[i + j] != array[j])
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (flag)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        public int IndexOf(MyString string1)
        {
            bool flag;
            for (int i = 0; i < this.content.Length - string1.Length + 1; i++)
            {
                flag = true;
                if (this.content[i] == string1[0])
                {
                    for (int j = 1; j < string1.Length; j++)
                    {
                        if (this.content[i + j] != string1[j])
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (flag)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        public int IndexOf(char symbol, int startIndex)
        {
            for (int i = startIndex; i < this.content.Length; i++)
            {
                if (this.content[i] == symbol)
                {
                    return i;
                }
            }

            return -1;
        }

        public int IndexOf(char[] array, int startIndex)
        {
            bool flag = true;
            for (int i = startIndex; i < this.content.Length - array.Length + 1; i++)
            {
                flag = true;
                if (this.content[i] == array[0])
                {
                    for (int j = 1; j < array.Length; j++)
                    {
                        if (this.content[i + j] != array[j])
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (flag)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        public int IndexOf(MyString string1, int startIndex)
        {
            bool flag = true;
            for (int i = startIndex; i < this.content.Length - string1.Length + 1; i++)
            {
                flag = true;
                if (this.content[i] == string1[0])
                {
                    for (int j = 1; j < string1.Length; j++)
                    {
                        if (this.content[i + j] != string1[j])
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (flag)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        public MyString Substring(int startIndex)
        {
            int newLength = this.Length - startIndex;
            char[] content = new char[newLength];

            for (int i = 0; i < newLength; i++)
            {
                content[i] = this.content[i + startIndex];
            }

            return new MyString(content);
        }

        public MyString Substring(int startIndex, int count)
        {
            char[] content = new char[count];

            for (int i = startIndex; i < count + startIndex; i++)
            {
                content[i - startIndex] = this.content[i];
            }

            return new MyString(content);
        }

        public MyString Remove(int startIndex)
        {
            char[] content = new char[startIndex];

            for (int i = 0; i < startIndex; i++)
            {
                content[i] = this.content[i];
            }

            return new MyString(content);
        }

        public MyString Remove(int startIndex, int count)
        {
            char[] content = new char[this.Length - count];

            for (int i = 0; i < startIndex; i++)
            {
                content[i] = this.content[i];
            }

            for (int i = startIndex + count; i < this.Length; i++)
            {
                content[i - count] = this.content[i];
            }

            return new MyString(content);
        }

        public MyString Replace(char oldChar, char newChar)
        {
            char[] content = new char[this.Length];
            for (int i = 0; i < this.Length; i++)
            {
                if (this.content[i] == oldChar)
                {
                    content[i] = newChar;
                }
                else
                {
                    content[i] = this.content[i];
                }
            }

            return new MyString(content);
        }

        public MyString Replace(MyString oldString, MyString newString)
        {
            int[] indexes = new int[this.Length];
            int j = 0, i = 0, count = -1;
            if (this.IndexOf(oldString) == -1)
            {
                return this;
            }

            do
            {
                count++;
                i = this.IndexOf(oldString, i);
                indexes[count] = i;
                if (i != -1)
                {
                    i++;
                }
            }
            while (i != -1);

            char[] content = new char[this.Length + ((newString.Length - oldString.Length) * count)];
            j = 0;

            for (int k = 0; k < content.Length; k++)
            {
                if (k == (indexes[j] + ((newString.Length - oldString.Length) * j)))
                {
                    for (int q = 0; q < newString.Length; q++, k++)
                    {
                        content[k] = newString[q];
                    }

                    j++;
                    k--;
                }
                else
                {
                    content[k] = this.content[k - ((newString.Length - oldString.Length) * j)];
                }
            }

            return new MyString(content);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MyString))
            {
                return false;
            }

            MyString string1 = (MyString)obj;

            return this.content == string1.Content;
        }

        public override int GetHashCode()
        {
            return this.content.GetHashCode();
        }

        public override string ToString()
        {
            return new string(this.content);
        }
    }
}