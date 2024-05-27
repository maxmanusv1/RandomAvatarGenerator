using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageGenerator.LogManager
{
    public class LogManager
    {
        public async Task PushLogs(RichTextBox textBox, LogTypes type, string log)
        {
            MethodInvoker methodInvoker = new MethodInvoker(delegate
            {
                if (textBox != null)
                {
                    if (type == LogTypes.Information)
                    {
                        textBox.ForeColor = Color.Blue;
                        textBox.AppendText(log + Environment.NewLine);    
                    }
                    else if (type == LogTypes.Warning)
                    {
                        textBox.ForeColor = Color.Yellow;
                        textBox.AppendText(log + Environment.NewLine);
                    }
                    else if(type == LogTypes.Error)
                    {
                        textBox.ForeColor= Color.Red;   
                        textBox.AppendText(log + Environment.NewLine);
                    }
                    else if (type == LogTypes.Success)
                    {
                        textBox.ForeColor = Color.DarkGreen;
                        textBox.AppendText(log + Environment.NewLine);
                    }
                }

            });
           textBox.Invoke(methodInvoker);

        }

    }
}
