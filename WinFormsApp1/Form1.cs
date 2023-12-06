namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var root = treeView1.Nodes.Add("root");
            root.Nodes.Add(new TreeNode("one"));
            root.Nodes.Add(new TreeNode("two"));
            var threeNode = new TreeNode("three");
            threeNode.Nodes.Add(new TreeNode("tt"));
            root.Nodes.Add(threeNode);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}