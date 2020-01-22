using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EgyszamjatekGUI
{
    class Jatekos
    {
        public string Nev { get; private set; }
        public List<int> Tippek { get; private set; }
        public int FordulokSzama { get { return Tippek.Count; } }
        public Jatekos(string sor)
        {
            string[] m = sor.Split();
            Nev = m[0];
            Tippek = new List<int>();
            foreach (var i in m.Skip(1)) Tippek.Add(int.Parse(i));
        }
    }

    public partial class MainWindow : Window
    {
        private List<Jatekos> jatekosok = new List<Jatekos>();

        public MainWindow()
        {
            InitializeComponent();
            AdatokBetoltese();
        }

        private void AdatokBetoltese()
        {
            foreach (var i in File.ReadAllLines("../../egyszamjatek2.txt")) jatekosok.Add(new Jatekos(i));
        }

        private void JatekostHozzaad_Click(object sender, RoutedEventArgs e)
        {
            if (jatekosok.Exists(x => x.Nev == InputJatekos.Text))
            {
                MessageBox.Show("Van már ilyen nevű játékos!", "Hiba!");
                return;
            }
            if (jatekosok[0].FordulokSzama != InputTippek.Text.Split(' ').Where(x => x.Length != 0).ToList().Count)
            {
                MessageBox.Show("A tippek száma nem megfelelő!", "Hiba!");
                return;
            }

            
            try // nem a megoldás része
            {
                File.AppendAllText("../../egyszamjatek2.txt", $"{InputJatekos.Text} {InputTippek.Text}\r\n");
                MessageBox.Show("Az állomány bővítése sikeres volt!", "Üzenet");
                InputJatekos.Text = "";
                InputTippek.Text = "";
                AdatokBetoltese();
            }
            catch (Exception ex) // nem a megoldás része
            {
                MessageBox.Show(ex.Message, "Hiba!");
            }
        }

        private void InputTippek_TextChanged(object sender, TextChangedEventArgs e)
        {
            TippDarab.Content = InputTippek.Text.Split(' ').Where(x => x.Length != 0).ToList().Count + " db";
        }
    }
}
