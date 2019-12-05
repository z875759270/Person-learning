/// <summary>
/// 文件操作类
/// 特别注意：
/// 1.在非web程序中,HttpContext.Current.Server.MapPath失效不好用,需要使用System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
///   获取本目录,然后写到根目录里。AppDomain.CurrentDomain.BaseDirectory将获取到Debug文件夹，无法使用相对路径
/// 2.在web程序里,可以使用HttpContext.Current.Server.MapPath进行转换，使用方法通过 ~/定位到一级目录，eg：FileOperateHelp.Write_Txt("~/TestFile/mr.txt", "mr");
/// </summary>
public static class FileOperateHelp
{
    #region 01.写文件(.txt-覆盖)
    /// <summary>
    /// 写文件(覆盖源文件内容)
    /// 文件不存在的话自动创建
    /// </summary>
    /// <param name="FileName">文件路径(web里相对路径,控制台在根目录下写)</param>
    /// <param name="Content">文件内容</param>
    public static string Write_Txt(string FileName, string Content)
    {
        try
        {
            Encoding code = Encoding.GetEncoding("gb2312");
            string htmlfilename = FileOperateHelp.PathConvert(FileName);
            //string htmlfilename = HttpContext.Current.Server.MapPath(FileName + ".txt");　//保存文件的路径  
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

    #region 02.读文件(.txt)
    /// <summary>
    /// 读文件
    /// </summary>
    /// <param name="filename">文件路径(web里相对路径,控制台在根目录下写)</param>
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
                    str = sr.ReadToEnd(); // 读取文件  
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

    #region 03.写文件（.txt-追加）
    /// <summary>  
    /// 写文件  
    /// </summary>  
    /// <param name="FileName">文件路径(web里相对路径,控制台在根目录下写)</param>  
    /// <param name="Strings">文件内容</param>  
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

    #region 04.读文件（.txt）
    /// <summary>  
    /// 读文件  
    /// </summary>  
    /// <param name="FileName">文件路径(web里相对路径,控制台在根目录下写)</param>  
    /// <returns></returns>  
    public static string ReadFile(string FileName)
    {
        try
        {
            string Path = FileOperateHelp.PathConvert(FileName);
            string s = "";
            if (!System.IO.File.Exists(Path))
                s = "不存在相应的目录";
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

    #region 05.删除文件
    /// <summary>  
    /// 删除文件  
    /// </summary>  
    /// <param name="Path">文件路径(web里相对路径,控制台在根目录下写)</param>  
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

    #region 06.移动文件
    /// <summary>  
    /// 移动文件  
    /// </summary>  
    /// <param name="OrignFile">原始路径(web里相对路径,控制台在根目录下写)</param>  
    /// <param name="NewFile">新路径,需要写上路径下的文件名，不能单写路径(web里相对路径,控制台在根目录下写)</param>  
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

    #region 07.复制文件
    /// <summary>  
    /// 复制文件  
    /// </summary>  
    /// <param name="OrignFile">原始文件(web里相对路径,控制台在根目录下写)</param>  
    /// <param name="NewFile">新文件路径(web里相对路径,控制台在根目录下写)</param>  
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

    #region 08.创建文件夹
    /// <summary>  
    /// 创建文件夹  
    /// </summary>  
    /// <param name="Path">相对路径(web里相对路径,控制台在根目录下写)</param>  
    public static string FolderCreate(string Path)
    {
        try
        {
            Path = FileOperateHelp.PathConvert(Path);
            // 判断目标目录是否存在如果不存在则新建之  
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

    #region 09.递归删除文件夹目录及文件
    /// <summary>  
    /// 递归删除文件夹目录及文件  
    /// </summary>  
    /// <param name="dir">相对路径(web里相对路径,控制台在根目录下写) 截止到哪删除到哪，eg：/a/ 连a也删除</param>    
    /// <returns></returns>  
    public static string DeleteFolder(string dir)
    {

        try
        {
            string adir = FileOperateHelp.PathConvert(dir);
            if (Directory.Exists(adir)) //如果存在这个文件夹删除之   
            {
                foreach (string d in Directory.GetFileSystemEntries(adir))
                {
                    if (File.Exists(d))
                        File.Delete(d); //直接删除其中的文件                          
                    else
                        DeleteFolder(d); //递归删除子文件夹   
                }
                Directory.Delete(adir, true); //删除已空文件夹                   
            }
            return "ok";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    #endregion

    #region 10.将相对路径转换成绝对路径
    /// <summary>
    /// 10.将相对路径转换成绝对路径
    /// </summary>
    /// <param name="strPath">相对路径</param>
    public static string PathConvert(string strPath)
    {
        //web程序使用
        if (HttpContext.Current != null)
        {
            return HttpContext.Current.Server.MapPath(strPath);
        }
        else //非web程序引用             
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
