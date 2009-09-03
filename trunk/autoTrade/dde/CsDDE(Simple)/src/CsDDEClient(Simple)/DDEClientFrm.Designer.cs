using System;
using System.Drawing;
using System.Windows.Forms;

namespace CsDDE_Simple_
{
    partial class DDEClientFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtService = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTopic = new System.Windows.Forms.TextBox();
            this.btnAddConnect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgConnection = new System.Windows.Forms.DataGridView();
            this.col_service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_topic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_connect_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_remove_conn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_btn_add_item = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_item = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgItemInfo = new System.Windows.Forms.DataGridView();
            this.col_iteminfo_service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_iteminfo_topic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_iteminfo_Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_iteminfo_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_iteminfo_btn_delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgConnection)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItemInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Service";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtService
            // 
            this.txtService.Font = new System.Drawing.Font("PMingLiU", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtService.Location = new System.Drawing.Point(77, 18);
            this.txtService.Name = "txtService";
            this.txtService.Size = new System.Drawing.Size(129, 23);
            this.txtService.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(238, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Topic";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTopic
            // 
            this.txtTopic.Font = new System.Drawing.Font("PMingLiU", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtTopic.Location = new System.Drawing.Point(290, 17);
            this.txtTopic.Name = "txtTopic";
            this.txtTopic.Size = new System.Drawing.Size(138, 23);
            this.txtTopic.TabIndex = 3;
            // 
            // btnAddConnect
            // 
            this.btnAddConnect.Font = new System.Drawing.Font("PMingLiU", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAddConnect.Location = new System.Drawing.Point(459, 17);
            this.btnAddConnect.Name = "btnAddConnect";
            this.btnAddConnect.Size = new System.Drawing.Size(101, 24);
            this.btnAddConnect.TabIndex = 4;
            this.btnAddConnect.Text = "新增連線";
            this.btnAddConnect.UseVisualStyleBackColor = true;
            this.btnAddConnect.Click += new System.EventHandler(this.btnAddConnect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddConnect);
            this.groupBox1.Controls.Add(this.txtTopic);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtService);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DDE 連結設定";
            // 
            // dgConnection
            // 
            this.dgConnection.AllowUserToAddRows = false;
            this.dgConnection.AllowUserToDeleteRows = false;
            this.dgConnection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgConnection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_service,
            this.col_topic,
            this.col_connect_status,
            this.col_remove_conn,
            this.col_btn_add_item});
            this.dgConnection.Location = new System.Drawing.Point(6, 21);
            this.dgConnection.MultiSelect = false;
            this.dgConnection.Name = "dgConnection";
            this.dgConnection.ReadOnly = true;
            this.dgConnection.RowHeadersVisible = false;
            this.dgConnection.RowTemplate.Height = 24;
            this.dgConnection.Size = new System.Drawing.Size(465, 193);
            this.dgConnection.TabIndex = 9;
            this.dgConnection.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // col_service
            // 
            this.col_service.HeaderText = "Service";
            this.col_service.Name = "col_service";
            this.col_service.ReadOnly = true;
            // 
            // col_topic
            // 
            this.col_topic.HeaderText = "Topic";
            this.col_topic.Name = "col_topic";
            this.col_topic.ReadOnly = true;
            // 
            // col_connect_status
            // 
            this.col_connect_status.HeaderText = "連線狀態";
            this.col_connect_status.Name = "col_connect_status";
            this.col_connect_status.ReadOnly = true;
            // 
            // col_remove_conn
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.col_remove_conn.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_remove_conn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.col_remove_conn.HeaderText = "";
            this.col_remove_conn.Name = "col_remove_conn";
            this.col_remove_conn.ReadOnly = true;
            this.col_remove_conn.Text = "移除";
            this.col_remove_conn.UseColumnTextForButtonValue = true;
            this.col_remove_conn.Width = 60;
            // 
            // col_btn_add_item
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.col_btn_add_item.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_btn_add_item.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.col_btn_add_item.HeaderText = "";
            this.col_btn_add_item.Name = "col_btn_add_item";
            this.col_btn_add_item.ReadOnly = true;
            this.col_btn_add_item.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_btn_add_item.Text = "新增項目";
            this.col_btn_add_item.UseColumnTextForButtonValue = true;
            this.col_btn_add_item.Width = 80;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txt_item);
            this.groupBox2.Controls.Add(this.dgConnection);
            this.groupBox2.Location = new System.Drawing.Point(0, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(595, 224);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DDE 連線資訊";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(477, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "ITEM (項目)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_item
            // 
            this.txt_item.Location = new System.Drawing.Point(477, 43);
            this.txt_item.Name = "txt_item";
            this.txt_item.Size = new System.Drawing.Size(112, 22);
            this.txt_item.TabIndex = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgItemInfo);
            this.groupBox3.Location = new System.Drawing.Point(0, 295);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(575, 281);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DDE 項目資訊";
            // 
            // dgItemInfo
            // 
            this.dgItemInfo.AllowUserToAddRows = false;
            this.dgItemInfo.AllowUserToDeleteRows = false;
            this.dgItemInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItemInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_iteminfo_service,
            this.col_iteminfo_topic,
            this.col_iteminfo_Item,
            this.col_iteminfo_value,
            this.col_iteminfo_btn_delete});
            this.dgItemInfo.Location = new System.Drawing.Point(6, 21);
            this.dgItemInfo.MultiSelect = false;
            this.dgItemInfo.Name = "dgItemInfo";
            this.dgItemInfo.ReadOnly = true;
            this.dgItemInfo.RowHeadersVisible = false;
            this.dgItemInfo.RowTemplate.Height = 24;
            this.dgItemInfo.Size = new System.Drawing.Size(490, 248);
            this.dgItemInfo.TabIndex = 0;
            this.dgItemInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // col_iteminfo_service
            // 
            this.col_iteminfo_service.HeaderText = "Service";
            this.col_iteminfo_service.Name = "col_iteminfo_service";
            this.col_iteminfo_service.ReadOnly = true;
            // 
            // col_iteminfo_topic
            // 
            this.col_iteminfo_topic.HeaderText = "Topic";
            this.col_iteminfo_topic.Name = "col_iteminfo_topic";
            this.col_iteminfo_topic.ReadOnly = true;
            // 
            // col_iteminfo_Item
            // 
            this.col_iteminfo_Item.HeaderText = "Item";
            this.col_iteminfo_Item.Name = "col_iteminfo_Item";
            this.col_iteminfo_Item.ReadOnly = true;
            // 
            // col_iteminfo_value
            // 
            this.col_iteminfo_value.HeaderText = "Value";
            this.col_iteminfo_value.Name = "col_iteminfo_value";
            this.col_iteminfo_value.ReadOnly = true;
            // 
            // col_iteminfo_btn_delete
            // 
            this.col_iteminfo_btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.col_iteminfo_btn_delete.HeaderText = "";
            this.col_iteminfo_btn_delete.Name = "col_iteminfo_btn_delete";
            this.col_iteminfo_btn_delete.ReadOnly = true;
            this.col_iteminfo_btn_delete.Text = "刪除";
            this.col_iteminfo_btn_delete.UseColumnTextForButtonValue = true;
            this.col_iteminfo_btn_delete.Width = 60;
            // 
            // DDEClientFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 616);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "DDEClientFrm";
            this.Text = "CSharp DDE Client Monitor";
            this.Load += new System.EventHandler(this.DDEClientFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgConnection)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgItemInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private TextBox txtService;
        private Label label2;
        private TextBox txtTopic;
        private Button btnAddConnect;
        private GroupBox groupBox1;
        private DataGridView dgConnection;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label3;
        private TextBox txt_item;
        private DataGridViewTextBoxColumn col_service;
        private DataGridViewTextBoxColumn col_topic;
        private DataGridViewTextBoxColumn col_connect_status;
        private DataGridViewButtonColumn col_remove_conn;
        private DataGridViewButtonColumn col_btn_add_item;
        private DataGridView dgItemInfo;
        private DataGridViewTextBoxColumn col_iteminfo_service;
        private DataGridViewTextBoxColumn col_iteminfo_topic;
        private DataGridViewTextBoxColumn col_iteminfo_Item;
        private DataGridViewTextBoxColumn col_iteminfo_value;
        private DataGridViewButtonColumn col_iteminfo_btn_delete;

    }
}

