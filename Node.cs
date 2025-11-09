using System;

namespace ADT_Project_2
{
	public class Node
	{
		public Song Data {
			get;
			set;
		}
		public Node? Next {
			get; 
			set; 
		}
		public Node? Prev {
			get; 
			set; 
		}
	
		public Node(Song data)
		{
			Data = data;
			Next = Prev = null;
		}
	}
}
