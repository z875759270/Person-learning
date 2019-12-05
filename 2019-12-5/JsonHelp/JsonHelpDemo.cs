
public class JsonHelpDemo
{
    public string Main()
    {
        //1. 将JSON对象转换成JSON字符串
        Console.WriteLine("-------------------------------------1. 将JSON转换成JSON字符串------------------------------------------");
        var myObj = new
        {
            id = "1",
            name = "ypf",
            myList = studentList,
            myList2 = studentList.Where(u => u.Age > 27).Select(u => new
            {
                t1 = u.Age,
                t2 = u.ClassId
            }).ToList()

        };
        //1.1 方式一
        string myString1 = JsonHelp.ObjectToString(myObj);
        //1.2 方式二
        string myString2 = JsonHelp.ToJsonString(myObj);
        string myString3 = JsonHelp.ToJsonString(studentList);
        Console.WriteLine(myString1);
        Console.WriteLine(myString2);
        //2. 将JSON字符串转换成JSON对象（必须显式的声明对象）
        List<Student> myList = JsonHelp.StringToObject<List<Student>>(myString3);
        Console.WriteLine(myList);
    }
}
