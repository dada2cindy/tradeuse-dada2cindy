using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NDde.Client;

namespace CsDDE_Simple_
{
    public partial class DDEClientFrm : Form
    {
        private Hashtable ht_conn;   //保存以 (連線字串) 為 key; 所建立的 DdeClient instance 為 object.
        //private Hashtable ht_item;    //保存以 (連線字串+項目名稱) 為 key; 項目值為 object
        private Hashtable ht_gdv;    // 保存以 (連線字串+項目名稱) 為 key;  DataGridViewRow 為 object.
        
        public DDEClientFrm()
        {
            InitializeComponent();
            ht_conn = new Hashtable();
            //ht_item  = new Hashtable();
            ht_gdv   = new Hashtable();
        }

        private void DDEClientFrm_Load(object sender, EventArgs e)
        {
        }

        /** 新增 DDE連線 的事件處理
         * 
         */
        private void btnAddConnect_Click(object sender, EventArgs e)
        {  
           if (ht_conn.ContainsKey(txtService.Text + "|" + txtTopic.Text))
           {
               MessageBox.Show("連線字串不能重覆！");
               return;
           }
           DdeClient dc = new DdeClient(txtService.Text, txtTopic.Text);
           //register the event handler            
           dc.Disconnected += client_Disconnected;
           dc.Advise += client_Advise;
           try
           {  
                // Connect to the server.  It must be running or an exception will be thrown.
                dc.Connect();
                
                dgConnection.Rows.Add(txtService.Text, txtTopic.Text, "已連線");

               //利用 "service|topic" 為 HashTable 的 Key; DdeClient 為 Object.
                string key = txtService.Text + "|" + txtTopic.Text;
                ht_conn.Add(key, dc); 
            }
            catch (Exception thrown)
            {
               MessageBox.Show("無法連結 DDE Server：" + thrown.Message);
             }
         }

        // 按下 dgConnection(DataGridView) Cell 後的事件處理
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells. 
            if (e.RowIndex < 0 || (e.ColumnIndex !=
                dgConnection.Columns["col_remove_conn"].Index && e.ColumnIndex !=
                dgConnection.Columns["col_btn_add_item"].Index))
                return;

            //判斷 dgv 內的按鈕名稱
            if (dgConnection.Columns[e.ColumnIndex].Name.Equals("col_remove_conn"))
            {
                this.Remove_Connect_and_Item_Row(e.RowIndex);
            }
            else if (dgConnection.Columns[e.ColumnIndex].Name.Equals("col_btn_add_item"))
            {
                if (txt_item.Text == "")
                {
                    MessageBox.Show("項目(Item)不能為空！");
                }
                else
                { 
                    //新增 gdItemInfo Row
                    //取得新增按鈕按下時所在的列(row)
                    DataGridViewRow curr_row = dgConnection.Rows[e.RowIndex];
                    //取得該列的連線字串, 並以該字串為 key, 找出對應的 DdeClient instance.
                    string key = curr_row.Cells["col_service"].Value.ToString() + "|" + curr_row.Cells["col_topic"].Value.ToString();
                    DdeClient dc = (DdeClient)ht_conn[key];
                    string item = txt_item.Text;              
      
                    this.AddItem(dc, item);    //新增 Item
                }
            }
        }

        /** 新增項目(Item), 並取得該項目的值(Value)
         *   1. 呼叫 DdeClient 的 "Request()" & "StartAdvise" 取得該 Item 的值
         *   2. 利用 service|topic!item 字串為 key
         *   2.1 ht_gdv(HashTable) -> (key, DataGridViewRow)
         *   3. 在 dgItemInfo(DataGridView)新增一列, 顯示項目相關資訊
         *   
         *   <param name="dc">     "新增項目" 按鈕事件所在列對應的 DdeClient
         *   <param name="item"> "新增項目" 名稱(Name)
         */
        private void AddItem(DdeClient dc, string item)
        {
            try
            {
                string key = dc.Service + "|" + dc.Topic + "!" + item;

                Item it = new Item();
                it.item = item; it.value = "";

                try
                {
                    //Synchronous Request Operation, 用以取得第一次呼叫的值
                    //eLeader, 康和 並未支援同步呼叫; yeswin/hts 則有支援
                    byte[] data = dc.Request(item, 1, 60000);
                    int codepage = Encoding.Default.CodePage;   //取得編碼的 codpage. 中文 Default: 950
                    string value = Encoding.GetEncoding(codepage).GetString(data, 0, data.Length);
                    //it.value = Encoding.ASCII.GetString(data);
                    it.value = value;
                }
                catch (Exception )
                {                    
                    ;  //忽略該錯誤
                }

                // Advise Loop
                dc.StartAdvise(item, 1, true, 60000);

                //Add a Row
                int idx = dgItemInfo.Rows.Add(dc.Service, dc.Topic, item, it.value);
                //保存 key 與 所在新增 Row
                ht_gdv.Add(key, dgItemInfo.Rows[idx]);
            }
            catch (Exception thrown)
            {
                MessageBox.Show("無法新增項目： \n" + thrown.Message);
            }
        }

