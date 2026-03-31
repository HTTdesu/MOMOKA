using System;
using System.IO;
using System.Text;

namespace MOMOKA.Generator
{
    public class MMKFileBuilder
    {
        protected string m_FilePath = "Assets/";
        protected int m_IndentLevel = 0;
        protected StringBuilder m_FileBuilder = new StringBuilder();

        public MMKFileBuilder(string filePath)
        {
            m_FilePath = Path.GetFullPath(filePath);
        }

        protected string GetIndent()
        {
            return new string(' ', m_IndentLevel * 4);
        }

        public void AppendIndent()
        {
            m_FileBuilder.Append(GetIndent());
        }

        public void Append(string text, bool hasIndent = false)
        {
            if (hasIndent)
            {
                m_FileBuilder.Append(GetIndent());
            }
            m_FileBuilder.Append(text);
        }

        public void AppendLine(string line = "")
        {
            if (line == null) return;
            m_FileBuilder.Append(GetIndent());
            m_FileBuilder.AppendLine(line);
        }

        public void IncreaseIndent(string beginning = null)
        {
            if (!string.IsNullOrEmpty(beginning))
            {
                AppendLine(beginning);
            }
            m_IndentLevel++;
        }

        public void DecreaseIndent(string ending = null)
        {
            m_IndentLevel = Math.Max(0, m_IndentLevel - 1);
            if (!string.IsNullOrEmpty(ending))
            {
                AppendLine(ending);
            }
        }

        public void WriteFile()
        {
            string directory = Path.GetDirectoryName(m_FilePath);
            if (directory == null)
            {
                Directory.CreateDirectory(directory);
            }
            File.WriteAllText(m_FilePath, m_FileBuilder.ToString());
        }
    }
}

