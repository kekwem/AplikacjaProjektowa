
namespace aplikacjaProjecktowa
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox = new System.Windows.Forms.ListBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.szukajbutton = new System.Windows.Forms.Button();
            this.analizujbutton = new System.Windows.Forms.Button();
            this.katalogibutton = new System.Windows.Forms.Button();
            this.plikibutton = new System.Windows.Forms.Button();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.sortNameButton = new System.Windows.Forms.Button();
            this.sortDataButton = new System.Windows.Forms.Button();
            this.sortRozmiarButton = new System.Windows.Forms.Button();
            this.zliczanieButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 16;
            this.listBox.Location = new System.Drawing.Point(12, 72);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(1076, 484);
            this.listBox.TabIndex = 0;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(12, 35);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(1076, 22);
            this.searchTextBox.TabIndex = 1;
            // 
            // szukajbutton
            // 
            this.szukajbutton.Location = new System.Drawing.Point(1125, 34);
            this.szukajbutton.Name = "szukajbutton";
            this.szukajbutton.Size = new System.Drawing.Size(92, 23);
            this.szukajbutton.TabIndex = 2;
            this.szukajbutton.Text = "Szukaj";
            this.szukajbutton.UseVisualStyleBackColor = true;
            this.szukajbutton.Click += new System.EventHandler(this.szukajbutton_Click);
            // 
            // analizujbutton
            // 
            this.analizujbutton.Location = new System.Drawing.Point(1125, 72);
            this.analizujbutton.Name = "analizujbutton";
            this.analizujbutton.Size = new System.Drawing.Size(92, 23);
            this.analizujbutton.TabIndex = 3;
            this.analizujbutton.Text = "Ananlizuj";
            this.analizujbutton.UseVisualStyleBackColor = true;
            this.analizujbutton.Click += new System.EventHandler(this.analizujbutton_Click);
            // 
            // katalogibutton
            // 
            this.katalogibutton.Location = new System.Drawing.Point(1125, 111);
            this.katalogibutton.Name = "katalogibutton";
            this.katalogibutton.Size = new System.Drawing.Size(92, 23);
            this.katalogibutton.TabIndex = 4;
            this.katalogibutton.Text = "Katalogi";
            this.katalogibutton.UseVisualStyleBackColor = true;
            this.katalogibutton.Click += new System.EventHandler(this.katalogibutton_Click);
            // 
            // plikibutton
            // 
            this.plikibutton.Location = new System.Drawing.Point(1125, 151);
            this.plikibutton.Name = "plikibutton";
            this.plikibutton.Size = new System.Drawing.Size(92, 23);
            this.plikibutton.TabIndex = 5;
            this.plikibutton.Text = "Pliki";
            this.plikibutton.UseVisualStyleBackColor = true;
            this.plikibutton.Click += new System.EventHandler(this.plikibutton_Click);
            // 
            // sortNameButton
            // 
            this.sortNameButton.Location = new System.Drawing.Point(1125, 191);
            this.sortNameButton.Name = "sortNameButton";
            this.sortNameButton.Size = new System.Drawing.Size(92, 43);
            this.sortNameButton.TabIndex = 6;
            this.sortNameButton.Text = "Sort imiona";
            this.sortNameButton.UseVisualStyleBackColor = true;
            this.sortNameButton.Click += new System.EventHandler(this.sortNameButton_Click);
            // 
            // sortDataButton
            // 
            this.sortDataButton.Location = new System.Drawing.Point(1125, 249);
            this.sortDataButton.Name = "sortDataButton";
            this.sortDataButton.Size = new System.Drawing.Size(92, 43);
            this.sortDataButton.TabIndex = 7;
            this.sortDataButton.Text = "Sort daty";
            this.sortDataButton.UseVisualStyleBackColor = true;
            this.sortDataButton.Click += new System.EventHandler(this.sortDataButton_Click);
            // 
            // sortRozmiarButton
            // 
            this.sortRozmiarButton.Location = new System.Drawing.Point(1125, 375);
            this.sortRozmiarButton.Name = "sortRozmiarButton";
            this.sortRozmiarButton.Size = new System.Drawing.Size(92, 43);
            this.sortRozmiarButton.TabIndex = 8;
            this.sortRozmiarButton.Text = "Sort rozmiar";
            this.sortRozmiarButton.UseVisualStyleBackColor = true;
            this.sortRozmiarButton.Click += new System.EventHandler(this.sortRozmiarButton_Click);
            // 
            // zliczanieButton
            // 
            this.zliczanieButton.Location = new System.Drawing.Point(1125, 448);
            this.zliczanieButton.Name = "zliczanieButton";
            this.zliczanieButton.Size = new System.Drawing.Size(92, 61);
            this.zliczanieButton.TabIndex = 9;
            this.zliczanieButton.Text = "Zlicznie plikow po typu";
            this.zliczanieButton.UseVisualStyleBackColor = true;
            this.zliczanieButton.Click += new System.EventHandler(this.zliczanieButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1122, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tylko dla plikow";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Jaki katalog albo plik chcesz znalesz?";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 577);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zliczanieButton);
            this.Controls.Add(this.sortRozmiarButton);
            this.Controls.Add(this.sortDataButton);
            this.Controls.Add(this.sortNameButton);
            this.Controls.Add(this.plikibutton);
            this.Controls.Add(this.katalogibutton);
            this.Controls.Add(this.analizujbutton);
            this.Controls.Add(this.szukajbutton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.listBox);
            this.Name = "Form1";
            this.Text = "Pliki i katalogi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button szukajbutton;
        private System.Windows.Forms.Button analizujbutton;
        private System.Windows.Forms.Button katalogibutton;
        private System.Windows.Forms.Button plikibutton;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.Windows.Forms.Button sortNameButton;
        private System.Windows.Forms.Button sortDataButton;
        private System.Windows.Forms.Button sortRozmiarButton;
        private System.Windows.Forms.Button zliczanieButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

