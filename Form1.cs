using System.Text.RegularExpressions;

namespace CalcLang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Обеспечивает подсветку синтаксиса, в частности ключевые слова
        private void SyntaxHighlighting()
        {
            string keyWords = "int|float|PRINT";
            Regex regex = new Regex(keyWords, RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(CodeSection.Text);
            int startPosition = CodeSection.SelectionStart;

            foreach (Match match in matches)
            {
                CodeSection.Select(match.Index, match.Length);
                CodeSection.SelectionColor = Color.FromArgb(49, 124, 222);
                CodeSection.SelectionStart = startPosition;
                CodeSection.SelectionLength = 0;
                CodeSection.SelectionColor = Color.White;
            }
        }

        // Обеспечивает подсветку комментариев
        private void CommentsHighlighting()
        {
            for (int i = 0; i < CodeSection.Text.Length; i++)
            {
                int startPosition = CodeSection.SelectionStart;

                if (CodeSection.Text[i] == '$')
                {
                    int lenght = 0;
                    int start = i;
                    while (i < CodeSection.Text.Length && CodeSection.Text[i] != '\n')
                    {
                        i++;
                        lenght++;
                    }
                    CodeSection.Select(start, lenght);
                    CodeSection.SelectionColor = Color.FromArgb(33, 155, 33);
                }
                CodeSection.SelectionStart = startPosition;
                CodeSection.SelectionLength = 0;
                CodeSection.SelectionColor = Color.White;
            }
        }

        // Обработчик события при изменении текста для подсветки синтаксиса
        private void CodeSection_TextChanged(object sender, EventArgs e)
        {
            SyntaxHighlighting();
            CommentsHighlighting();
        }

        // Обработчик события для кнопки "Open"
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "cl files (*.cl)|*.cl";

            if (file.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(file.FileName))
                {
                    CodeSection.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
        }

        // Обработчик события для кнопки "Save"
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "cl files (*.cl)|*.cl";

            if (file.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(file.FileName, CodeSection.Text);
            }
        }

        // Обработчик события для кнопки "Run"
        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OutputBox.Items.Clear();
            Starter starter = new Starter(CodeSection.Text);

            List<SToken>? lexer = starter.StartLexer();
            if (lexer == null)
            {
                OutputBox.Items.Add(starter.LexerError);
                return;
            }

            List<DataObject>? parser = starter.StartParser(lexer);
            if (parser == null)
            {
                foreach (string error in starter.ParserErrors)
                {
                    OutputBox.Items.Add(error);
                }
                return;
            }

            List<DataObject>? semantic = starter.StartSemantic(parser);
            if (semantic == null)
            {
                foreach (string error in starter.SemanticErrors)
                {
                    OutputBox.Items.Add(error);
                }
                return;
            }

            List<string>? outputs = starter.StartCodeGenerator(parser);
            if (outputs == null)
            {
                foreach (string error in starter.GenerateErrors)
                {
                    OutputBox.Items.Add(error);
                }
                return;
            }

            foreach (string output in outputs)
            {
                OutputBox.Items.Add(output);
            }
        }
    }
}