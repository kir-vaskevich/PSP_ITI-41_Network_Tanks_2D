using System;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using TanksGameLibrary;
using TanksGameLibrary.Network;

namespace TanksWFA
{
    public partial class Form1 : Form
    {
        Game game;
        public Form1(Client client, bool player)
        {
            InitializeComponent();
            game = new Game(client, player);
            GameEvents.EndGame = EndGame;
        }

        private bool _loaded;

        private void GLControl_Load(object sender, EventArgs e)
        {
            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.Texture2D);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.Viewport(0, 0, gLControl.Width, gLControl.Height);

            _loaded = true;

            gLControl.Invalidate();
            Application.Idle += Application_Idle;

            game.Init();

            gLControl.Visible = true;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            while (gLControl.IsIdle)
            {
                Render();
            }
        }

        private void Render()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(System.Drawing.Color.CornflowerBlue);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-Width / 2, Width / 2, Height / 2, -Height / 2, 0d, 1d);
            
            game.Rendering();
            InitTanksProperties();

            gLControl.SwapBuffers();
        }

        private void EndGame(bool winner)
        {
            Application.Idle -= Application_Idle;
            EndGameLabel.Visible = true;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            tank1Ammo.Visible = false;
            tank1Health.Visible = false;
            tank2Ammo.Visible = false;
            tank1Fuel.Visible = false;
            tank2Health.Visible = false;
            tank2Fuel.Visible = false;
            gLControl.Visible = false;

            if (!winner)
                EndGameLabel.Text = "Игрок справа выйграл";
            else
                EndGameLabel.Text = "Игрок слева выйграл";
        }

        private void GLControl_Resize(object sender, EventArgs e)
        {
            if (!_loaded)
                return;
            GL.Viewport(0, 0, gLControl.Width, gLControl.Height);
            gLControl.Invalidate();
        }

        private void InitTanksProperties()
        {
            Tank tank;
            for (int i = 0; i < game.Count; i++)
            {
                if (game[i] is Tank)
                {
                    tank = game[i] as Tank;
                    if (!game[i].Player)
                    {
                        tank1Health.Text = tank.Health.ToString();
                        tank1Ammo.Text = tank.Canon.Ammo.ToString();
                        tank1Fuel.Text = tank.Fuel.ToString();
                    }
                    else
                    {
                        tank2Health.Text = tank.Health.ToString();
                        tank2Ammo.Text = tank.Canon.Ammo.ToString();
                        tank2Fuel.Text = tank.Fuel.ToString();
                    }
                }
            }
        }
    }
}