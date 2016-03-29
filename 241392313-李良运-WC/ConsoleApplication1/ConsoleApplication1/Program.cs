using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Diagnostics;
namespace wc
{
    public class Program
    {
        static void Main(string[] args)
        {
            //d:\\program.cs
            Console.WriteLine("请输入文件路径：路径输入格式为d:\\program.cs");
            string dizhi = Console.ReadLine();
            FileStream fs = new FileStream(dizhi, FileMode.Open);
            StreamReader sdr = new StreamReader(fs);
            int iline = 0, n = 0, m = 1, t = 0, pline = 0, wline = 0, c = 0;
            int count = 0;
            string s = sdr.ReadLine();
            while (s != null)
            {
                iline++;
                if (m == 0 && c != iline)//判断是否是多行注释行中的一行
                {
                    wline++;
                }
                string[] str = s.Split(' ', '.', ',', ':', '?', '[', ']', '(', ')', '=', '!', '{', '}', '/', '"', '+', ';');
                foreach (string str1 in str)
                {
                    if (!str1.Equals(""))
                    {
                        count++;
                    }
                }
                if (s.Length == 0)
                {
                    pline++;
                }
                else
                {
                    t = 0;
                    foreach (string str1 in str)
                    {
                        if (!str1.Equals(""))
                        {
                            t++;
                        }
                    }
                    if (t == 0)
                    {
                        pline++;
                    }
                }
                for (int j = 0; j < s.Length - 1; j++)
                {
                    if (s[j] == '/' && s[j + 1] == '/')
                    {
                        wline++;
                    }
                    else if (s[j] == '/' && s[j] == '*')
                    {
                        c = iline;
                        m = 0;
                        wline++;
                    }
                    else if (s[j] == '*' && s[j] == '/')
                    {
                        m = 1;
                        wline++;
                    }
                }
                n = n + s.Length;
                s = sdr.ReadLine();
            }
            Console.WriteLine("总行数：{0}", iline);
            Console.WriteLine("空行数：{0}", pline);
            Console.WriteLine("注释行数：{0}", wline);
            Console.WriteLine("代码行数：{0}", iline - wline - pline);
            Console.WriteLine("字符数：{0}", n);
            Console.WriteLine("单词数：{0}", count);
            sdr.Close();
            System.Diagnostics.Debugger.Break();
        }
    }
}