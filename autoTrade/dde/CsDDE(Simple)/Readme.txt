�@�̡G Kenming Wang  @2008/12/03
Email: kenming.wang@msa.hinet.net
Blog:  http://www.kenming.idv.tw/

�Ѧҧڭ�өҼg���@�g�G�u[url="http://www.kenming.idv.tw/index.php?title=el_el_c_net_e_pcm_dde_server&more=1&c=1&tb=1&pb=1"]�ͽ� C#.NET �s�� DDE Server ���]�p�[[/url]�v�C �ϥ� [url="http://www.codeplex.com/ndde"]NDde[/url] �o�Ӷ}�񷽽X�A�ӥ]�q(Wrap) Win32 APIs �s�� DDE ���q�T���h�A�ϱo .NET-based �����ε{���]�i�H�ܫK�Q�a�s�� DDE Server�C

�Q�δX�Ѫ��ɶ��A�ڼg�F�@�Ӻ�O������㪺 C# DDE �Τ��(Client)�{���A�i�H�T��s���ꤺ��өҴ��Ѫ��ݽL�n��(�����Y�O DDE Server)�C�ثe���L�]�A "���ת� eLeader", "���j Yeswin", "�鲱 HTS", "�d�X ������" ���A���i�H���`�s���è̾ڳs������(Item)������ܩҸ���(Tick)����(Value)�C �o��O�@��²�����d���A���b�i�ܧQ�� .NET OOP �y���i�H�T��s�� Legacy DDE Server�A�öi�������ߪ��{������H���A�i�H�A���X�i�A�ۦ漶�g�]�A����έp�B�޳N�u�����R�����ΡC

[img]http://farm4.static.flickr.com/3275/3079744820_349a08dd3f.jpg[/img]

�ڼg���o��²�� DDE Client�A�򥻥\��p�U�G
�@o �i�H�P�ɳs���h�� DDE Server�C
�@o �i�H�P����ܦh�Ӷ���(Item)�ҫ������(Tick)���ƭ�(Value)�C
�@o �i�H���T��ܶǿ鶵�حȬ����媺�s�X�C
�@o �i�H���N�a�R�� DDE �s�u�P���� ��������T�C


[size=4][red]²�檺���X����[/red][/size=4]

[size=3][b]DDE ���s�u[/b][/size=3]
1. �ݽL�n�饻���Y�� DDE Server�I �o�I�n���˲M���C �ҥH�ݽL�n��s�u�ܨ�Ӫ��������A���A���O�t�~�@�^�ơADDE Server �@�o�n���n�A�O�P�ݽL�n�饻����í�w�׻P�귽�޲z�����A�Ӥ��O�P���ݪ��������A�������C