        /** 移除所在連線資訊列(row)相關連線資訊與所關聯的項目(item)資訊
         *    <param = row_idx> dgView1 移除按鈕事件所在列的位置
         */
        private void Remove_Connect_and_Item_Row(int row_idx)
        {
            /** 確定為 "移除按鈕" 後的處理
            *   1. 刪除 HashTable 內的 key/value, 以及 DdeClient instance
            *   2. 將該列(row)從 dgConnection(DataGridView) 移除。
            */

            //取得移除按鈕按下時所在的列(row)
            DataGridViewRow del_row = dgConnection.Rows[row_idx];
            //取得刪除列的欄位(col_service, col_topic)值當成 key, 以取出所對應的 DdeClient 連線 instance.
            string key = del_row.Cells["col_service"].Value.ToString() + "|" + del_row.Cells["col_topic"].Value.ToString();
            DdeClient client_conn = (DdeClient)ht_conn[key];

            //利用 連線字串(service+topic) 為 key, 刪除相關聯(1到多) dgItemInfo 所在的 Item 列
            ArrayList list = new ArrayList();  //暫存欲刪除的 Item Key.
            foreach (DictionaryEntry de1 in ht_gdv)
            {
                //取出 "!" 前面的字串 (service|topic)
                string item_key = de1.Key.ToString();
                string item_key_substr = item_key.Substring(0, item_key.IndexOf("!"));

                //每一個欲刪除的 Item, 需先呼叫 DdeClient.StopAdvise
                if (key.Equals(item_key_substr))
                {
                    DataGridViewRow del_item_row = (DataGridViewRow)de1.Value;
                    string item = del_item_row.Cells["col_iteminfo_Item"].Value.ToString();
                    this.Stop_advise(client_conn, item);
                    list.Add(item_key);  
                }
            }

            //實際刪除 Item 所在的 DataGridView Row, 以及移除儲存在 HashTable 的 key/value
            foreach (string str_key in list)
            {
                DataGridViewRow del_item_row = (DataGridViewRow)ht_gdv[str_key];
                ht_gdv.Remove(str_key);
                dgItemInfo.Rows.Remove(del_item_row);
            }

            //刪除所儲存連線資訊的 key/value, 以及將該 DdeClient 連線移除。
            ht_conn.Remove(key);
            client_conn.Dispose();

            //將所在的連線資料列刪除掉
            dgConnection.Rows.RemoveAt(row_idx);
        }

        // 按下 dgItemInfo(DataGridView) Cell 後的事件處理
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells. 
            if (e.RowIndex < 0 || e.ColumnIndex !=
                dgItemInfo.Columns["col_iteminfo_btn_delete"].Index) return;

            //取得移除按鈕按下時所在的列(row)
            DataGridViewRow del_row = dgItemInfo.Rows[e.RowIndex];
            //取得該列欄位的 service, topic, item 字串值
            string service_topic = del_row.Cells["col_iteminfo_service"].Value.ToString() + "|" + del_row.Cells["col_iteminfo_topic"].Value.ToString();
            string item = del_row.Cells["col_iteminfo_Item"].Value.ToString();
            
            //Get DdeClient connection.
            DdeClient dc = (DdeClient)ht_conn[service_topic];
            
            //Stop Advise.
            this.Stop_advise(dc, item);

            //移除該列並從 HashTable 也一併移除所對應的 key/value.
            string service_topic_item = service_topic + "!" + item;
            DataGridViewRow del_item_row = (DataGridViewRow)ht_gdv[service_topic_item];
            ht_gdv.Remove(service_topic_item);
            dgItemInfo.Rows.Remove(del_item_row);
        }

        //Stop Advise
        private void Stop_advise(DdeClient dc, string item)
        {
            try
            {
                dc.StopAdvise(item, 60000);
            }
            catch (Exception thrown)
            {
                MessageBox.Show("Can not Stop Advise: \n" + thrown.Message);
            }
        }

        private void client_Advise(object sender, DdeAdviseEventArgs args)
        {
            DdeClient dc = (DdeClient)sender;
            string key = dc.Service + "|" + dc.Topic + "!" + args.Item;
            //取得 key 所對應位置的 DataGridViewRow
            DataGridViewRow chg_value_row = (DataGridViewRow)ht_gdv[key];
            
            //將變動的值指定至該列所在的欄位 "Item_Value"
            int codepage = Encoding.Default.CodePage;   //取得編碼的 codpage. 中文 Default: 950
            string data = Encoding.GetEncoding(codepage).GetString(args.Data, 0, args.Data.Length);

            //顯示變動後的 Item 值.
            chg_value_row.Cells["col_iteminfo_value"].Value = data;
        }

        private void client_Disconnected(object sender, DdeDisconnectedEventArgs args)
        {
            string msg =
                "OnDisconnected: " +
                "IsServerInitiated=" + args.IsServerInitiated.ToString() + " " +
                "IsDisposed=" + args.IsDisposed.ToString();
            //可實做將該訊息顯示在 StatusBar 上.
        }
    }
}
