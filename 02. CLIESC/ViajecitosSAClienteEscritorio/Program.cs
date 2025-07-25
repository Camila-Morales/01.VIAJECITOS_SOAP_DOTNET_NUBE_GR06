﻿using System;
using System.Windows.Forms;

namespace ViajecitosSAClienteEscritorio
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm(loginForm.UsuarioAutenticado));
            }
        }
    }
}