2. �ݽL�n��ݤ��ݭn�Ұ� Excel�H ���ݭn���AExcel �����N�O DDE ���Τ��(Client)�A�ӥB�]�]�� Excel �����Y�A�ϱo���@��Ӫ��ݽL�n��A�������ŦX���� Excel �o�ӥΤ�ݥ��T�a��ܸ�ơC �o�Ӧ���A�O Server �ݥ����ŦX Client �ݪ��ǿ�W��A�ӥB����÷d�C �ҥH�۹�ӻ��A���{���}�o�H���ۦ�n�g DDE Client �{���ӻ��A�N���ξ�߯ण�ॿ�`��ܩҶǿ�L�Ӫ��ƭȡA�n�O�����D�A�֩w�O�ۤv�g���{�������D�A�]��K�ۦ� DEBUG�C

3. DDE Client �n��s�W�@�� DDE �s�u(Connection)�A�إߤ��ʪ� Conversation�A�ݭn����Ӹ�T�A�@�� "Service"�A�t�@�� "Topic"�C �ҥH�A�ҿת��@�� DDE Connection �w�q���G
�@�@1 DDE Connection = 1 Service + 1 Topic

�Ǧ��]�i�H�P���[��A�ꤺ�Ѧh�ݽL�n��L�̹��ҿ� DDE Connection ����@�覡�C �Ҧp eLeader �O�C�@��Ѳ��N���Y���@�� DDE �s�u�A�ҥH�A�Y�n�[��e�ʤj�����������ѡA�N�ݭn�إߤW�ʱ��� DDE �s�u�F�� YesWin/�d�X�����ȵ��ݽL�n��A�h�O�Ҧ����İӫ~���u�إߤ@�� DDE �s�u�Ӥw�C �o�Pí�w�פήį�O�_�����H �ƹ�W�A�o���ӬO���o�A�� DDE Server �������� DDE �s�u���귽����(Resource Management)���D�A�@��ӻ��A�������i�����Φ��A��(Application Server)�A���|���ѽѦp "Connection Pooling" ������A�Ӧ��ĹF�����A�����귽�W����աC

4. �s�u��²��A���q���{���X�ѦҦp�U�G
[code]
DdeClient dc = new DdeClient(service, topic);
try{  
   // Connect to the server.  It must be running or an exception will be thrown.
   dc.Connect();
}catch (Exception thrown){
    MessageBox.Show("�L�k�s�� DDE Server�G" + thrown.Message);
}
[/code]

[size=3][b]�V DDE Server �������[/b][/size=3]
�@o �إߥi�H�ۤ���ܪ��s�u��A�ӱ��s�u�Y�� "Stateful" �����A�AClient �P Server �i�H���۶ǻ���ơC Client �ݦV DDE Server �n�D��Ʀ��]�A "Request(�P�B)", "OnBeginRequest(�D�P�B)", "Advise(�q�i)" ���X�ؤ覡�C ���ݽL�n��ӻ��A�̥��n���N�O "Advise" �o�ӭn�D�F�A�� Client �o�X "StartAdvise" �o�ӰT����ADDE Server ����u�n�w��Ӷ��ت��Ȥ@���ܧ�ɡA�N�|�q���w���U�� Client �Ө��o�ܧ󪺭ȡC

�ܩ�t�~��ػݨD���T���A"Poke" �O Client �ݥD�ʰe��Ƶ� DDE Server�F"Command" �O Client �ݵo�X�R�O�n�D DDE Server ����Y�ӫ��O�C ���ݽL�n��ӻ��A�O�S���ϥΨ쪺�A�ҥH�b�ڪ����X���A�èS����@�C

�@o �ꤺ�X�ӥD�n���ݽL�n��A���ǿ��ƪ���@�A���G���Ǯt�� (���O�b Excel ���i�H���`���)�C ���̥��M�����䴩 "Advise" �o�ӰT��(Message)�A�ҥH�~�ຸ�����a���o���ʪ��ȡC���O�A�ڵo�{��AYesWin/HTS �o��Ө�ӬݽL�n��A�p�G�L�ᰱ����ʮɡADDEClient �u�Q�� "Advise" �o�ӰT���n�D��ƪ��ܡA�O�L�k���o��ƪ�(���]�S�����~)�F�Ӭ۹� eLeader �P �����Ȩӻ��A�u�Q�γo�ӰT���A�N�i�H���o��ơC�e�����L�AExcel �o���O�i�H���`��ܪ��A�ҥH�A�ګ�Ӥ~�[�W "Request" �o�ӦP�B�n�D��ƪ��T���A�~�ϱo�Ҧ����ݽL�n�鳣����ܷ�����ʮɡA�]����o�Ĥ@�����ȡC

�l�ͪ��@�Ӥp���D�O�AeLeader/������ �èS����� "Request" �o�ӰT������@�A�ҥH�Y�o�X "Request"�A�|�X�{���~�C�o�̧ڨϥΪ��@�Ӥp�ޥ��N�O�A���� "throw" �@�Өҥ~���~(Exception)���ƥ�(Event)�A������(catch)�F�o�Өƥ��A�����ä��B�z���C

�@o Client �ݭ����o�X "StartAdvise"�A�q�i DDE Server �ǳƭn�D������ơC�ұa���Ѽư����@�ӡA�N�O����(Item)�W�١C �ܩ� "Service", "Topic", "Item" ���W�٦p����o�H�@��u�n�q�ݽL�n�餤�A��Y�Ӫ�檺�e�����A�k�� Excel DDE �ƻs�� Excel ���A�Y�i��ݨ�C

Client �ݥt�~�n�����@��ƴN�O�A���U�i�H���o�Ӧ� DDE Server �ҶǨӨƥ�(Event)��������T�A�]�A�s�u��T�P�ܰʪ���Ƶ��C ���U���覡�N�O�b Client �ݪ��{���X���ŧi�ù�@ Advise ���B�z�禡�C���������q�{���X�ѦҦp�U�G
[code]
dc.Advise += client_Advise; //register the Advise process event.
dc.StartAdvise(item, 1, true, 60000);  // Advise Loop

private void client_Advise(object sender, DdeAdviseEventArgs args) {
   chg_value_row.Cells["col_iteminfo_value"].Value = args.Text;  //����ܰʫ᪺ Item ��.
}
[/code]

�@o �ƹ�W�A��ӽХͳ������ծɡA�~�o�{��A����s�X�����D�I �ڨèS���`�N��A�]���@��ݽL�n�骺�ƭȳ��O�¼Ʀr�A���O "�d�X ������" �Y�n�D�p �������X���W�١A�|�Ǧ^����C �o�̬۷�P�¥ͳ����A�L���ڸѨM�F�s�X�ǿ骺���D�C �i�H�ѦҥL�g���@�g�G�u�b.NET���T��ܳz�LDDE�ǰe����r�s�X�v�C �ҥH�b client_Adivse() �o�̭n�אּ�G
[code]
private void client_Advise(object sender, DdeAdviseEventArgs args) {
   int codepage = Encoding.Default.CodePage;   //���o�s�X�� codpage. ���� Default: 950

   string data = Encoding.GetEncoding(codepage).GetString(args.Data, 0, args.Data.Length);
   chg_value_row.Cells["col_iteminfo_value"].Value = data;
}
[/code]

[size=3][b]UI ����@���D[/b][/size=3]
�ѹ껡�A�u���x�Z�ڪ��A�O���� UI ����@�A�o��ڥi�H���O�۷��ͪ��C UI �n��]�p���n�A�j������ӭ��I�A �@����ƥ�(Event)�����޳B�z�A�t�@�ӴN�O�p���� UI����(Component)�P��ô��(Binding)���@��h�Ӹ�Ʒ�(Data Source)�A�ëO���i�ܻP����ܰʪ��@�P�ʡC

�b Windows Form�A�j���N�O .NET �� DataGridView �o�� UI ����̬��h���ܤƤF�A�p��P ��Ʒ� "Binding" �b�@�_�A���@�i�ܻP����ܰʪ��@�P�ʧ�O�ӾǰݡC �ثe�ں�O�� "�w�@" ���覡�A�èS���Ĩ� "Auto Binding" ���۰ʦP�B�A�ӬO�ۤv�Q�� HashTable�A�H "Service+Topic", "Item" ���D�n��������(key)�A�ӧ�X������ DDE Connection, DataGridView �Ҧb�ܰʦC(�α��R���C)����m�C

�o�̧ڴN�O�Q�� DataGrideView ����Ӯi�ܳs�u�P���ص�������T���C �@�� Connection �i�H "Hole" ��h�� Item, �ҥH���M�O "Master/Detail" �o�˪��e�{�C