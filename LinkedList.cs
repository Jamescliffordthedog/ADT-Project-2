using System;

namespace ADT_Project_2
{
    public class LinkedList
    {
        public Node? Head { get; set; };
        public int Count { get; set; };

        public LinkedList()
        {
            Head = null;
            Count = 0;
        }

        public void DisplayPlaylist()
        {
            Node current = Head;
            int index = 1;

            if (Head == null)
            {
                Console.WriteLine("This playlist has no songs");
                return;
            }

            while (true)
            {
                Console.WriteLine(index + ". " + current.Data.displaySong() + "/n");
                current = current.Next!;
                index++;

                if (current == Head)
                    break;
            }
        }

        public void Add(Song song)
        {
            Node currentNode = new Node(song);

            if (Head == null)
            {
                Head = currentNode;
                Head.Next = Head;
                Head.Prev = Head;
            }
            else
            {
                Node tail = Head.prev;
                Head.Prev = currentNode;
                tail.Next = currentNode;
                currentNode.Next = Head;
                currentNode.Prev = tail;
            }

            Count++;
        }

        public void DeleteByTitle(Song song)
        {

        }

        public void DeleteByPosition(Song song)
        {

        }

        public void SearchSong(Song song)
        {

        }


    }
}
