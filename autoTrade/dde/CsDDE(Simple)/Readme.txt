作者： Kenming Wang  @2008/12/03
Email: kenming.wang@msa.hinet.net
Blog:  http://www.kenming.idv.tw/

參考我原來所寫的一篇：「[url="http://www.kenming.idv.tw/index.php?title=el_el_c_net_e_pcm_dde_server&more=1&c=1&tb=1&pb=1"]談談 C#.NET 連結 DDE Server 的設計觀[/url]」。 使用 [url="http://www.codeplex.com/ndde"]NDde[/url] 這個開放源碼，來包裹(Wrap) Win32 APIs 連結 DDE 的通訊底層，使得 .NET-based 的應用程式也可以很便利地連結 DDE Server。

利用幾天的時間，我寫了一個算是比較完整的 C# DDE 用戶端(Client)程式，可以確實連結國內券商所提供的看盤軟體(本身即是 DDE Server)。目前測過包括 "永豐金 eLeader", "元大 Yeswin", "日盛 HTS", "康合 全都賺" 等，均可以正常連結並依據連結項目(Item)持續顯示所跳動(Tick)的值(Value)。 這算是一個簡易的範本，旨在展示利用 .NET OOP 語言可以確實連結 Legacy DDE Server，並進而讓有心的程式交易人員，可以再行擴展，自行撰寫包括報表統計、技術線型分析等應用。

[img]http://farm4.static.flickr.com/3275/3079744820_349a08dd3f.jpg[/img]

我寫的這個簡單 DDE Client，基本功能如下：
　o 可以同時連結多個 DDE Server。
　o 可以同時顯示多個項目(Item)所持續跳動(Tick)的數值(Value)。
　o 可以正確顯示傳輸項目值為中文的編碼。
　o 可以任意地刪除 DDE 連線與項目 的相關資訊。


[size=4][red]簡單的源碼說明[/red][/size=4]

[size=3][b]DDE 的連線[/b][/size=3]
1. 看盤軟體本身即為 DDE Server！ 這點要先弄清楚。 所以看盤軟體連線至券商的報價伺服器，那是另外一回事，DDE Server 作得好不好，是與看盤軟體本身的穩定度與資源管理有關，而不是與遠端的報價伺服器有關。

2. 看盤軟體需不需要啟動 Excel？ 不需要的，Excel 本身就是 DDE 的用戶端(Client)，而且也因為 Excel 的關係，使得任一券商的看盤軟體，都必須符合能讓 Excel 這個用戶端正確地顯示資料。 這個有趣，是 Server 端必須符合 Client 端的傳輸規格，而且不能亂搞。 所以相對來說，對於程式開發人員自行要寫 DDE Client 程式來說，就不用擔心能不能正常顯示所傳輸過來的數值，要是有問題，肯定是自己寫的程式有問題，也方便自行 DEBUG。

3. DDE Client 要能新增一條 DDE 連線(Connection)，建立互動的 Conversation，需要有兩個資訊，一為 "Service"，另一為 "Topic"。 所以，所謂的一條 DDE Connection 定義為：
　　1 DDE Connection = 1 Service + 1 Topic

藉此也可以同時觀察，國內諸多看盤軟體他們對於所謂 DDE Connection 的實作方式。 例如 eLeader 是每一支股票代號即為一條 DDE 連線，所以，若要觀察前百大的期指成分股，就需要建立上百條的 DDE 連線；而 YesWin/康合全都賺等看盤軟體，則是所有金融商品都只建立一條 DDE 連線而已。 這與穩定度及效能是否有關？ 事實上，這應該是說牽涉到 DDE Server 內部關於 DDE 連線的資源控管(Resource Management)問題，一般來說，較為先進的應用伺服器(Application Server)，都會提供諸如 "Connection Pooling" 的機制，來有效達成伺服器內資源上的協調。

4. 連線很簡單，片段的程式碼參考如下：
[code]
DdeClient dc = new DdeClient(service, topic);
try{  
   // Connect to the server.  It must be running or an exception will be thrown.
   dc.Connect();
}catch (Exception thrown){
    MessageBox.Show("無法連結 DDE Server：" + thrown.Message);
}
[/code]

[size=3][b]向 DDE Server 索取資料[/b][/size=3]
　o 建立可以相互對話的連線後，該條連線即為 "Stateful" 的狀態，Client 與 Server 可以互相傳遞資料。 Client 端向 DDE Server 要求資料有包括 "Request(同步)", "OnBeginRequest(非同步)", "Advise(通告)" 等幾種方式。 對於看盤軟體來說，最必要的就是 "Advise" 這個要求了，當 Client 發出 "StartAdvise" 這個訊息後，DDE Server 爾後只要針對該項目的值一有變更時，就會通知已註冊的 Client 來取得變更的值。

