using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aplikacjaProjecktowa
{
    public partial class Form1 : Form
    {
        List<FileInfo> lista_plikow = new List<FileInfo>();
        List<DirectoryInfo> lista_katalogow = new List<DirectoryInfo>();

        public Form1()
        {
            InitializeComponent();
            fbd.Description = "Wybierz katalog, w którym będzie dzialal algorytm";
            fbd.ShowNewFolderButton = false;
        }
        //Aplikacja do analiz i wyszukiwania plików i folderów, generująca także różne statystyki
        //np. wypisywanie plików, folderów posortowanych wg rozmiarów, daty utworzenia, zliczanie plików wg ich typów (rozszerzeń),
        public void refresh()
        {
            listBox.Items.Clear();
            lista_plikow.RemoveRange(0, lista_plikow.Count);
            lista_katalogow.RemoveRange(0, lista_katalogow.Count);
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            searchTextBox.Text = "";
        }

        private void szukajbutton_Click(object sender, EventArgs e)
        {
            string napis = searchTextBox.Text;
            refresh();
            searchTextBox.Text = napis;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string katalog = fbd.SelectedPath;
                DirectoryInfo directoryInfo = new DirectoryInfo(katalog);
                if (searchTextBox.Text.Equals(""))
                {
                    searchTextBox.Text = "Tutaj trzeba wpisac nazwe pliku albo katalogu ktorego szukassz!";
                }
                else
                {
                    szukaj(directoryInfo, searchTextBox.Text);
                    wyswietlanie();
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano katalogu do wyszukiwania");
            }
        }

        private void szukaj(DirectoryInfo di, string pattern)
        {
            FileInfo[] pliki = di.GetFiles();
            foreach (FileInfo fi in pliki)
            {
                if (fi.Name.Contains(pattern))
                {
                    lista_plikow.Add(fi);
                }
            }
            DirectoryInfo[] katalogi = di.GetDirectories();
            foreach (DirectoryInfo dikolejne in katalogi)
            {
                if (dikolejne.Name.Contains(pattern))
                {
                    lista_katalogow.Add(dikolejne);
                }
                szukaj(dikolejne, pattern);
            }
        }

        private void analizujbutton_Click(object sender, EventArgs e)
        {
            refresh();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string katalog = fbd.SelectedPath;
                DirectoryInfo directoryInfo = new DirectoryInfo(katalog);
                listBox.Items.Add($"{directoryInfo.Name} data utworzenia: {directoryInfo.CreationTime}");
                analizujKatalog(directoryInfo);
                searchTextBox.Text = "";
                if (lista_katalogow.Count != 0)
                {
                    searchTextBox.Text += $"Liczba katalogow: {lista_katalogow.Count} ";
                }
                if (lista_plikow.Count != 0)
                {
                    searchTextBox.Text += $"Liczba plikow: {lista_plikow.Count}";
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano katalogu do wyszukiwania");
            }
        }

        private void analizujKatalog(DirectoryInfo di)
        {
            FileInfo[] pliki = di.GetFiles();
            listBox.Items.Add($"Pliki w katalogu ---> {di.FullName}: ");
            foreach (FileInfo fi in pliki)
            {
                lista_plikow.Add(fi);
                listBox.Items.Add($"{fi.Name} czas utworzenia: {fi.CreationTime} rozmiar pliku: {fi.Length}");
            }
            DirectoryInfo[] katalogi = di.GetDirectories();
            foreach (DirectoryInfo dikolejne in katalogi)
            {
                lista_katalogow.Add(dikolejne);
                analizujKatalog(dikolejne);
            }
        }

        private void katalogibutton_Click(object sender, EventArgs e)
        {
            refresh();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string katalog = fbd.SelectedPath;
                DirectoryInfo directoryInfo = new DirectoryInfo(katalog);
                szukajKatalogi(directoryInfo);
                wyswietlanie();
            }
            else
            {
                MessageBox.Show("Nie wybrano katalogu do wyszukiwania");
            }
        }

        private void szukajKatalogi(DirectoryInfo di)
        {
            DirectoryInfo[] katalogi = di.GetDirectories();
            foreach (DirectoryInfo dikolejne in katalogi)
            {
                lista_katalogow.Add(dikolejne);
                szukajKatalogi(dikolejne);
            }
        }

        private void plikibutton_Click(object sender, EventArgs e)
        {
            refresh();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string katalog = fbd.SelectedPath;
                DirectoryInfo directoryInfo = new DirectoryInfo(katalog);
                szukajPliki(directoryInfo);
                wyswietlanie();
            }
            else
            {
                MessageBox.Show("Nie wybrano katalogu do wyszukiwania");
            }
        }

        private void szukajPliki(DirectoryInfo di)
        {

            FileInfo[] pliki = di.GetFiles();
            foreach (FileInfo fi in pliki)
            {
                lista_plikow.Add(fi);
            }
            DirectoryInfo[] katalogi = di.GetDirectories();
            foreach (DirectoryInfo dikolejne in katalogi)
            {
                szukajPliki(dikolejne);
            }
        }

        private void sortNameButton_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            lista_katalogow.Sort(
                delegate (DirectoryInfo dr1, DirectoryInfo dr2) { return dr1.Name.CompareTo(dr2.Name); }
            );
            lista_plikow.Sort(
                delegate (FileInfo fi1, FileInfo fi2) { return fi1.Name.CompareTo(fi2.Name); }
            );
            wyswietlanie();
        }

        private void sortDataButton_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            lista_katalogow.Sort(
                delegate (DirectoryInfo dr1, DirectoryInfo dr2) { return dr1.CreationTime.CompareTo(dr2.CreationTime); }
            );
            lista_plikow.Sort(
                delegate (FileInfo fi1, FileInfo fi2) { return fi1.CreationTime.CompareTo(fi2.CreationTime); }
            );
            wyswietlanie();
        }

        private void sortRozmiarButton_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            lista_plikow.Sort(
                delegate (FileInfo fi1, FileInfo fi2) { return fi1.Length.CompareTo(fi2.Length); }
            );
            wyswietlanie();
        }

        private void wyswietlanie()
        {
            if (lista_katalogow.Count != 0)
            {
                listBox.Items.Add($"Liczba katalogow: {lista_katalogow.Count}");
            }
            if (lista_plikow.Count != 0)
            {
                listBox.Items.Add($"Liczba plikow: {lista_plikow.Count}");
            }
            if (lista_katalogow.Count != 0)
            {
                foreach (var element in lista_katalogow)
                {
                    listBox.Items.Add($"Katalog: {element.Name} data utworzenia: {element.CreationTime}");
                }
            }
            if (lista_plikow.Count != 0)
            {
                foreach (var element in lista_plikow)
                {
                    listBox.Items.Add($"Plik: {element.Name} data utworzenia: {element.CreationTime} rozmiar pliku: {element.Length}");
                }
            }
        }

        private void zliczanieButton_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            Dictionary<string, int> typy = new Dictionary<string, int>();
            foreach (var element in lista_plikow)
            {
                bool jest = false;
                foreach (var typ in typy)
                {
                    if (typ.Key == element.Extension)
                    {
                        string napis = typ.Key;
                        int ilosc = typ.Value + 1;
                        typy.Remove(napis);
                        typy.Add(napis, ilosc);
                        jest = true;
                        break;
                    }
                }
                if (!jest)
                {
                    typy.Add(element.Extension, 1);
                }
            }
            foreach (var element in typy)
            {
                listBox.Items.Add($"Sa {element.Value} plikow o typie {element.Key}");
            }
        }
    }
}


