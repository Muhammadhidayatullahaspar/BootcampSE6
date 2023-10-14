namespace Collection;
class ObjectCollection { //
	public object[] myCollection = new object[100];
	public int counter = 0; // 
	
	public bool Add(object input) {
		myCollection[counter] = input;
		counter++;
		return true;
	}
}