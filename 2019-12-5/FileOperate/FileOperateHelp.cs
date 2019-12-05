/// <summary>
/// �ļ�������
/// �ر�ע�⣺
/// 1.�ڷ�web������,HttpContext.Current.Server.MapPathʧЧ������,��Ҫʹ��System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
///   ��ȡ��Ŀ¼,Ȼ��д����Ŀ¼�AppDomain.CurrentDomain.BaseDirectory����ȡ��Debug�ļ��У��޷�ʹ�����·��
/// 2.��web������,����ʹ��HttpContext.Current.Server.MapPath����ת����ʹ�÷���ͨ�� ~/��λ��һ��Ŀ¼��eg��FileOperateHelp.Write_Txt("~/TestFile/mr.txt", "mr");
/// </summary>
public static class FileOperateHelp
{
    #region 01.д�ļ�(.txt-����)
    /// <summary>
    /// д�ļ�(����Դ�ļ�����)
    /// �ļ������ڵĻ��Զ�����
    /// </summary>
    /// <param name="FileName">�ļ�·��(web�����·��,����̨�ڸ�Ŀ¼��д)</param>
    /// <param name="Content">�ļ�����</param>
    public static string Write_Txt(string FileName, string Content)
    {
        try
        {
            Encoding code = Encoding.GetEncoding("gb2312");
            string htmlfilename = FileOperateHelp.PathConvert(FileName);
            //string htmlfilename = HttpContext.Current.Server.MapPath(FileName + ".txt");��//�����ļ���·��  
            string str = Content;
            StreamWriter sw = null;
            {
                try
                {
                    sw = new StreamWriter(htmlfilename, false, code);
                    sw.Write(str);
                    sw.Flush();
                }
                catch { }
            }
            sw.Close();
            sw.Dispose();
            return "ok";
        }
        catch (Exception ex)
        {

            return ex.Message;
        }

    }
    #endregion

    #region 02.���ļ�(.txt)
    /// <summary>
    /// ���ļ�
    /// </summary>
    /// <param name="filename">�ļ�·��(web�����·��,����̨�ڸ�Ŀ¼��д)</param>
    /// <returns></returns>
    public static string Read_Txt(string filename)
    {

        try
        {
            Encoding code = Encoding.GetEncoding("gb2312");
            string temp = FileOperateHelp.PathConvert(filename);
            //  string temp = HttpContext.Current.Server.MapPath(filename + ".txt");
            string str = "";
            if (File.Exists(temp))
            {
                StreamReader sr = null;
                try
                {
                    sr = new StreamReader(temp, code);
                    str = sr.ReadToEnd(); // ��ȡ�ļ�  
                }
                catch { }
                sr.Close();
                sr.Dispose();
            }
            else
            {
                str = "";
            }
            return str;
        }
        catch (Exception ex)
        {

            return ex.Message;
        }
    }
    #endregion

    #region 03.д�ļ���.txt-��ӣ�
    /// <summary>  
    /// д�ļ�  
    /// </summary>  
    /// <param name="FileName">�ļ�·��(web�����·��,����̨�ڸ�Ŀ¼��д)</param>  
    /// <param name="Strings">�ļ�����</param>  
    public static string WriteFile(string FileName, string Strings)
    {
        try
        {
            string Path = FileOperateHelp.PathConvert(FileName);

            if (!System.IO.File.Exists(Path))
            {
                System.IO.FileStream f = System.IO.File.Create(Path);
                f.Close();
                f.Dispose();
            }
            System.IO.StreamWriter f2 = new System.IO.StreamWriter(Path, true, System.Text.Encoding.UTF8);
            f2.WriteLine(Strings);
            f2.Close();
            f2.Dispose();
            return "ok";
        }
        catch (Exception ex)
        {

            return ex.Message;
        }
    }
    #endregion