至於另外兩種需求的訊息，"Poke" 是 Client 端主動送資料給 DDE Server；"Command" 是 Client 端發出命令要求 DDE Server 執行某個指令。 對於看盤軟體來說，是沒有使用到的，所以在我的源碼內，並沒有實作。

　o 國內幾個主要的看盤軟體，對於傳輸資料的實作，似乎有些差異 (但是在 Excel 都可以正常顯示)。 它們必然都有支援 "Advise" 這個訊息(Message)，所以才能爾後持續地取得跳動的值。但是，我發現到，YesWin/HTS 這兩個兩個看盤軟體，如果盤後停止跳動時，DDEClient 只利用 "Advise" 這個訊息要求資料的話，是無法取得資料的(但也沒有錯誤)；而相對 eLeader 與 全都賺來說，只利用這個訊息，就可以取得資料。前面說過，Excel 卻都是可以正常顯示的，所以，我後來才加上 "Request" 這個同步要求資料的訊息，才使得所有的看盤軟體都能顯示當停止跳動時，也能取得第一次的值。

衍生的一個小問題是，eLeader/全都賺 並沒有支持 "Request" 這個訊息的實作，所以若發出 "Request"，會出現錯誤。這裡我使用的一個小技巧就是，讓它 "throw" 一個例外錯誤(Exception)的事件(Event)，但捕捉(catch)了這個事件後，忽略並不處理它。

　o Client 端首先發出 "StartAdvise"，通告 DDE Server 準備要求索取資料。所帶的參數隻有一個，就是項目(Item)名稱。 至於 "Service", "Topic", "Item" 的名稱如何取得？一般只要從看盤軟體中，對某個表單的畫面欄位，右鍵 Excel DDE 複製到 Excel 中，即可察看到。

Client 端另外要做的一件事就是，註冊可以取得來自 DDE Server 所傳來事件(Event)的相關資訊，包括連線資訊與變動的資料等。 註冊的方式就是在 Client 端的程式碼內宣告並實作 Advise 的處理函式。部分的片段程式碼參考如下：
[code]
dc.Advise += client_Advise; //register the Advise process event.
dc.StartAdvise(item, 1, true, 60000);  // Advise Loop

private void client_Advise(object sender, DdeAdviseEventArgs args) {
   chg_value_row.Cells["col_iteminfo_value"].Value = args.Text;  //顯示變動後的 Item 值.
}
[/code]

　o 事實上，後來請生魚片測試時，才發現到，中文編碼有問題！ 我並沒有注意到，因為一般看盤軟體的數值都是純數字，但是 "康合 全都賺" 若要求如 期指的合約名稱，會傳回中文。 這裡相當感謝生魚片，他幫我解決了編碼傳輸的問題。 可以參考他寫的一篇：「在.NET正確顯示透過DDE傳送的文字編碼」。 所以在 client_Adivse() 這裡要改為：
[code]
private void client_Advise(object sender, DdeAdviseEventArgs args) {
   int codepage = Encoding.Default.CodePage;   //取得編碼的 codpage. 中文 Default: 950

   string data = Encoding.GetEncoding(codepage).GetString(args.Data, 0, args.Data.Length);
   chg_value_row.Cells["col_iteminfo_value"].Value = data;
}
[/code]

[size=3][b]UI 的實作問題[/b][/size=3]
老實說，真正困擾我的，是關於 UI 的實作，這對我可以說是相當陌生的。 UI 要能設計的好，大概有兩個重點， 一為對事件(Event)的控管處理，另一個就是如何讓 UI元件(Component)與所繫結(Binding)的一到多個資料源(Data Source)，並保持展示與資料變動的一致性。

在 Windows Form，大概就是 .NET 的 DataGridView 這個 UI 元件最為多樣變化了，如何與 資料源 "Binding" 在一起，維護展示與資料變動的一致性更是個學問。 目前我算是用 "硬作" 的方式，並沒有採取 "Auto Binding" 的自動同步，而是自己利用 HashTable，以 "Service+Topic", "Item" 當成主要的索引鍵(key)，來找出相關於 DDE Connection, DataGridView 所在變動列(或欲刪除列)的位置。

這裡我就是利用 DataGrideView 元件來展示連線與項目等相關資訊的。 一個 Connection 可以 "Hole" 住多個 Item, 所以必然是 "Master/Detail" 這樣的呈現。