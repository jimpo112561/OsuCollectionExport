using CollectionManager.DataTypes;
using CollectionManager.Modules.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace 收藏夾匯出工具
{
    public partial class Form1 : Form
    {
        string osuPath; Collections collections;
        public OsuFileIo osuFileIo = new OsuFileIo(new BeatmapExtension());

        public Form1()
        {
            InitializeComponent();

            osuPath = OsuPathResolver.Instance.GetOsuDir((path) => {
                var dialogResult = MessageBox.Show(
                    "偵測到osu在: " + Environment.NewLine + path + Environment.NewLine + "是否正確?",
                    "osu資料夾", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                return dialogResult == DialogResult.Yes;
            }, (text) => {
                FolderBrowserDialog dialog = new FolderBrowserDialog();

                dialog.ShowNewFolderButton = false;
                dialog.Description = "請選擇osu資料夾";
                dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                if (dialog.ShowDialog() == DialogResult.OK && Directory.Exists(dialog.SelectedPath)) return dialog.SelectedPath;
                return "";
            });

            if (osuPath == string.Empty || !Directory.Exists(osuPath)) Exit("需要有效的osu資料夾才能繼續!");
            if (!osuPath.EndsWith("\\")) osuPath += "\\";

            lab_OsuPath.Text = "osu資料夾: " + osuPath;

            osuFileIo.OsuSettings.Load(osuPath);
            osuFileIo.OsuDatabase.Load(osuPath + "osu!.db");

            collections = osuFileIo.CollectionLoader.LoadCollection(osuPath + "collection.db");

            foreach (Collection item in collections)   
            {
                if (item.NumberOfBeatmaps != 0)
                {
                    TreeNode treeNode = treeView1.Nodes.Add(item.Name);
                    foreach (BeatmapExtension item2 in item.AllBeatmaps())
                    {
                        treeNode.Nodes.Add(string.Format("{0} {1} - {2}", item2.MapSetId, item2.Title, item2.DiffName));
                    }
                }
            }
        }

        private void treeView1_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            btn_Export.Enabled = false;
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            btn_Export.Enabled = true;
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            TreeNode treeNode = treeView1.SelectedNode; JsonData jsonData;
            if (treeNode == null) return;
            if (treeNode.Parent != null) treeNode = treeNode.Parent;
            saveFileDialog1.FileName = treeNode.Text;
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            if (File.Exists(saveFileDialog1.FileName) && MessageBox.Show("收藏夾資料已存在\r\n是否將新的收藏夾資料寫入到舊的收藏夾內?", "",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                jsonData = JsonConvert.DeserializeObject<JsonData>(File.ReadAllText(saveFileDialog1.FileName));
            }
            else
            {
                jsonData = new JsonData();
                jsonData.collection_data = new List<CollectionData>();
            }

            CollectionData collectionData = new CollectionData();
            collectionData.collection_name = treeNode.Text;
            collectionData.beatmap_data = new List<BeatmapData>();

            foreach (BeatmapExtension item in collections.First((x) => x.Name == treeNode.Text).AllBeatmaps()) collectionData.beatmap_data.Add(new BeatmapData() { beatmap_id = item.MapId, beatmap_md5 = item.Md5, beatmap_name = item.Artist + " - " + item.Title, beatmap_setid = item.MapSetId });
            jsonData.collection_data.Add(collectionData);

            File.WriteAllText(saveFileDialog1.FileName, JsonConvert.SerializeObject(jsonData));

            MessageBox.Show("完成!");
        }

        void Exit(string text)
        {
            MessageBox.Show(text);
            Environment.Exit(0);
        }
    }

    public class BeatmapData
    {
        public int beatmap_setid { get; set; }
        public int beatmap_id { get; set; }
        public string beatmap_name { get; set; }
        public string beatmap_md5 { get; set; }
    }

    public class CollectionData
    {
        public string collection_name { get; set; }
        public List<BeatmapData> beatmap_data { get; set; }
    }

    public class JsonData
    {
        public List<CollectionData> collection_data { get; set; }
    }
}
