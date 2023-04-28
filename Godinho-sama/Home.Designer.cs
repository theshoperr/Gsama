namespace Godinho_sama
{
    partial class Home
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.bar = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.minimizeBtn = new System.Windows.Forms.Button();
            this.maximizeBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.barDivision = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.dock = new System.Windows.Forms.Panel();
            this.mainShade = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.recentDock = new System.Windows.Forms.FlowLayoutPanel();
            this.recentDivision = new System.Windows.Forms.Panel();
            this.menu = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.forwardBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.settignsBtn = new System.Windows.Forms.Button();
            this.sideMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.favBtn = new System.Windows.Forms.Button();
            this.favDock = new System.Windows.Forms.FlowLayoutPanel();
            this.appBtn = new System.Windows.Forms.Button();
            this.appsDock = new System.Windows.Forms.FlowLayoutPanel();
            this.sideMenuHolder = new System.Windows.Forms.Panel();
            this.footer = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.footerDivision = new System.Windows.Forms.Panel();
            this.sideMenuDivision = new System.Windows.Forms.Panel();
            this.trayApp = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.dock.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menu.SuspendLayout();
            this.sideMenu.SuspendLayout();
            this.sideMenuHolder.SuspendLayout();
            this.footer.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // bar
            // 
            this.bar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(120)))), ((int)(((byte)(121)))));
            this.bar.Controls.Add(this.pictureBox1);
            this.bar.Controls.Add(this.minimizeBtn);
            this.bar.Controls.Add(this.maximizeBtn);
            this.bar.Controls.Add(this.closeBtn);
            this.bar.Controls.Add(this.barDivision);
            this.bar.Controls.Add(this.title);
            this.bar.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar.Location = new System.Drawing.Point(0, 0);
            this.bar.Name = "bar";
            this.bar.Size = new System.Drawing.Size(995, 26);
            this.bar.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Godinho_sama.Properties.Resources.Gsama_Logo;
            this.pictureBox1.Location = new System.Drawing.Point(6, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.minimizeBtn.FlatAppearance.BorderSize = 0;
            this.minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeBtn.ForeColor = System.Drawing.Color.White;
            this.minimizeBtn.Location = new System.Drawing.Point(911, 0);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(28, 26);
            this.minimizeBtn.TabIndex = 4;
            this.minimizeBtn.Text = "—";
            this.minimizeBtn.UseVisualStyleBackColor = true;
            this.minimizeBtn.Click += new System.EventHandler(this.Mini);
            // 
            // maximizeBtn
            // 
            this.maximizeBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.maximizeBtn.FlatAppearance.BorderSize = 0;
            this.maximizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximizeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maximizeBtn.ForeColor = System.Drawing.Color.White;
            this.maximizeBtn.Location = new System.Drawing.Point(939, 0);
            this.maximizeBtn.Name = "maximizeBtn";
            this.maximizeBtn.Size = new System.Drawing.Size(28, 26);
            this.maximizeBtn.TabIndex = 2;
            this.maximizeBtn.Text = "▢";
            this.maximizeBtn.UseVisualStyleBackColor = true;
            this.maximizeBtn.Click += new System.EventHandler(this.Max);
            // 
            // closeBtn
            // 
            this.closeBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.ForeColor = System.Drawing.Color.White;
            this.closeBtn.Location = new System.Drawing.Point(967, 0);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(28, 26);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.Text = "X";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.Fechar);
            // 
            // barDivision
            // 
            this.barDivision.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.barDivision.BackColor = System.Drawing.Color.White;
            this.barDivision.Location = new System.Drawing.Point(0, 25);
            this.barDivision.Name = "barDivision";
            this.barDivision.Size = new System.Drawing.Size(909, 1);
            this.barDivision.TabIndex = 0;
            // 
            // title
            // 
            this.title.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(29, -2);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(91, 26);
            this.title.TabIndex = 3;
            this.title.Text = "𝙶 𝚂 𝚊 𝚖 𝚊";
            // 
            // dock
            // 
            this.dock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            this.dock.Controls.Add(this.mainShade);
            this.dock.Controls.Add(this.label3);
            this.dock.Controls.Add(this.panel1);
            this.dock.Controls.Add(this.label1);
            this.dock.Controls.Add(this.groupBox1);
            this.dock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dock.Location = new System.Drawing.Point(205, 71);
            this.dock.Name = "dock";
            this.dock.Size = new System.Drawing.Size(790, 510);
            this.dock.TabIndex = 2;
            // 
            // mainShade
            // 
            this.mainShade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.mainShade.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainShade.Location = new System.Drawing.Point(0, 0);
            this.mainShade.Name = "mainShade";
            this.mainShade.Size = new System.Drawing.Size(790, 2);
            this.mainShade.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(175)))), ((int)(((byte)(175)))));
            this.label3.Location = new System.Drawing.Point(22, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 46);
            this.label3.TabIndex = 2;
            this.label3.Text = "𝚁𝚎𝚌𝚎𝚗𝚝 𝙰𝚙𝚙𝚜";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(120)))), ((int)(((byte)(121)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(204, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 63);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(52, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "𝚀𝚞𝚒𝚌𝚔 𝚜𝚑𝚘𝚛𝚝𝚌𝚞𝚝𝚜 𝚜𝚘𝚕𝚞𝚝𝚒𝚘𝚗";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 175F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(188)))), ((int)(((byte)(193)))));
            this.label1.Location = new System.Drawing.Point(-117, -71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(957, 265);
            this.label1.TabIndex = 0;
            this.label1.Text = "GSAMA";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.recentDock);
            this.groupBox1.Controls.Add(this.recentDivision);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(7, 269);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 229);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // recentDock
            // 
            this.recentDock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recentDock.Location = new System.Drawing.Point(3, 26);
            this.recentDock.Name = "recentDock";
            this.recentDock.Size = new System.Drawing.Size(770, 200);
            this.recentDock.TabIndex = 0;
            // 
            // recentDivision
            // 
            this.recentDivision.Dock = System.Windows.Forms.DockStyle.Top;
            this.recentDivision.Location = new System.Drawing.Point(3, 16);
            this.recentDivision.Name = "recentDivision";
            this.recentDivision.Size = new System.Drawing.Size(770, 10);
            this.recentDivision.TabIndex = 1;
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(69)))));
            this.menu.Controls.Add(this.button2);
            this.menu.Controls.Add(this.button1);
            this.menu.Controls.Add(this.forwardBtn);
            this.menu.Controls.Add(this.backBtn);
            this.menu.Controls.Add(this.settignsBtn);
            this.menu.Dock = System.Windows.Forms.DockStyle.Top;
            this.menu.Location = new System.Drawing.Point(0, 26);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(995, 45);
            this.menu.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(69)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::Godinho_sama.Properties.Resources.home_white;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(7, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 23);
            this.button2.TabIndex = 4;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.GoHome);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(69)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::Godinho_sama.Properties.Resources.plus_white;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(933, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 23);
            this.button1.TabIndex = 3;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.OpenCreate);
            // 
            // forwardBtn
            // 
            this.forwardBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.forwardBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(69)))));
            this.forwardBtn.FlatAppearance.BorderSize = 0;
            this.forwardBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.forwardBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forwardBtn.ForeColor = System.Drawing.Color.White;
            this.forwardBtn.Location = new System.Drawing.Point(119, 11);
            this.forwardBtn.Name = "forwardBtn";
            this.forwardBtn.Size = new System.Drawing.Size(28, 23);
            this.forwardBtn.TabIndex = 2;
            this.forwardBtn.Text = "▶";
            this.forwardBtn.UseVisualStyleBackColor = false;
            this.forwardBtn.Visible = false;
            this.forwardBtn.Click += new System.EventHandler(this.Next);
            // 
            // backBtn
            // 
            this.backBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.backBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(69)))));
            this.backBtn.FlatAppearance.BorderSize = 0;
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.ForeColor = System.Drawing.Color.White;
            this.backBtn.Location = new System.Drawing.Point(91, 11);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(28, 23);
            this.backBtn.TabIndex = 1;
            this.backBtn.Text = "◀";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Visible = false;
            this.backBtn.Click += new System.EventHandler(this.Previous);
            // 
            // settignsBtn
            // 
            this.settignsBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.settignsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(69)))));
            this.settignsBtn.FlatAppearance.BorderSize = 0;
            this.settignsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settignsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settignsBtn.ForeColor = System.Drawing.Color.White;
            this.settignsBtn.Image = global::Godinho_sama.Properties.Resources.gear_white;
            this.settignsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settignsBtn.Location = new System.Drawing.Point(962, 11);
            this.settignsBtn.Name = "settignsBtn";
            this.settignsBtn.Size = new System.Drawing.Size(25, 23);
            this.settignsBtn.TabIndex = 0;
            this.settignsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.settignsBtn.UseVisualStyleBackColor = false;
            this.settignsBtn.Click += new System.EventHandler(this.OpenSettings);
            // 
            // sideMenu
            // 
            this.sideMenu.AutoScroll = true;
            this.sideMenu.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.sideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(69)))));
            this.sideMenu.Controls.Add(this.favBtn);
            this.sideMenu.Controls.Add(this.favDock);
            this.sideMenu.Controls.Add(this.appBtn);
            this.sideMenu.Controls.Add(this.appsDock);
            this.sideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideMenu.Location = new System.Drawing.Point(0, 0);
            this.sideMenu.Name = "sideMenu";
            this.sideMenu.Size = new System.Drawing.Size(205, 510);
            this.sideMenu.TabIndex = 0;
            // 
            // favBtn
            // 
            this.favBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.favBtn.FlatAppearance.BorderSize = 0;
            this.favBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.favBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.favBtn.ForeColor = System.Drawing.Color.White;
            this.favBtn.Location = new System.Drawing.Point(3, 3);
            this.favBtn.Name = "favBtn";
            this.favBtn.Size = new System.Drawing.Size(187, 33);
            this.favBtn.TabIndex = 0;
            this.favBtn.Text = "Favourites ▴";
            this.favBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.favBtn.UseVisualStyleBackColor = true;
            this.favBtn.Click += new System.EventHandler(this.Favs);
            // 
            // favDock
            // 
            this.favDock.AutoSize = true;
            this.favDock.Dock = System.Windows.Forms.DockStyle.Top;
            this.favDock.Location = new System.Drawing.Point(196, 3);
            this.favDock.Name = "favDock";
            this.favDock.Size = new System.Drawing.Size(0, 0);
            this.favDock.TabIndex = 1;
            // 
            // appBtn
            // 
            this.appBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.appBtn.FlatAppearance.BorderSize = 0;
            this.appBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.appBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appBtn.ForeColor = System.Drawing.Color.White;
            this.appBtn.Location = new System.Drawing.Point(3, 42);
            this.appBtn.Name = "appBtn";
            this.appBtn.Size = new System.Drawing.Size(187, 33);
            this.appBtn.TabIndex = 2;
            this.appBtn.Text = "Apps ▴";
            this.appBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.appBtn.UseVisualStyleBackColor = true;
            this.appBtn.Click += new System.EventHandler(this.Apps);
            // 
            // appsDock
            // 
            this.appsDock.AutoSize = true;
            this.appsDock.Dock = System.Windows.Forms.DockStyle.Top;
            this.appsDock.Location = new System.Drawing.Point(196, 42);
            this.appsDock.Name = "appsDock";
            this.appsDock.Size = new System.Drawing.Size(0, 0);
            this.appsDock.TabIndex = 3;
            // 
            // sideMenuHolder
            // 
            this.sideMenuHolder.Controls.Add(this.footer);
            this.sideMenuHolder.Controls.Add(this.sideMenuDivision);
            this.sideMenuHolder.Controls.Add(this.sideMenu);
            this.sideMenuHolder.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideMenuHolder.Location = new System.Drawing.Point(0, 71);
            this.sideMenuHolder.Name = "sideMenuHolder";
            this.sideMenuHolder.Size = new System.Drawing.Size(205, 510);
            this.sideMenuHolder.TabIndex = 4;
            // 
            // footer
            // 
            this.footer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.footer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(69)))));
            this.footer.Controls.Add(this.label5);
            this.footer.Controls.Add(this.footerDivision);
            this.footer.Location = new System.Drawing.Point(0, 489);
            this.footer.Name = "footer";
            this.footer.Size = new System.Drawing.Size(205, 21);
            this.footer.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(4, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "𝙶𝚘𝚍𝚒𝚗𝚑𝚘 ▪ © 𝚠𝚠𝚠.𝚐𝚘𝚍𝚒𝚗𝚑𝚘.𝚠𝚘𝚛𝚔";
            // 
            // footerDivision
            // 
            this.footerDivision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.footerDivision.Dock = System.Windows.Forms.DockStyle.Top;
            this.footerDivision.Location = new System.Drawing.Point(0, 0);
            this.footerDivision.Name = "footerDivision";
            this.footerDivision.Size = new System.Drawing.Size(205, 1);
            this.footerDivision.TabIndex = 0;
            // 
            // sideMenuDivision
            // 
            this.sideMenuDivision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.sideMenuDivision.Location = new System.Drawing.Point(0, 0);
            this.sideMenuDivision.Name = "sideMenuDivision";
            this.sideMenuDivision.Size = new System.Drawing.Size(205, 1);
            this.sideMenuDivision.TabIndex = 0;
            // 
            // trayApp
            // 
            this.trayApp.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayApp.ContextMenuStrip = this.menuStrip;
            this.trayApp.Icon = ((System.Drawing.Icon)(resources.GetObject("trayApp.Icon")));
            this.trayApp.Text = "Gsama";
            this.trayApp.DoubleClick += new System.EventHandler(this.OpenFromTray);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openAppToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(181, 98);
            this.menuStrip.Text = "Gsama";
            // 
            // openAppToolStripMenuItem
            // 
            this.openAppToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.openAppToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(69)))));
            this.openAppToolStripMenuItem.Name = "openAppToolStripMenuItem";
            this.openAppToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openAppToolStripMenuItem.Text = "Open app";
            this.openAppToolStripMenuItem.ToolTipText = "Open back the app";
            this.openAppToolStripMenuItem.Click += new System.EventHandler(this.OpenFromTray);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(69)))));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.ToolTipText = "Close the app";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.HardClose);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(69)))));
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.ToolTipText = "Open the app directly into the settings menu";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsFromTray);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(995, 581);
            this.Controls.Add(this.dock);
            this.Controls.Add(this.sideMenuHolder);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.bar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Godinho-Sama";
            this.bar.ResumeLayout(false);
            this.bar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.dock.ResumeLayout(false);
            this.dock.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.menu.ResumeLayout(false);
            this.sideMenu.ResumeLayout(false);
            this.sideMenu.PerformLayout();
            this.sideMenuHolder.ResumeLayout(false);
            this.footer.ResumeLayout(false);
            this.footer.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bar;
        private System.Windows.Forms.Panel barDivision;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button maximizeBtn;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel dock;
        private System.Windows.Forms.Panel menu;
        private System.Windows.Forms.Button settignsBtn;
        private System.Windows.Forms.FlowLayoutPanel sideMenu;
        private System.Windows.Forms.Panel sideMenuHolder;
        private System.Windows.Forms.Panel sideMenuDivision;
        private System.Windows.Forms.Button forwardBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button minimizeBtn;
        private System.Windows.Forms.Button favBtn;
        private System.Windows.Forms.FlowLayoutPanel favDock;
        private System.Windows.Forms.Button appBtn;
        private System.Windows.Forms.FlowLayoutPanel appsDock;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel recentDock;
        private System.Windows.Forms.Panel recentDivision;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel footer;
        private System.Windows.Forms.Panel footerDivision;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NotifyIcon trayApp;
        private System.Windows.Forms.ContextMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem openAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel mainShade;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}

