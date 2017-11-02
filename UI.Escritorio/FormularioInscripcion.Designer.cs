namespace UI.Escritorio
{
    partial class FormularioInscripcion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLoguin = new System.Windows.Forms.Label();
            this.lblLoguinTexto = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblComision = new System.Windows.Forms.Label();
            this.cbbxComision = new System.Windows.Forms.ComboBox();
            this.comisionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tp2_netDataSet2 = new UI.Escritorio.tp2_netDataSet2();
            this.lblMateria = new System.Windows.Forms.Label();
            this.cbbxMateria = new System.Windows.Forms.ComboBox();
            this.materiasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tp2_netDataSet1 = new UI.Escritorio.tp2_netDataSet1();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.tp2_netDataSet = new UI.Escritorio.tp2_netDataSet();
            this.tp2netDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.materiasTableAdapter = new UI.Escritorio.tp2_netDataSet1TableAdapters.materiasTableAdapter();
            this.comisionesTableAdapter = new UI.Escritorio.tp2_netDataSet2TableAdapters.comisionesTableAdapter();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comisionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tp2_netDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tp2_netDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tp2_netDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tp2netDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.89723F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.10277F));
            this.tableLayoutPanel1.Controls.Add(this.lblLoguin, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLoguinTexto, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblComision, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbbxComision, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblMateria, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbbxMateria, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblID, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(37, 38);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(253, 196);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblLoguin
            // 
            this.lblLoguin.AutoSize = true;
            this.lblLoguin.Enabled = false;
            this.lblLoguin.Location = new System.Drawing.Point(3, 0);
            this.lblLoguin.Name = "lblLoguin";
            this.lblLoguin.Size = new System.Drawing.Size(93, 13);
            this.lblLoguin.TabIndex = 0;
            this.lblLoguin.Text = "Alumno Logueado";
            // 
            // lblLoguinTexto
            // 
            this.lblLoguinTexto.AutoSize = true;
            this.lblLoguinTexto.Location = new System.Drawing.Point(108, 0);
            this.lblLoguinTexto.Name = "lblLoguinTexto";
            this.lblLoguinTexto.Size = new System.Drawing.Size(0, 13);
            this.lblLoguinTexto.TabIndex = 5;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(3, 159);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Guardar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(108, 159);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // lblComision
            // 
            this.lblComision.AutoSize = true;
            this.lblComision.Location = new System.Drawing.Point(3, 117);
            this.lblComision.Name = "lblComision";
            this.lblComision.Size = new System.Drawing.Size(49, 13);
            this.lblComision.TabIndex = 2;
            this.lblComision.Text = "Comision";
            // 
            // cbbxComision
            // 
            this.cbbxComision.DataSource = this.comisionesBindingSource;
            this.cbbxComision.DisplayMember = "desc_comision";
            this.cbbxComision.FormattingEnabled = true;
            this.cbbxComision.Location = new System.Drawing.Point(108, 120);
            this.cbbxComision.Name = "cbbxComision";
            this.cbbxComision.Size = new System.Drawing.Size(121, 21);
            this.cbbxComision.TabIndex = 7;
            this.cbbxComision.ValueMember = "id_comision";
            // 
            // comisionesBindingSource
            // 
            this.comisionesBindingSource.DataMember = "comisiones";
            this.comisionesBindingSource.DataSource = this.tp2_netDataSet2;
            // 
            // tp2_netDataSet2
            // 
            this.tp2_netDataSet2.DataSetName = "tp2_netDataSet2";
            this.tp2_netDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblMateria
            // 
            this.lblMateria.AutoSize = true;
            this.lblMateria.Location = new System.Drawing.Point(3, 78);
            this.lblMateria.Name = "lblMateria";
            this.lblMateria.Size = new System.Drawing.Size(42, 13);
            this.lblMateria.TabIndex = 1;
            this.lblMateria.Text = "Materia";
            // 
            // cbbxMateria
            // 
            this.cbbxMateria.DataSource = this.materiasBindingSource;
            this.cbbxMateria.DisplayMember = "desc_materia";
            this.cbbxMateria.FormattingEnabled = true;
            this.cbbxMateria.Location = new System.Drawing.Point(108, 81);
            this.cbbxMateria.Name = "cbbxMateria";
            this.cbbxMateria.Size = new System.Drawing.Size(121, 21);
            this.cbbxMateria.TabIndex = 6;
            this.cbbxMateria.ValueMember = "id_materia";
            // 
            // materiasBindingSource
            // 
            this.materiasBindingSource.DataMember = "materias";
            this.materiasBindingSource.DataSource = this.tp2_netDataSet1;
            // 
            // tp2_netDataSet1
            // 
            this.tp2_netDataSet1.DataSetName = "tp2_netDataSet1";
            this.tp2_netDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(3, 39);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 8;
            this.lblID.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(108, 42);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 9;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // tp2_netDataSet
            // 
            this.tp2_netDataSet.DataSetName = "tp2_netDataSet";
            this.tp2_netDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tp2netDataSetBindingSource
            // 
            this.tp2netDataSetBindingSource.DataSource = this.tp2_netDataSet;
            this.tp2netDataSetBindingSource.Position = 0;
            // 
            // materiasTableAdapter
            // 
            this.materiasTableAdapter.ClearBeforeFill = true;
            // 
            // comisionesTableAdapter
            // 
            this.comisionesTableAdapter.ClearBeforeFill = true;
            // 
            // FormularioInscripcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 279);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormularioInscripcion";
            this.Text = "FormularioInscripcion";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comisionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tp2_netDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tp2_netDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tp2_netDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tp2netDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblLoguin;
        private System.Windows.Forms.Label lblMateria;
        private System.Windows.Forms.Label lblComision;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblLoguinTexto;
        private System.Windows.Forms.ComboBox cbbxMateria;
        private System.Windows.Forms.ComboBox cbbxComision;
        private tp2_netDataSet tp2_netDataSet;
        private System.Windows.Forms.BindingSource tp2netDataSetBindingSource;
        private tp2_netDataSet1 tp2_netDataSet1;
        private System.Windows.Forms.BindingSource materiasBindingSource;
        private tp2_netDataSet1TableAdapters.materiasTableAdapter materiasTableAdapter;
        private tp2_netDataSet2 tp2_netDataSet2;
        private System.Windows.Forms.BindingSource comisionesBindingSource;
        private tp2_netDataSet2TableAdapters.comisionesTableAdapter comisionesTableAdapter;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
    }
}