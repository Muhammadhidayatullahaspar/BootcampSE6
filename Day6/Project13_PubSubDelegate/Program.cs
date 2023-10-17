using Project13_PubSubDelegate;
class Program {
	static void Main(){
		Penjual pub = new Penjual();
		
		Pembeli sub1 = new Pembeli();
		Pembeli2 sub2 = new Pembeli2();
		Pembeli3 sub3 = new Pembeli3();
		
		pub.Masak(sub1.Notification);
		pub.Masak(sub2.Notification);
		pub.Masak(sub3.Notification);
		
		pub.UploadVideo();
		pub.RemoveSubscriber(sub1.Notification);
		pub.UploadVideo();
		
	}
}