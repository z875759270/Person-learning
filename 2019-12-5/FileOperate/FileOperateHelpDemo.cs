public class FileOperateHelpDemo
{

    /// <summary>
    /// ��web�����е���
    /// </summary>
    public void Index()
    {
        //1.д�ļ�����(����д��)
        FileOperateHelp.Write_Txt("~/TestFile/mr.txt", "mr123");
        FileOperateHelp.Write_Txt("~/TestFile/mr2.txt", "mr123");
        //2.���ļ�����
        string msg1 = FileOperateHelp.Read_Txt("~/TestFile/mr.txt");

        //3.д�ļ�����(׷��д��)
        FileOperateHelp.WriteFile("~/TestFile/mr.txt", "123456");
        //4.���ļ�����
        string msg2 = FileOperateHelp.ReadFile("~/TestFile/mr.txt");

        //5.ɾ���ļ�����
        FileOperateHelp.FileDel("~/TestFile/mr2.txt");

        //6.�ƶ��ļ�����
        FileOperateHelp.FileMove("~/TestFile/mr.txt", "~/TestFile/TEST/mr�ƶ�.txt");

        //7.�����ļ�����
        FileOperateHelp.FileCopy("~/TestFile/mr3.txt", "~/TestFile/TEST/mr3Copy.txt");

        //8.�����ļ���
        FileOperateHelp.FolderCreate("~/TestFile/TEST2");

        //9.�ݹ�ɾ���ļ��У�ɾ��a�ļ��У�
        FileOperateHelp.DeleteFolder("~/TestFile/TestDel/a/");

    }
}