    #region 04.���ļ���.txt��
    /// <summary>  
    /// ���ļ�  
    /// </summary>  
    /// <param name="FileName">�ļ�·��(web�����·��,����̨�ڸ�Ŀ¼��д)</param>  
    /// <returns></returns>  
    public static string ReadFile(string FileName)
    {
        try
        {
            string Path = FileOperateHelp.PathConvert(FileName);
            string s = "";
            if (!System.IO.File.Exists(Path))
                s = "��������Ӧ��Ŀ¼";
            else
            {
                StreamReader f2 = new StreamReader(Path, System.Text.Encoding.GetEncoding("gb2312"));
                s = f2.ReadToEnd();
                f2.Close();
                f2.Dispose();
            }
            return s;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    #endregion

    #region 05.ɾ���ļ�
    /// <summary>  
    /// ɾ���ļ�  
    /// </summary>  
    /// <param name="Path">�ļ�·��(web�����·��,����̨�ڸ�Ŀ¼��д)</param>  
    public static string FileDel(string Path)
    {
        try
        {
            string temp = FileOperateHelp.PathConvert(Path);
            File.Delete(temp);
            return "ok";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    #endregion

    #region 06.�ƶ��ļ�
    /// <summary>  
    /// �ƶ��ļ�  
    /// </summary>  
    /// <param name="OrignFile">ԭʼ·��(web�����·��,����̨�ڸ�Ŀ¼��д)</param>  
    /// <param name="NewFile">��·��,��Ҫд��·���µ��ļ��������ܵ�д·��(web�����·��,����̨�ڸ�Ŀ¼��д)</param>  
    public static string FileMove(string OrignFile, string NewFile)
    {
        try
        {
            OrignFile = FileOperateHelp.PathConvert(OrignFile);
            NewFile = FileOperateHelp.PathConvert(NewFile);
            File.Move(OrignFile, NewFile);
            return "ok";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    #endregion

    #region 07.�����ļ�
    /// <summary>  
    /// �����ļ�  
    /// </summary>  
    /// <param name="OrignFile">ԭʼ�ļ�(web�����·��,����̨�ڸ�Ŀ¼��д)</param>  
    /// <param name="NewFile">���ļ�·��(web�����·��,����̨�ڸ�Ŀ¼��д)</param>  
    public static string FileCopy(string OrignFile, string NewFile)
    {
        try
        {
            OrignFile = FileOperateHelp.PathConvert(OrignFile);
            NewFile = FileOperateHelp.PathConvert(NewFile);
            File.Copy(OrignFile, NewFile, true);
            return "ok";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    #endregion

    #region 08.�����ļ���
    /// <summary>  
    /// �����ļ���  
    /// </summary>  
    /// <param name="Path">���·��(web�����·��,����̨�ڸ�Ŀ¼��д)</param>  
    public static string FolderCreate(string Path)
    {
        try
        {
            Path = FileOperateHelp.PathConvert(Path);
            // �ж�Ŀ��Ŀ¼�Ƿ����������������½�֮  
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
            return "ok";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    #endregion

    #region 09.�ݹ�ɾ���ļ���Ŀ¼���ļ�
    /// <summary>  
    /// �ݹ�ɾ���ļ���Ŀ¼���ļ�  
    /// </summary>  
    /// <param name="dir">���·��(web�����·��,����̨�ڸ�Ŀ¼��д) ��ֹ����ɾ�����ģ�eg��/a/ ��aҲɾ��</param>    
    /// <returns></returns>  
    public static string DeleteFolder(string dir)
    {

        try
        {
            string adir = FileOperateHelp.PathConvert(dir);
            if (Directory.Exists(adir)) //�����������ļ���ɾ��֮   
            {
                foreach (string d in Directory.GetFileSystemEntries(adir))
                {
                    if (File.Exists(d))
                        File.Delete(d); //ֱ��ɾ�����е��ļ�                          
                    else
                        DeleteFolder(d); //�ݹ�ɾ�����ļ���   
                }
                Directory.Delete(adir, true); //ɾ���ѿ��ļ���                   
            }
            return "ok";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    #endregion

    #region 10.�����·��ת���ɾ���·��
    /// <summary>
    /// 10.�����·��ת���ɾ���·��
    /// </summary>
    /// <param name="strPath">���·��</param>
    public static string PathConvert(string strPath)
    {
        //web����ʹ��
        if (HttpContext.Current != null)
        {
            return HttpContext.Current.Server.MapPath(strPath);
        }
        else //��web��������             
        {
            strPath = strPath.Replace("/", "\\");
            if (strPath.StartsWith("\\"))
            {
                strPath = strPath.TrimStart('\\');
            }
            return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
        }
    }
    #endregion

}