using System;

namespace ADT_Project_2
{
	public class Node
	{
		//Each node contains data, in this case a song object
		public Song Data {
			get;
			set;
		}
		//It will also have the ability to navigate to the next node
		public Node? Next {
			get; 
			set; 
		}
		//And the previous node
		public Node? Prev {
			get; 
			set; 
		}
		//Defines the function that creates a node
		public Node(Song data)
		{
			Data = data;
			Next = Prev = null;
		}
	}
}
