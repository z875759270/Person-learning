///<summer>
///Json序列化和反序列化工具类
///<summer>
public class JsonHelp
{
    #region 01-将JSON转换成JSON字符串
    /// <summary>
    /// 将JSON转换成JSON字符串
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string ObjectToString<T>(T obj)
    {
        JavaScriptSerializer jss = new JavaScriptSerializer();
        return jss.Serialize(obj);
    }
    #endregion

    #region 02-将字符串转换成JSON对象
    /// <summary>
    /// 将字符串转换成JSON对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="content"></param>
    /// <returns></returns>
    public static T StringToObject<T>(string content)
    {
        JavaScriptSerializer jss = new JavaScriptSerializer();
        return jss.Deserialize<T>(content);
    }
    #endregion

    #region 03-将JSON转换成JSON字符串
    /// <summary>
    ///将JSON转换成JSON字符串
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string ToJsonString<T>(T obj)
    {
        return JsonConvert.SerializeObject(obj);
    }
    #endregion

    #region 04-将字符串转换成JSON对象
    /// <summary>
    /// 将字符串转换成JSON对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="content"></param>
    /// <returns></returns>
    public static T ToObject<T>(string content)
    {
        return JsonConvert.DeserializeObject<T>(content);
    }
    #endregion
}