/*
        private void plikiButton_Click(object sender, EventArgs e)
        {
            refresh();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string katalog = fbd.SelectedPath;
                DirectoryInfo directoryInfo = new DirectoryInfo(katalog);
                szukajPliki(directoryInfo);
                informacja.Sort(delegate(FileInfo info1, FileInfo info2)
                { return info1.CreationTime.CompareTo(info2.CreationTime); });
                foreach (FileInfo element in informacja)
                {
                    listBox.Items.Add(element.Name + "   " + element.CreationTime + "   " + element.Length);
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano katalogu do wyszukiwania");
            }
        }

        private void katalogiButton_Click(object sender, EventArgs e)
        {
            refresh();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string katalog = fbd.SelectedPath;
                DirectoryInfo directoryInfo = new DirectoryInfo(katalog);
                szukajKatalogi(directoryInfo);
            }
            else
            {
                MessageBox.Show("Nie wybrano katalogu do wyszukiwania");
            }
        }

        private void szukajPliki(DirectoryInfo di)
        {
            
            FileInfo[] pliki = di.GetFiles();
            foreach (FileInfo fi in pliki)
            {
                informacja.Add(fi);
            }
            DirectoryInfo[] katalogi = di.GetDirectories();
            foreach (DirectoryInfo dirinfo in katalogi)
            {
                szukajPliki(dirinfo);
            }
        }

        private void szukajKatalogi(DirectoryInfo di)
        {
            DirectoryInfo[] katalogi = di.GetDirectories();
            foreach (DirectoryInfo dirinfo in katalogi)
            {
                listBox.Items.Add(dirinfo.Name + " data utworzenia: " + dirinfo.CreationTime);
                szukajKatalogi(dirinfo);
            }
        }

        private void analizButton_Click(object sender, EventArgs e)
        {
            refresh();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string katalog = fbd.SelectedPath;
                DirectoryInfo directoryInfo = new DirectoryInfo(katalog);
                listBox.Items.Add(directoryInfo.Name + " data utworzenia: " + directoryInfo.CreationTime);
                analizujKatalog(directoryInfo);
            }
            else
            {
                MessageBox.Show("Nie wybrano katalogu do wyszukiwania");
            }
        }

        private void analizujKatalog(DirectoryInfo di)
        {
            FileInfo[] pliki = di.GetFiles();
            listBox.Items.Add("Pliki w katalogu ---> " + di.FullName + ":");
            foreach (FileInfo fi in pliki)
            {
                listBox.Items.Add(fi.ToString() + " czas utworzenia: " + fi.CreationTime + " rozmiar pliku: " + fi.Length);
            }
            DirectoryInfo[] katalogi = di.GetDirectories();
            foreach (DirectoryInfo dirinfo in katalogi)
            {
                analizujKatalog(dirinfo);
            }
        }

        private void szukajButton_Click(object sender, EventArgs e)
        {
            refresh();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string katalog = fbd.SelectedPath;
                DirectoryInfo directoryInfo = new DirectoryInfo(katalog);
                szukaj(directoryInfo, searchTextBox.Text);
            }
            else
            {
                MessageBox.Show("Nie wybrano katalogu do wyszukiwania");
            }
        }

        private void szukaj(DirectoryInfo di, string pattern)
        {
            FileInfo[] pliki = di.GetFiles();
            foreach (FileInfo fi in pliki)
            {
                if (fi.Name.Contains(pattern))
                {
                    listBox.Items.Add("Plik: " + fi.FullName + " czas utworzenia: " + fi.CreationTime + " rozmiar pliku: " + fi.Length);
                }
            }
            DirectoryInfo[] katalogi = di.GetDirectories();
            foreach (DirectoryInfo dirinfo in katalogi)
            {
                if (dirinfo.Name.Contains(pattern))
                {
                    listBox.Items.Add("Katalog: " + dirinfo.FullName + " czas utworzenia: " + dirinfo.CreationTime);
                }
                szukaj(dirinfo, pattern);
            }

        }
*/