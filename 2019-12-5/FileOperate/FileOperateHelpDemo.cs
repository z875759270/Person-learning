public class FileOperateHelpDemo
{

    /// <summary>
    /// 在web程序中调用
    /// </summary>
    public void Index()
    {
        //1.写文件测试(覆盖写入)
        FileOperateHelp.Write_Txt("~/TestFile/mr.txt", "mr123");
        FileOperateHelp.Write_Txt("~/TestFile/mr2.txt", "mr123");
        //2.读文件测试
        string msg1 = FileOperateHelp.Read_Txt("~/TestFile/mr.txt");

        //3.写文件测试(追加写入)
        FileOperateHelp.WriteFile("~/TestFile/mr.txt", "123456");
        //4.读文件测试
        string msg2 = FileOperateHelp.ReadFile("~/TestFile/mr.txt");

        //5.删除文件测试
        FileOperateHelp.FileDel("~/TestFile/mr2.txt");

        //6.移动文件测试
        FileOperateHelp.FileMove("~/TestFile/mr.txt", "~/TestFile/TEST/mr移动.txt");

        //7.复制文件测试
        FileOperateHelp.FileCopy("~/TestFile/mr3.txt", "~/TestFile/TEST/mr3Copy.txt");

        //8.创建文件夹
        FileOperateHelp.FolderCreate("~/TestFile/TEST2");

        //9.递归删除文件夹（删除a文件夹）
        FileOperateHelp.DeleteFolder("~/TestFile/TestDel/a/");

    }
}