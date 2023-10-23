namespace Project10_HttpEnum;

public class WebAccess
{
	public static void ContinueAccess(HTTPRequest status) {
		if (status == HTTPRequest.NotFound) {
			Console.WriteLine((int)status);
		}
		else if (status == HTTPRequest.OK) {
			Console.WriteLine((int)status);
		}
		else
		{
			Console.WriteLine((int)status);
		}
	}
}
