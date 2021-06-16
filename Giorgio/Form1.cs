using Giorgio.Properties;
using System;
using System.Drawing;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Giorgio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            CenterToScreen();

            new SoundPlayer(Resources.GiorgioAudio).Play();

            for (int i = 0; i < 5; i++)
                await Task.Delay(1100); // Aspetta il drop della canzone

            await PerformMovementAsync(50, () =>
            {
                Left -= 2;
                Top++;
            });

            while (true)
            {
                await PerformMovementAsync(50, () =>
                {
                    Left -= 2;
                    Top--;
                });
                await PerformMovementAsync(50, () =>
                {
                    Left += 2;
                    Top--;
                });

                await PerformMovementAsync(100, () =>
                {
                    Left += 2;
                    Top++;
                });

                await PerformMovementAsync(50, () =>
                {
                    Left += 2;
                    Top--;
                });
                await PerformMovementAsync(50, () => 
                { 
                    Left -= 2; 
                    Top--; 
                });

                await PerformMovementAsync(100, () => 
                {
                    Left -= 2;
                    Top++;
                });
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private async Task PerformMovementAsync(int count, Action action, int delay = 10)
        {
            for (int i = 0; i < count; i++)
            {
                action.Invoke();
                await Task.Delay(delay);
            }
        }
    }
}
